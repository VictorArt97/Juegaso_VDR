
using UnityEngine;

public class tienda : MonoBehaviour
{

    public blueprints caballero;
    public blueprints peon;

  public void seleccionarCaballero()
    {
        Debug.Log("Caballero comprado");
        buildManager.selectPiezaToBuild(caballero);
    }
    public void seleccionarPeon()
    {
        Debug.Log("peon comprado");
        buildManager.selectPiezaToBuild(peon);
    }
    BuildManager buildManager;

     void Start()
     {
        buildManager = BuildManager.instance;

     }
}
