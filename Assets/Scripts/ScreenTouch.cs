﻿using System;
using UnityEngine;
using UnityEngine.EventSystems;

 public class ScreenTouch : MonoBehaviour, IPointerClickHandler
{
    public Action Touched;
    
    public void OnPointerClick(PointerEventData eventData)
    {
        Touched?.Invoke();
    }
}