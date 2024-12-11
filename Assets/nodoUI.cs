using System.Collections;
using UnityEditor.Experimental.GraphView;
using UnityEngine;



public class nodoUI : MonoBehaviour
{
   private seleccion  objetivo;
    public void establecerObjetivo(seleccion _objetivo)
    {
        objetivo = _objetivo;

        transform.position = objetivo.getBuildPosition();

    }
}
