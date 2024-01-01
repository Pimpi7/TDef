using UnityEngine;

public class Shop : MonoBehaviour
{
    BuildManager buildManager;

    void Start()
    {
        buildManager = BuildManager.instance;
    }
    public void PurchaseStandardTurret ()
    {
        Debug.Log ("Standard turret purchase");
        buildManager.SetTurretToBuild(buildManager.standardTurretPrefab);
    }

    public void PurchaseStandardTurret2 ()
    {
        Debug.Log ("Standard turret purchase2");
        buildManager.SetTurretToBuild(buildManager.anotherTurretPrefab2);
    }
}
