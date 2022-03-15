using UnityEngine;

namespace Stumps
{
    public class StumpFillingSpawn : MonoBehaviour
    {
        [SerializeField] private float _spawnOffset = 0.3f;

        [SerializeField] private Transform _knifePrefab;
        [SerializeField] private Transform _applePrefab;
        
        private Stump _stump;
        private CircleCollider2D _stumpColider;

        private int _fillingCount = 0;
        private int _appleCount = 0;
        private int _knifeCount = 0;
        
        private void Awake()
        {
            _stump = GetComponent<Stump>();
            _stumpColider = GetComponent<CircleCollider2D>();
            
            SpawnFillings();
        }

        private void SpawnFillings()
        {
            EvaluateFilling();

            float spawnDistance = (_stumpColider.radius / 2) + _spawnOffset;
            float spawnAngleStep = 360 / _fillingCount;
            
            for (int i = 1; i < _fillingCount; i++)
            {
                float angle = (spawnAngleStep * i) * Mathf.Deg2Rad;
                Vector2 spawnPosition = new Vector2(Mathf.Sin(angle), Mathf.Cos(angle));
                spawnPosition *= spawnDistance;

                if (_appleCount > 0)
                {
                    Instantiate(_applePrefab, spawnPosition, Quaternion.identity, transform);
                    _appleCount--;
                }
                else
                {
                    Instantiate(_knifePrefab, spawnPosition, Quaternion.identity, transform);
                }
                
                Debug.Log($"{spawnAngleStep * i} {spawnPosition} I{i}");
            }
        }

        private Vector3 PositionOnCircle(Vector3 center, float radius, float angle)
        {
            Vector3 position = Vector3.zero;

            angle *= Mathf.Deg2Rad;
            
            position.x = center.x + radius * Mathf.Sin(angle);
            position.y = center.y + radius * Mathf.Sin(angle);
            position.z = center.z;

            return position;
        }
        
        private void EvaluateFilling()
        {
            if (Random.Range(0, 100) <= _stump.Settings.AppleSpawnChance)
            {
                _appleCount++;
            }

            _knifeCount = Random.Range(_stump.Settings.StuckedKnifeMinimum, _stump.Settings.StuckedKnifeMaximum);

            _fillingCount = _appleCount + _knifeCount;
        }
    }
}

