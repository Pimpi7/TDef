using UnityEngine;
using UnityEngine.EventSystems;
public class Node : MonoBehaviour
{
    public Color hoverColor;

    private GameObject turret;

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
        if (buildManager.GetTurretToBuild() == null)
            return;
        if (turret != null)
        {
            Debug.Log("Spazio Occupato");
            return;
        }
        // SI COSTRUISCE 
        GameObject turretToBuild = buildManager.GetTurretToBuild();
        turret = (GameObject)Instantiate(turretToBuild, transform.position, transform.rotation);
    }

    void OnMouseEnter()
    {
        if (EventSystem.current.IsPointerOverGameObject())
            return;
        
        if (buildManager.GetTurretToBuild() == null)
            return;
        // ogni volta che il mouse ci passa sopra si attiva 
        rend.material.color = hoverColor;
    }

    void OnMouseExit()
    {
        if (EventSystem.current.IsPointerOverGameObject())
            return;
        
        rend.material.color = startColor;
    }
}
