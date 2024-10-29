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

   public GameObject prefabCaballero;

    private GameObject caballerocolocar;

    public GameObject caballerocolocado ()
    {
        return caballerocolocar ;
    }

    public void setCaballeroToBuild(GameObject caballero)
    {
        caballerocolocar = caballero;
    }
}
