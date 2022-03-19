using System.Collections.Generic;
using UnityEngine;

namespace Stumps
{
    public class StumpFillingSpawn : MonoBehaviour
    {
        [SerializeField] private GameObject _knifePrefab;
        [SerializeField] private GameObject _applePrefab;
        
        private Queue<GameObject> _fillings = new Queue<GameObject>();
        
        private Stump _stump;
        private CircleCollider2D _stumpColider;
        private Transform _stumpCenter;

        private int _fillingsCount;
        
        private void Awake()
        {
            _stump = GetComponent<Stump>();
            _stumpColider = GetComponent<CircleCollider2D>();
            _stumpCenter = transform;
            
            SpawnFillings();
        }

        private void SpawnFillings()
        {
            ComputeFilling();

            float spawnDistance = _stumpColider.radius;
            float spawnAngleStep = 360 / _fillingsCount;
            
            for (int i = 1; i <= _fillingsCount; i++)
            {
                float angle = spawnAngleStep * i;
                
                Vector3 spawnPosition = PositionOnCircle(_stumpCenter.position, spawnDistance, angle);
                Vector3 direction = spawnPosition - _stumpCenter.position;
                float angleRotation = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg + 90;
                Quaternion spawnRotation = Quaternion.AngleAxis(angleRotation,Vector3.forward);

                Instantiate(_fillings.Dequeue(), spawnPosition, spawnRotation, _stumpCenter);
            }
        }

        private Vector3 PositionOnCircle(Vector3 center, float radius, float angle)
        {
            Vector3 position;
            angle *= Mathf.Deg2Rad;
            
            position.x = center.x + radius * Mathf.Sin(angle);
            position.y = center.y + radius * Mathf.Cos(angle);
            position.z = center.z;

            return position;
        }
        
        private void ComputeFilling()
        {
            if (Random.Range(0, 100) <= _stump.Settings.AppleSpawnChance)
            {
                _fillings.Enqueue(_applePrefab);
            }

            int knifeCount = Random.Range(_stump.Settings.StuckedKnifeMinimum, _stump.Settings.StuckedKnifeMaximum);

            for (int i = 0; i < knifeCount; i++)
            {
                _fillings.Enqueue(_knifePrefab);
            }

            _fillingsCount = _fillings.Count;
        }
    }
}

