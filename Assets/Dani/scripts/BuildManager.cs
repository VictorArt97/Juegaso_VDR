using UnityEditor.Experimental.GraphView;
using UnityEngine;

public class BuildManager : MonoBehaviour
{
    public static BuildManager instance;

    void Awake()
    {
        if ( instance != null)
        {
            Debug.LogError("Hay mas de un buildmanager");
        }
        instance = this;
    }

    public GameObject prefabEstandarCaballero;
    public GameObject prefabEstandarPeon;

    private blueprints piezaColocar;

    public bool puedeConstruir { get { return piezaColocar != null; } }
    
    public void buildPiezaOn( seleccion node)
    {
        if (Player_Stats.Dinero  < piezaColocar.coste)
        {
            Debug.Log("No hay dinero");
            return;
        }

        Player_Stats.Dinero -= piezaColocar.coste;

      GameObject pieza = (GameObject) Instantiate(piezaColocar.prefab, node.getBuildPosition(), Quaternion.identity);
      node.pieza = pieza;
       
    }

   public void selectPiezaToBuild(blueprints pieza)
    {
        piezaColocar = pieza;
    }
}