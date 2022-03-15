using UnityEngine;

[CreateAssetMenu(fileName = "ThrowingSettingsDefault", menuName = "Throwing & Knifes/Create Throwing Settings", order = 1)]
public class ThrowingSettings : ScriptableObject
{
    public float PowerThrow = 50;
    public float ReloadDelay = 0.1f;
}
