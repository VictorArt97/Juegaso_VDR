using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tablero : MonoBehaviour
{
    private const int Total_Casillas_X = 12;
    private const int Total_Casillas_Y = 12;
    private GameObject[,] casillas;

    private void Awake()
    {
        GenerarTodasLasCasillas(1, Total_Casillas_X, Total_Casillas_Y);


    }

    private void GenerarTodasLasCasillas(float tamanioCasilla, int contadorCasillasX, int contadorCasillasY  )
    {
        casillas = new GameObject[contadorCasillasX, contadorCasillasY];
        //for (int X = 0; X < contadorCasillasX; X++)
        //for (int y = 0; y < contadorCasillasY; y++)
       // casillas[X, y] = GenerarUnaCasilla(tamanioCasilla, X, y);


    }
    private void GenerarUnaCasilla(float tamanioCasilla, int x, int y)
    {
        GameObject objetoCasilla = new GameObject(string.Format("x:{0}, y:{1}", x, y));
        objetoCasilla.transform.parent= transform;
        //return objetoCasilla;

    
    }
}
