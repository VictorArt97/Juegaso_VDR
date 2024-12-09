using System.Collections;
using System.Collections.Generic;
using UnityEditor.Experimental.GraphView;
using UnityEngine;

public class nodoUI : MonoBehaviour
{
   private Node objetivo;
    public void establecerObjetivo(Node _objetivo)
    {
        objetivo = _objetivo;

        //transform.position = objetivo.getBuildPosition();

    }
}
