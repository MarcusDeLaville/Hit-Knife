using System;
using Levels;
using UnityEngine;

namespace Stumps
{
    public class StumpSpawner : MonoBehaviour
    {
        public Action<Stump> StumpSpawned;

        [SerializeField] private GameHandler _gameHandler;
        [SerializeField] private LevelHandler _levelHandler;
        [SerializeField] private Transform _spawnPoint;

        private Stump _spawnedStump;

        private void OnEnable()
        {
            _levelHandler.StageChanged += level => Spawn(level.Stump);
        }

        private void OnDisable()
        {
            _levelHandler.StageChanged -= level => Spawn(level.Stump);
        }

        private void Spawn(Stump stump)
        {
            DestructStump();
            
            _spawnedStump = Instantiate(stump, _spawnPoint);
            StumpSpawned?.Invoke(_spawnedStump);
        }

        private void DestructStump()
        {
            if (_spawnedStump != null)
            {
                Destroy(_spawnedStump.gameObject);
                
            }
        }
    }
}