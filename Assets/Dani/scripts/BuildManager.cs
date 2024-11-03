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

    private GameObject piezaColocar;

    public GameObject getPiezaToBuild ()
    {
        return piezaColocar ;
    }

    public void setPiezaToBuild(GameObject caballero)
    {
        piezaColocar = caballero;
    }
}
