using System;
using System.Collections.Generic;
using Levels;
using UnityEngine;
using UnityEngine.UI;

public class KnifeCounter : MonoBehaviour
{
    [SerializeField] private LevelHandler _levelHandler;
    [SerializeField] private KnifeThrower _thrower;
    [SerializeField] private List<Image> _knifesImages;

    [SerializeField] private Text _knifeThrowed;
    
    [SerializeField] private Color _availableKnife;
    [SerializeField] private Color _stuckedKnife;
    
    private int _knifesCount;
    private int _stuckedKnifesCount;

    private int _knifeThrowedCount;
    
    private void OnEnable()
    {
        _thrower.KnifeThrow += DepriveKnife;
        _levelHandler.StageChanged += level => SetTotalKnifesCount(level.KnifeCount);
    }

    private void OnDisable()
    {
        _thrower.KnifeThrow -= DepriveKnife;
        _levelHandler.StageChanged -= level => SetTotalKnifesCount(level.KnifeCount);
    }

    private void DepriveKnife()
    {
        RedrawStuckedKnife();
        _stuckedKnifesCount++;
        _knifeThrowedCount++;
        _knifeThrowed.text = _knifeThrowedCount.ToString();
    }

    private void SetTotalKnifesCount(int totalValue)
    {
        _knifesCount = totalValue;
        _stuckedKnifesCount = 0;
        DrawKnifeCount();
    }

    private void DrawKnifeCount()
    {
        for (int i = 0; i < _knifesImages.Count; i++)
        {
            if (i < _knifesCount)
            {
                _knifesImages[i].gameObject.SetActive(true);
                _knifesImages[i].color = _availableKnife;
            }
            else
            {
                _knifesImages[i].gameObject.SetActive(false);
            }
        }
    }

    private void RedrawStuckedKnife()
    {
        _knifesImages[_stuckedKnifesCount].color = _stuckedKnife;
    }
}
