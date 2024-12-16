using System.Collections;

using UnityEngine;

[System.Serializable]
public class blueprints 
{
    public GameObject prefab;
    public int coste;

    public int GetCantidadCoste()
    {
        return coste;    
    } 
}
