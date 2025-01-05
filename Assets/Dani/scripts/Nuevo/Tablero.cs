using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class Tablero : MonoBehaviour
{
    private const int Total_Casillas_X = 12;
    private const int Total_Casillas_Y = 12;
    private GameObject[,] casillas;

    private void Awake()
    {
        GenerarTodasLasCasillas(1.8f, Total_Casillas_X, Total_Casillas_Y);


    }

    private void GenerarTodasLasCasillas(float tamanioCasilla, int contadorCasillasX, int contadorCasillasY  )
    {
        casillas = new GameObject[contadorCasillasX, contadorCasillasY];
        for (int X = 0; X < contadorCasillasX; X++)
        {
            for (int y = 0; y < contadorCasillasY; y++)
            {
                casillas[X, y] = GenerarUnaCasilla(tamanioCasilla, X, y);
            }
            
        }
    }

    private GameObject GenerarUnaCasilla(float tamanioCasilla, int x, int y)
    {
        GameObject objetoCasilla = new GameObject(string.Format("x{0}, y:{1}", x, y));
        objetoCasilla.transform.parent = transform;

        Mesh mesh = new Mesh();
        objetoCasilla.AddComponent<MeshFilter>().mesh = mesh;
        objetoCasilla.AddComponent<MeshRenderer>();

        Vector3[] vertices = new Vector3[4];
        vertices[0] = new Vector3(x* tamanioCasilla, 0, y*tamanioCasilla);
        vertices[1] = new Vector3(x* tamanioCasilla, 0, (y+1)*tamanioCasilla);
        vertices[2] = new Vector3((x+1)* tamanioCasilla, 0, y*tamanioCasilla);
        vertices[3] = new Vector3((x+1)* tamanioCasilla, 0, (y+1)*tamanioCasilla);

        int[] tris = new int[]{0, 1, 2, 1, 3, 2};

        mesh.vertices = vertices; 
        mesh.triangles = tris;

        objetoCasilla.AddComponent<BoxCollider>();

        return objetoCasilla;
        
    }
}
