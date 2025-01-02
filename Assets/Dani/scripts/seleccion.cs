using UnityEngine;
using UnityEngine.EventSystems;

public class seleccion : MonoBehaviour
{
    private Renderer rend;
    public Color hovercolor;
    private Color colorInicial;
    private Color colorSinDinero;

    BuildManager buildManager;

    public blueprints blueprints;

    public GameObject pieza;


    private void Start()
    {
        rend = GetComponent<Renderer>();
        colorInicial = rend.material.color; 

        buildManager = BuildManager.instance;
    }

    public Vector3 getBuildPosition()
    {
        return transform.position;
    }

    private void OnMouseEnter()
    {
        rend.material.color = hovercolor;
        if (EventSystem.current.IsPointerOverGameObject())
            return;
        if (!buildManager.puedeConstruir)
         return;

        if (buildManager.tieneDinero)
        {
            rend.material.color = hovercolor;

        }
        else
        {
            rend .material.color = colorSinDinero;
        
        }

    }

    private void OnMouseExit()
    {
        rend.material.color = colorInicial ;

    }

    private void OnMouseDown()
    {
        if (EventSystem.current.IsPointerOverGameObject())
            return;


        if (pieza != null)
        {
            buildManager.SeleccionarNodo(this);
            return;
        }

        if (!buildManager.puedeConstruir)
         return;
       
       
       buildManager.buildPiezaOn(this);

        


    }

    public void venderPieza()
    {
        Player_Stats.Dinero += blueprints.GetCantidadCoste();

        Destroy(pieza);

        blueprints = null;
    }
}
