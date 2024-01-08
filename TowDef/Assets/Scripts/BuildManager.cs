using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuildManager : MonoBehaviour
{
    public static BuildManager instance;

    void Awake()
    {
        if (instance != null)
        {
            Debug.LogError("piu buildmanager");
            return;
        }
        instance = this;
    }

    public GameObject standardTurretPrefab;
    public GameObject anotherTurretPrefab2;
    private TurretBlueprint turretToBuild;

    public bool CanBuild { get { return turretToBuild != null; } }
    public bool HasMoney { get { return PlayerStats.Money >= turretToBuild.cost; } }

    /*public void BuildTurretOn(Node node)
    {
        
        if (PlayerStats.Money < turretToBuild.cost)
        {
            Debug.Log ("POVERO");
            return;
        }

        PlayerStats.Money =  PlayerStats.Money - turretToBuild.cost;
        // Instantiate the prefab directly from turretToBuild
        GameObject turret = Instantiate(turretToBuild.prefab, node.GetBuildPosition(), Quaternion.identity);
        
        node.turret = turret;

        Debug.Log("Turret built, sei povero: " + PlayerStats.Money);
    }*/

    public void BuildTurretOn(Node node)
{
    if (turretToBuild == null || turretToBuild.prefab == null)
    {
        Debug.LogError("Turret to build or its prefab is null!");
        return;
    }

    if (PlayerStats.Money < turretToBuild.cost)
    {
        Debug.Log("Not enough money!");
        return;
    }

    PlayerStats.Money -= turretToBuild.cost;

    // Instantiate the prefab directly from turretToBuild
    GameObject turret = Instantiate(turretToBuild.prefab, node.GetBuildPosition(), Quaternion.identity);
    
    if (turret != null)
    {
        node.turret = turret;
        Debug.Log("Turret built. Money left: " + PlayerStats.Money);
    }
    else
    {
        Debug.LogError("Failed to instantiate turret prefab!");
    }
}


    public void SelectTurretToBuild(TurretBlueprint turret)
    {
        turretToBuild = turret;
    }
}
