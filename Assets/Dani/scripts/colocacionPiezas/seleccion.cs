using UnityEngine;

public class seleccion : MonoBehaviour
{
    private Renderer rend;
    public Color hovercolor;
    private Color colorInicial;



    private GameObject capsule;
    private void Start()
    {
        rend = GetComponent<Renderer>();
    }
    private void OnMouseEnter()
    {
        rend.material.color = hovercolor;
    }

    private void OnMouseExit()
    {
        rend.material.color = colorInicial ;
    }

    private void OnMouseDown()
    {
        if (capsule != null)
        {
            Debug.Log("No puedes poner esto aqui");
            return;
        }
       
        GameObject capsulacolocar = BuildManager.instance.capsulacolocada();
        
        capsule = (GameObject)Instantiate(capsulacolocar, transform.position, transform.rotation);
    }
}
