using UnityEngine;

public class Shop : MonoBehaviour
{
    public TurretBlueprint standardTurret;
    public TurretBlueprint missilelauncher;
    BuildManager buildManager;

    void Start()
    {
        buildManager = BuildManager.instance;
    }
    public void SelectStandardTurret ()
    {
        Debug.Log ("Standard turret purchase");
        buildManager.SelectTurretToBuild(standardTurret);
    }

    public void SelectMissileLauncher()
    {
        Debug.Log ("Standard turret purchase2");
        buildManager.SelectTurretToBuild(missilelauncher);
    }
}
