using UnityEngine;

public class seleccion : MonoBehaviour
{
    private Renderer rend;
    public Color hovercolor;
    private Color colorInicial;

    BuildManager buildManager;



    private GameObject caballero;
    private void Start()
    {
        rend = GetComponent<Renderer>();

        buildManager = BuildManager.instance;
    }
    private void OnMouseEnter()
    {
        rend.material.color = hovercolor;
        if (buildManager.caballerocolocado() == null)
         return;
        
    }

    private void OnMouseExit()
    {
        rend.material.color = colorInicial ;
    }

    private void OnMouseDown()
    {
        if (buildManager.caballerocolocado()== null)
         return;
       
        if (caballero != null)
        {
            Debug.Log("No puedes poner esto aqui");
            return;
        }
       
        GameObject capsulacolocar = buildManager.caballerocolocado();
        
        caballero = (GameObject)Instantiate(capsulacolocar, transform.position, transform.rotation);
    }
}
