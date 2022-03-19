using System;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

namespace Levels
{
    public class LevelHandler : MonoBehaviour
    {
        public Action<Stage> StageChanged;
        
        [SerializeField] private GameHandler _gameHandler;
        [SerializeField] private List<Stage> _simpleStages;
        [SerializeField] private List<Stage> _bossStages;
        
        private int _currentStage;

        private void OnEnable()
        {
            //reword todo
            _gameHandler.StartLevel += RandomLevelSet;
        }

        private void OnDisable()
        {
            _gameHandler.StartLevel -= RandomLevelSet;
        }

        private void RandomLevelSet()
        {
            Stage stage = _simpleStages[Random.Range(0, _simpleStages.Count)];
            StageChanged?.Invoke(stage);
        }

        private void NextStage()
        {
            
        }

        private void ResetStage()
        {
        }
        
        
    }
}