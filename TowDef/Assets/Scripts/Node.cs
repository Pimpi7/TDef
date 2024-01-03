using UnityEngine;
using UnityEngine.EventSystems;
public class Node : MonoBehaviour
{
    public Color hoverColor;
    public Vector3 positionOffset;
    [Header("Optional")]
    public GameObject turret;

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
        if (!buildManager.CanBuild)
            return;
        if (turret != null)
        {
            Debug.Log("Spazio Occupato");
            return;
        }
        // SI COSTRUISCE 
        buildManager.BuildTurretOn(this);
    }

    public Vector3 GetBuildPosition ()
    {
        return transform.position + positionOffset;
    }

    void OnMouseEnter()
    {
        if (EventSystem.current.IsPointerOverGameObject())
            return;
        
        if (!buildManager.CanBuild)
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

