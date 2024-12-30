using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class Control_Canvas : MonoBehaviour
{

    [SerializeField] private GameObject[] imagen ;
    private int imagenActual;
   
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
           imagen[imagenActual]. SetActive(false);
        }
    }

    public void ActivarKnight()
    {
        imagenActual = 5;
        imagen[imagenActual] .SetActive(true);
    }
    public void ActivarPeon()
    {
        imagenActual = 0;
        imagen[imagenActual] .SetActive(true);
    }
    public void ActivarRook()
    {
        imagenActual = 4;
        imagen[imagenActual] .SetActive(true);
    }
    public void ActivarInfo()
    {
        imagenActual = 6;
        imagen[imagenActual] .SetActive(true);
    }

    public void VolverAlMenu()
    {
        this.gameObject.SetActive(false);
    }
}
