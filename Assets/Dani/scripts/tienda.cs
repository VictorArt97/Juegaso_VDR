
using UnityEngine;

public class tienda : MonoBehaviour
{
  public void comprarCaballero()
    {
        Debug.Log("Caballero comprado");
        buildManager.setCaballeroToBuild(buildManager.prefabEstandarCaballero);
    }
    public void comprarOtroCaballero()
    {
        Debug.Log("Otro caballero comprado");
       
    }
    BuildManager buildManager;

     void Start()
     {
        buildManager = BuildManager.instance;
     }
}
