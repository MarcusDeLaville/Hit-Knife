using System;
using Stumps;
using UnityEngine;
using UnityEngine.UI;

public class GameHandler : MonoBehaviour
{
    public Action StagePassed;
    public Action LevelFailed;
    public Action GoingHome;
    public Action StartLevel;

    [SerializeField] private Button _playButton;
    [SerializeField] private Button _homeButton;
    
    [SerializeField] private KnifeThrower _thrower;
    [SerializeField] private StumpSpawner _stumpSpawner;

    private void OnEnable()
    {
        _thrower.KnifeMissed += OnKnifeMissed;
        _stumpSpawner.StumpSpawned += OnStumpSpawned;
        _playButton.onClick.AddListener(() => StartLevel?.Invoke());
        _homeButton.onClick.AddListener(() => GoingHome?.Invoke());
    }

    private void OnDisable()
    {
        _thrower.KnifeMissed += OnKnifeMissed;
        _stumpSpawner.StumpSpawned += OnStumpSpawned;
    }

    private void OnKnifeMissed()
    {
        LevelFailed?.Invoke();
    }

    private void OnStumpSpawned(Stump stump)
    {
        stump.Break += OnStumpBroke;
    }

    private void OnStumpBroke()
    {
        StagePassed?.Invoke();
    }
}
