using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;
using UnityEngine.UIElements;

public class Tablero : MonoBehaviour
{

    private Pieza[,] piezasTablero;
    private Renderer rend;
    [SerializeField] private Material materialCasilla;
    private const int Total_Casillas_X = 12;
    private const int Total_Casillas_Y = 12;
    private GameObject[,] casillas;
    private Camera camaraActual;
    private Vector2Int currentHover;

     public Color hovercolor;
    private Color colorInicial;

    [Header("Prefabs y materiales")]
    [SerializeField] private GameObject[] prefabs;
    [SerializeField] private Material[] materialesEquipos;

 

    private void Awake()
    {
        GenerarTodasLasCasillas(1.8f, Total_Casillas_X, Total_Casillas_Y);

        //RECORDAR COMENTAR LA SIGUIENTE LINEA

        //spwanearUnaSolaPieza(tipoPieza.peon, 0);

        spawnearTodasLasPiezas();

    }
    private void Update()
    {
      if(!camaraActual)
      {
        camaraActual = Camera.main;
        return;
      }  

      RaycastHit info;
      Ray ray = camaraActual.ScreenPointToRay(Input.mousePosition);
      if(Physics.Raycast(ray, out info, 100, LayerMask.GetMask("Casilla", "Hover")))
      {
        Vector2Int hitPosition = MirarInformacionCasilla(info.transform.gameObject);
        //esto ocurre en caso de que no estuvieramos apuntando a ninguna otra casilla
        if(currentHover == -Vector2Int.one)
        {
            currentHover = hitPosition;
            casillas[hitPosition.x, hitPosition.y].layer = LayerMask.NameToLayer("Hover");
        }
        //esto ocurre cuando pasamos de una casilla a otra
        if(currentHover != -Vector2Int.one)
        {
            casillas[currentHover.x, currentHover.y].layer = LayerMask.NameToLayer("Casilla");
            currentHover = hitPosition;
            casillas[hitPosition.x, hitPosition.y].layer = LayerMask.NameToLayer("Hover");
        }
      }
      else
      {
        if(currentHover != Vector2Int.one)
        {
            casillas[currentHover.x, currentHover.y].layer = LayerMask.NameToLayer("Casilla");
           currentHover = Vector2Int.one; 
        }
      }
    }

//Tablero
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
        objetoCasilla.AddComponent<MeshRenderer>().material = materialCasilla;

        Vector3[] vertices = new Vector3[4];
        vertices[0] = new Vector3(x* tamanioCasilla, 0, y*tamanioCasilla);
        vertices[1] = new Vector3(x* tamanioCasilla, 0, (y+1)*tamanioCasilla);
        vertices[2] = new Vector3((x+1)* tamanioCasilla, 0, y*tamanioCasilla);
        vertices[3] = new Vector3((x+1)* tamanioCasilla, 0, (y+1)*tamanioCasilla);

        int[] tris = new int[]{0, 1, 2, 1, 3, 2};

        mesh.vertices = vertices; 
        mesh.triangles = tris;

        objetoCasilla.layer = LayerMask.NameToLayer("Casilla");
        mesh.RecalculateNormals();
        objetoCasilla.AddComponent<BoxCollider>();

        return objetoCasilla;
        
    }

private Vector2Int MirarInformacionCasilla(GameObject hitInfo)
{
    for(int x = 0 ; x < Total_Casillas_X ; x++)
    {
        for (int y = 0; y < Total_Casillas_Y; y++)
        {
            if(casillas[x,y] == hitInfo)
            {
                return new Vector2Int(x,y);
            }
        }
    }
    return -Vector2Int.one; //invalido
}
 

//Spawnear Piezas

private void spawnearTodasLasPiezas()
{
    piezasTablero = new Pieza[Total_Casillas_X, Total_Casillas_Y];

    int equipoRosa = 0, equipoAzul = 1;

    //equipo rosa

    piezasTablero[0,0] = spwanearUnaSolaPieza(tipoPieza.caballero, equipoRosa);
    piezasTablero[0,11] = spwanearUnaSolaPieza(tipoPieza.caballero, equipoRosa);
    piezasTablero[0,3] = spwanearUnaSolaPieza(tipoPieza.alfil, equipoRosa);
    piezasTablero[0,9] = spwanearUnaSolaPieza(tipoPieza.alfil, equipoRosa);
    piezasTablero[0,5] = spwanearUnaSolaPieza(tipoPieza.caballero, equipoRosa);
    piezasTablero[0,7] = spwanearUnaSolaPieza(tipoPieza.caballero, equipoRosa);
    piezasTablero[0,6] = spwanearUnaSolaPieza(tipoPieza.reina, equipoRosa);

}
private Pieza spwanearUnaSolaPieza(tipoPieza tipo, int equipo)
{
    Pieza p = Instantiate(prefabs[(int)tipo -1], transform).GetComponent<Pieza>();

    p.tipo = tipo;
    p.equipo = equipo;
    p.GetComponent<MeshRenderer>().material = materialesEquipos[equipo];

    return p;
}

private void ColocarTodasLasPiezas()
{
    for(int x = 0; x < Total_Casillas_X; x++)
    {
        for(int y = 0; y < Total_Casillas_Y; y++)
        {
            if(piezasTablero[x,y] != null)
            {
                ColocarUnaPieza(x, y, true);
            }
        }
    }
}

private void ColocarUnaPieza(int x, int y, bool force = false)
{
    piezasTablero[x,y].xActual = x;
    piezasTablero[x,y].xActual = y;
    //piezasTablero[x,y].transform.position = new Vector3(x*, yof)
}

}
