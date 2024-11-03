using UnityEngine;

public class seleccion : MonoBehaviour
{
    private Renderer rend;
    public Color hovercolor;
    private Color colorInicial;

    BuildManager buildManager;



    private GameObject pieza;
    private void Start()
    {
        rend = GetComponent<Renderer>();

        buildManager = BuildManager.instance;
    }
    private void OnMouseEnter()
    {
        rend.material.color = hovercolor;
        if (buildManager.getPiezaToBuild() == null)
         return;
        
    }

    private void OnMouseExit()
    {
        rend.material.color = colorInicial ;
    }

    private void OnMouseDown()
    {
        if (buildManager.getPiezaToBuild()== null)
         return;
       
        if (pieza != null)
        {
            Debug.Log("No puedes poner esto aqui");
            return;
        }
       
        GameObject piezaColocar = buildManager.getPiezaToBuild();
        
        pieza = (GameObject)Instantiate(piezaColocar, transform.position, transform.rotation);
    }
}
