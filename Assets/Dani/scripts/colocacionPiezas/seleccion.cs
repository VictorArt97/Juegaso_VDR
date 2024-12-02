using UnityEngine;
using UnityEngine.EventSystems;

public class seleccion : MonoBehaviour
{
    private Renderer rend;
    public Color hovercolor;
    private Color colorInicial;
    private Color colorSinDinero;

    BuildManager buildManager;



    public GameObject pieza;


    private void Start()
    {
        rend = GetComponent<Renderer>();

        buildManager = BuildManager.instance;
    }

    public Vector3 getBuildPosition()
    {
        return transform.position;
    }

    private void OnMouseEnter()
    {
        rend.material.color = hovercolor;
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
        if (!buildManager.puedeConstruir)
         return;
       
        if (pieza != null)
        {
            Debug.Log("No puedes poner esto aqui");
            return;
        }
       
       buildManager.buildPiezaOn(this);

        if (buildManager.puedeConstruir)
            return;


    }
}
