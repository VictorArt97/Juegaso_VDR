
using UnityEngine.UI;
using UnityEngine;



public class nodoUI : MonoBehaviour
{
    public GameObject ui;

   private seleccion  objetivo;
    public void establecerObjetivo(seleccion _objetivo)
    {
        objetivo = _objetivo;

        transform.position = objetivo.getBuildPosition() ;

        ui.SetActive(true);

    }

    public void esconder()
    {
        ui.SetActive(false);

    }

    public void vender()
    {
        objetivo.venderPieza();
        BuildManager.instance.deseleccionarNodo();
    }
}
