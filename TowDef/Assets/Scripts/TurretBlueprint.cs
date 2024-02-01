using UnityEngine;

[System.Serializable]
public class TurretBlueprint
{
    public GameObject prefab;
    public int cost; // This should be the actual turret GameObject
    
    // Other properties related to your turret blueprint
    public GameObject upgradedPrefab;
    public int upgradeCost;
}

