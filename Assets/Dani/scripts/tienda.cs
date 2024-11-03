
using UnityEngine;

public class tienda : MonoBehaviour
{
  public void comprarCaballero()
    {
        Debug.Log("Caballero comprado");
        buildManager.setPiezaToBuild(buildManager.prefabEstandarCaballero);
    }
    public void comprarPeon()
    {
        Debug.Log("peon comprado");
       buildManager.setPiezaToBuild(buildManager.prefabEstandarPeon)
    }
    BuildManager buildManager;

     void Start()
     {
        buildManager = BuildManager.instance;
     }
}
