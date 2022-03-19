using DG.Tweening;
using UnityEngine;
using Random = UnityEngine.Random;

namespace Stumps
{
    [RequireComponent(typeof(Stump))]
    public class StumpEndurance : MonoBehaviour
    {
        [SerializeField] private ParticleSystem _hitEffectPrefab;
        [SerializeField] private ParticleSystem _breakEffect;
        [SerializeField] private SpriteRenderer _spriteRenderer;
        
        [Space(10)] [SerializeField] private Vector3 _punchForse;
        [SerializeField] private float _punchDuration = 0.3f;
        [SerializeField] private int _punchVibrato = 3;
    
        private Transform _transform;
        private Stump _stump;
        private ParticleSystem _spawnedHitEffect;

        private int _endurance = 5;
        
        private void Awake()
        {
            _transform = transform;
            _stump = GetComponent<Stump>();
            
            _spawnedHitEffect = Instantiate(_hitEffectPrefab);
        }

        private void OnDestroy()
        {
            Destroy(_spawnedHitEffect);
        }
        
        public void Hit(Vector3 hitPoint)
        {
            _endurance--;
            _spawnedHitEffect.transform.position = hitPoint;
            _transform.DOPunchScale(_punchForse, _punchDuration, _punchVibrato);
            _spawnedHitEffect.Play();
            TryBreak();
        }

        private void TryBreak()
        {
            if (_endurance <= 0)
            {
                Break();
            }
        }

        private void Break()
        {
            _stump.enabled = false;
            _breakEffect.Play();
            _spriteRenderer.DOFade(0, 0.25f);
            
            Transform[] fillings = GetComponentsInChildren<Transform>(false);

            int side = 1;
            
            foreach (var filling in fillings)
            {
                side *= -1;
                Vector3 direction = new Vector3(8 * side, Random.Range(5, -5));
                filling.DOMove(direction, 1f);
            }
            
            _stump.Break?.Invoke();
        }
    }
}