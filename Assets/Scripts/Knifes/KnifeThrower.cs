using UnityEngine;
using Utils;

public class KnifeThrower : MonoBehaviour
{
        [SerializeField] private ThrowingSettings _settings;

        [SerializeField] private ScreenTouch _screen;

        [SerializeField] private Knife _knifePrefab;
        [SerializeField] private Transform _knifeSpawnPoint;
        
        private Knife _spawnedKnife;
        private bool _throwingAvailable;

        private void Start()
        {
                Reload();
        }

        private void OnEnable()
        {
                _screen.Touched += Throw;
        }

        private void OnDisable()
        {
                _screen.Touched -= Throw;
        }

        private void Throw()
        {
                if(_throwingAvailable == false) return;
                _throwingAvailable = false;
                
                _spawnedKnife.Collider.enabled = true;
                _spawnedKnife.Rigidbody.freezeRotation = true;
                _spawnedKnife.Rigidbody.isKinematic = false;
                _spawnedKnife.Rigidbody.AddForce(Vector2.up * _settings.PowerThrow, ForceMode2D.Impulse);

                DelayedCallUtil.DelayedCall(_settings.ReloadDelay, () => Reload());
        }

        private void Reload()
        {
                _spawnedKnife = Instantiate(_knifePrefab, _knifeSpawnPoint);
                _spawnedKnife.Collider.enabled = false;
                _throwingAvailable = true;
        }
}