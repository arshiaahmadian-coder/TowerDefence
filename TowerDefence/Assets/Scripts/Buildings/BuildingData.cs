using UnityEngine;

[CreateAssetMenu(fileName = "BuildingData", menuName = "Scriptable Objects/BuildingData")]
public class BuildingData : ScriptableObject
{
    [Header("About")]
    public int buildCost;
    public BuildingType type;

    [Header("Attack")]
    public float attackRange;
    public float attackDamage;
    public float attackTime;
}

public enum BuildingType
{
    Attacker,
    Support
}
