using UnityEngine;

[CreateAssetMenu(fileName = "StumpSettingsDefault", menuName = "Throwing & Knifes/Create Stump Settings", order = 2)]
public class StumpSettings : ScriptableObject
{
    [Range(0f,100f)]
    public float AppleSpawnChance;
    public int StuckedKnifeMinimum;
    public int StuckedKnifeMaximum;

    public AnimationCurve Multiplier;

    public float SpeedRotation = 0.7f;
}
