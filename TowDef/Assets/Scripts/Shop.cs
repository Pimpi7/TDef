using UnityEngine;

public class Shop : MonoBehaviour
{
    public TurretBlueprint standardTurret;
    public TurretBlueprint missileLauncher;
    public TurretBlueprint laserBeamer;
    public TurretBlueprint frostyTower;
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

    public void SelectFrostyTower()
    {
        Debug.Log ("Frosty tower purchased");
        buildManager.SelectTurretToBuild(frostyTower);
    }
}
