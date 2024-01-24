using UnityEngine;

public class Shop : MonoBehaviour
{
    public TurretBlueprint standardTurret;
    public TurretBlueprint missileLauncher;
    public TurretBlueprint laserBeamer;
    BuildManager buildManager;

    void Start()
    {
        buildManager = BuildManager.instance;
    }
    public void SelectStandardTurret ()
    {
        Debug.Log ("Standard Turret purchased");
        buildManager.SelectTurretToBuild(standardTurret);
    }

    public void SelectMissileLauncher()
    {
        Debug.Log ("Standard Missile Launcher purchased");
        buildManager.SelectTurretToBuild(missileLauncher);
    }

    public void SelectLaserBeamer()
    {
        Debug.Log ("Laser Beamer purchased");
        buildManager.SelectTurretToBuild(laserBeamer);
    }
}
