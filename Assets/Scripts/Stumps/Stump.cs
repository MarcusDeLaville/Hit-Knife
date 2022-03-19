using System;
using UnityEngine;

namespace Stumps
{
    public class Stump : MonoBehaviour
    {
        public Action Break;
        
        [SerializeField] private StumpSettings _settings;
        
        private Transform _transform;
        private float _currentTime;
        private float _totalTime;

        public StumpSettings Settings => _settings;

        private void Awake()
        {
            _transform = transform;
            _totalTime = _settings.Multiplier.keys[_settings.Multiplier.keys.Length - 1].time;
        }

        private void Update()
        {
            _transform.Rotate(Vector3.forward * (_settings.SpeedRotation * _settings.Multiplier.Evaluate(_currentTime)));

            _currentTime += Time.deltaTime;

            if (_currentTime >= _totalTime)
            {
                _currentTime = 0;
            }
        }
    }
}