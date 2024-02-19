using System;
using UnityEngine;
using UnityEngine.EventSystems;
public class Node : MonoBehaviour
{
    public Color hoverColor;
    public Color notEnoughMoneyColor;
    public Vector3 positionOffset;
    
    [HideInInspector]
    public GameObject turret;

    [HideInInspector]
    public TurretBlueprint turretBlueprint;

    [HideInInspector]
    public Boolean isUpgraded = false;

    private Renderer rend;

    private Color startColor;

    BuildManager buildManager;

    void Start()
    {
        rend = GetComponent<Renderer>();
        startColor = rend.material.color;

        buildManager = BuildManager.instance;
    }

    void OnMouseDown ()
    {
        if (EventSystem.current.IsPointerOverGameObject())
            return;        

        if (turret != null)
        {
            buildManager.SelectNode(this);
            return;
        }

         if (!buildManager.CanBuild)
            return;

        // SI COSTRUISCE 
        BuildTurret(buildManager.GetTurretToBuild());
    }

    public Vector3 GetBuildPosition ()
    {
        return transform.position + positionOffset;
    }

    void BuildTurret(TurretBlueprint blueprint) 
    {
        if (PlayerStats.Money < blueprint.cost)
        {
            Debug.Log ("POVERO");
            return;
        }

        PlayerStats.Money -= blueprint.cost;
        // Instantiate the prefab directly from t
        GameObject _turret = Instantiate(blueprint.prefab, GetBuildPosition(), Quaternion.identity);
        turret = _turret;

        turretBlueprint = blueprint;
        /*GameObject effect = (GameObject)Instantiate(buildManager.buildEffect, GetBuildPosition(), Quaternion.identity);
		Destroy(effect, 5f);*/

        Debug.Log("Turret built");
    }

    public void UpgradeTurret()
    {
         if (PlayerStats.Money < turretBlueprint.upgradeCost)
        {
            Debug.Log ("Not enough money to update this");
            return;
        }

        PlayerStats.Money -= turretBlueprint.upgradeCost;

        //get rid of the old turret
        Destroy(turret);

        // Instantiate the prefab directly from t
        GameObject t = Instantiate(turretBlueprint.upgradedPrefab, GetBuildPosition(), Quaternion.identity);
        turret = t;
        /*GameObject effect = (GameObject)Instantiate(buildManager.buildEffect, GetBuildPosition(), Quaternion.identity);
		Destroy(effect, 5f);*/

        isUpgraded = true;

        Debug.Log("Turret upgraded");
    }

    public void SellTurret() 
    {
        PlayerStats.Money += turretBlueprint.GetSellAmount();

        GameObject effect = (GameObject)Instantiate(buildManager.sellEffect, GetBuildPosition(), Quaternion.identity);
		Destroy(effect, 5f);

        Destroy(turret);
        turretBlueprint = null;
    }

    void OnMouseEnter()
    {
        if (EventSystem.current.IsPointerOverGameObject())
            return;
        
        if (!buildManager.CanBuild)
            return;

       /* if (buildManager.HasMoney)
        {
            // ogni volta che il mouse ci passa sopra si attiva 
            rend.material.color = hoverColor;
        } else
        {
            rend.material.color = notEnoughMoneyColor;
        }*/
        
    }

    void OnMouseExit()
    {
        /*if (EventSystem.current.IsPointerOverGameObject())
            return;*/
        
        rend.material.color = startColor;
    }
}

