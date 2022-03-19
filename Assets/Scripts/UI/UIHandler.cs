using System;
using UnityEngine;

namespace UI
{
    public class UIHandler : MonoBehaviour
    {
        [SerializeField] private GameHandler _gameHandler;
        
        [Space(10)]
        [SerializeField] private Panel _homePanel;
        [SerializeField] private Panel _fightPanel;
        [SerializeField] private Panel _failPanel;

        [Space(10)] [Header("Animations")]
        [SerializeField] private Animation _knife;

        private Panel[] _allPanels;

        private void Awake()
        {
            _allPanels = FindObjectsOfType<Panel>();
        }

        private void OnEnable()
        {
            _gameHandler.StartLevel += OnPickStart;
        }

        private void OnDisable()
        {
            // throw new NotImplementedException();
        }

        private void OnPickStart()
        {
            CloseAllPanels();
            
            _knife.Animate(1);
            _fightPanel.Show(0.3f);
        }

        private void CloseAllPanels()
        {
            foreach (var panel in _allPanels)
            {
                panel.Hide();
            }
        }
    } 
}