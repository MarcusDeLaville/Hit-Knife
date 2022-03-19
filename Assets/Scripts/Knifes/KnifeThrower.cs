using System;
using Levels;
using UnityEngine;
using Utils;

public class KnifeThrower : MonoBehaviour
{
        public Action KnifeThrow;
        public Action KnifeMissed;

        [SerializeField] private LevelHandler _levelHandler;
        [SerializeField] private ThrowingSettings _settings;

        [SerializeField] private ScreenTouch _screen;

        [SerializeField] private Knife _knifePrefab;
        [SerializeField] private Transform _knifeSpawnPoint;
        
        private Knife _spawnedKnife;
        private bool _throwingAvailable;
        private int _knifeCount;
        
        private void Start()
        {
                Reload();
        }

        private void OnEnable()
        {
                _screen.Touched += Throw;
                _levelHandler.StageChanged += level => SetKnifeCount(level.KnifeCount);
        }

        private void OnDisable()
        {
                _screen.Touched -= Throw;
                _levelHandler.StageChanged -= level => SetKnifeCount(level.KnifeCount);
        }

        private void Throw()
        {
                if(_throwingAvailable == false) return;

                _knifeCount--;
                _throwingAvailable = false;
                _spawnedKnife.Collider.enabled = true;
                _spawnedKnife.Rigidbody.freezeRotation = true;
                _spawnedKnife.Rigidbody.isKinematic = false;
                _spawnedKnife.Rigidbody.AddForce(Vector2.up * _settings.PowerThrow, ForceMode2D.Impulse);

                _spawnedKnife.Miss += OnKnifeMiss;
                
                KnifeThrow?.Invoke();

                if (_knifeCount > 0)
                {
                        DelayedCallUtil.DelayedCall(_settings.ReloadDelay, () => Reload());   
                }
        }

        private void OnKnifeMiss()
        {
                KnifeMissed?.Invoke();
                Debug.Log("Knife Miss");
        }

        private void Reload()
        {
                _spawnedKnife = Instantiate(_knifePrefab, _knifeSpawnPoint);
                _spawnedKnife.Collider.enabled = false;
                _throwingAvailable = true;
        }

        private void SetKnifeCount(int count)
        {
                _knifeCount = count;
        }
}