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

    public GameObject prefabEstandarCapsula;

    private void Start()
    {
        capsulacolocar = prefabEstandarCapsula;
    }

    private GameObject capsulacolocar;

    public GameObject capsulacolocada ()
    {
        return capsulacolocar ;
    }
}
