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

    public GameObject sellEffect;              

    private TurretBlueprint turretToBuild;
    private Node selectedNode;
    public NodeUI nodeUI;
     CameraController cameraController;

    public bool CanBuild { get { return turretToBuild != null; } }
    public bool HasMoney { get { return PlayerStats.Money >= turretToBuild.cost; } }

    public void SelectNode(Node node) 
    {
        if(selectedNode == node || Input.touchCount==2) 
        {
            DeselectNode();
            return;
        }

        selectedNode = node;
        turretToBuild = null;

        nodeUI.SetTarget(node);
    }

    public void DeselectNode() 
    {
        selectedNode = null;
        nodeUI.Hide();
    }

    public void SelectTurretToBuild(TurretBlueprint turret)
    {
        turretToBuild = turret;
        DeselectNode();                                                 
    }

    public TurretBlueprint GetTurretToBuild()
    {
        return turretToBuild;
    }
}

