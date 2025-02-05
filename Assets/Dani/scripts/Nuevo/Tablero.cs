using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;
using UnityEngine.UIElements;

public class Tablero : MonoBehaviour
{

    private Pieza[,] piezasEnTablero;
    private Renderer rend;

    [SerializeField] private Material materialCasilla;
    [SerializeField] private Material materialSeleccion;
    [SerializeField] private float tamanioCasilla;
    [SerializeField] private float yOffset;
    [SerializeField] private Vector3 centroTablero = Vector3.zero;

    private const int Total_Casillas_X = 12;
    private const int Total_Casillas_Y = 12;

    private GameObject[,] casillas;
    private Camera camaraActual;
    private Vector2Int currentHover;
    private Vector3 bounds;

     public Color hovercolor;
    private Color colorInicial;

    [Header("Prefabs y materiales")]
    [SerializeField] private GameObject[] prefabs;
    [SerializeField] private Material[] materialesEquipos;

    private List<Vector2Int> movimientosDisponibles = new List<Vector2Int>();



    private Pieza piezaArrastrada;
 

    private void Awake()
    {
        GenerarTodasLasCasillas(tamanioCasilla, Total_Casillas_X, Total_Casillas_Y);

        //RECORDAR COMENTAR LA SIGUIENTE LINEA

        //spwanearUnaSolaPieza(tipoPieza.peon, 0);

        
        spawnearTodasLasPiezas();

        ColocarTodasLasPiezas();

    }
    private void Update()
    {
        if (!camaraActual)
        {
            camaraActual = Camera.main;
            return;
        }

       
      

        RaycastHit info;
        Ray ray = camaraActual.ScreenPointToRay(Input.mousePosition);
        if (Physics.Raycast(ray, out info, 100, LayerMask.GetMask("Casilla", "Hover")))
        {
            Vector2Int hitPosition = MirarInformacionCasilla(info.transform.gameObject);
            //esto ocurre en caso de que no estuvieramos apuntando a ninguna otra casilla
            if (currentHover == -Vector2Int.one)
            {
                currentHover = hitPosition;

                casillas[hitPosition.x, hitPosition.y].layer = LayerMask.NameToLayer("Hover");
                casillas[hitPosition.x, hitPosition.y].GetComponent<Renderer>().material = materialSeleccion;
            }
            //esto ocurre cuando pasamos de una casilla a otra
            if (currentHover != -Vector2Int.one)
            {
                casillas[currentHover.x, currentHover.y].layer = LayerMask.NameToLayer("Casilla");


                currentHover = hitPosition;

                casillas[hitPosition.x, hitPosition.y].layer = LayerMask.NameToLayer("Hover");
                casillas[hitPosition.x, hitPosition.y].GetComponent<Renderer>().material = materialSeleccion;
             
            }



            if (Input.GetMouseButtonDown(0))
            {
                if (piezasEnTablero[hitPosition.x, hitPosition.y] != null)
                {
                    //es nuestro turno o no?
                    if (true)
                    {
                        piezaArrastrada = piezasEnTablero[hitPosition.x, hitPosition.y];


                        //consigue una lista de a donde se puede mover y cambia el color de las casillas
                        movimientosDisponibles = piezaArrastrada.GetMovimientosDisponibles(ref piezasEnTablero, Total_Casillas_X, Total_Casillas_Y);
                    }
                }
            }
            if (piezaArrastrada != null && Input.GetMouseButtonUp(0))
            {
                Vector2Int posicionAnterior = new Vector2Int(piezaArrastrada.xActual, piezaArrastrada.yActual);

                bool movimientoValido = MoverA(piezaArrastrada, hitPosition.x, hitPosition.y);
                if (!movimientoValido)
                {
                    piezaArrastrada.setPosition(CentroCasilla(posicionAnterior.x, posicionAnterior.y));
                    piezaArrastrada = null;

                }
                else
                {
                    piezaArrastrada = null;
                }
            }
            else
            {
                if (currentHover != -Vector2Int.one)
                {
                    casillas[currentHover.x, currentHover.y].layer = LayerMask.NameToLayer("Casilla");
                    currentHover = -Vector2Int.one;

                }

                if (piezaArrastrada && Input.GetMouseButtonUp(0))
                {
                    piezaArrastrada.setPosition(CentroCasilla(piezaArrastrada.xActual, piezaArrastrada.yActual));
                    piezaArrastrada = null;
                }
            }


        }
        else
        {

            Debug.Log("Hola!");
            if (currentHover != Vector2Int.one)
            {
                
                casillas[currentHover.x, currentHover.y].layer = LayerMask.NameToLayer("Casilla");

                currentHover = Vector2Int.one;
            }
        }
    }

    private bool MoverA(Pieza piezaAMover, int x, int y)
    {
        if (piezasEnTablero[x, y] != null) //Si hay pieza en donde pretendo mover...
        {
            Pieza piezaEnCasilla = piezasEnTablero[x,y]; //Obtén información de esa pieza

            if (piezaAMover.equipo == piezaEnCasilla.equipo) //Y si es de mi equipo. no puedo moverme.
            {
                return false;
            }
        }


        Vector2Int posicionAnterior = new Vector2Int(piezaAMover.xActual, piezaAMover.yActual);

        //Actualizo la posición de mi pieza a la coordenada x, y.
        piezasEnTablero[x, y] = piezaAMover;

        //Dejo mi posición en nulo.
        piezasEnTablero[posicionAnterior.x, posicionAnterior.y] = null;

        //la coloco en la nueva coordenada.
        ColocarUnaPieza(x, y);

        return true;
    }

    //Tablero
    private void GenerarTodasLasCasillas(float tamanioCasilla, int contadorCasillasX, int contadorCasillasY  )
    {

        yOffset += transform.position.y;
        bounds = new Vector3((contadorCasillasX / 2) * tamanioCasilla, 0, (contadorCasillasX / 2) * tamanioCasilla) + centroTablero;

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
        vertices[0] = new Vector3(x* tamanioCasilla, yOffset, y*tamanioCasilla) - bounds;
        vertices[1] = new Vector3(x* tamanioCasilla, yOffset, (y+1)*tamanioCasilla) - bounds;
        vertices[2] = new Vector3((x+1)* tamanioCasilla, yOffset, y*tamanioCasilla) - bounds;
        vertices[3] = new Vector3((x+1)* tamanioCasilla, yOffset, (y+1)*tamanioCasilla) - bounds;

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
    piezasEnTablero = new Pieza[Total_Casillas_X, Total_Casillas_Y];

    int equipoRosa = 0, equipoAzul = 1;

    //equipo rosa

    piezasEnTablero[0,0] = spwanearUnaSolaPieza(tipoPieza.torre, equipoRosa);
    piezasEnTablero[0, 11] = spwanearUnaSolaPieza(tipoPieza.caballero, equipoRosa);
    piezasEnTablero[0, 3] = spwanearUnaSolaPieza(tipoPieza.alfil, equipoRosa);
    piezasEnTablero[0, 9] = spwanearUnaSolaPieza(tipoPieza.alfil, equipoRosa);
    piezasEnTablero[0, 5] = spwanearUnaSolaPieza(tipoPieza.caballero, equipoRosa);
    piezasEnTablero[0, 7] = spwanearUnaSolaPieza(tipoPieza.caballero, equipoRosa);
    piezasEnTablero[0, 6] = spwanearUnaSolaPieza(tipoPieza.reina, equipoRosa);

    }
private Pieza spwanearUnaSolaPieza(tipoPieza tipo, int equipo)
{
    GameObject piezaGO = Instantiate(prefabs[(int)tipo -1], Vector3.zero, Quaternion.identity);
    piezaGO.transform.SetParent(transform);
    Pieza pieza = piezaGO.GetComponent<Pieza>();

    pieza.tipo = tipo;
    pieza.equipo = equipo;
    pieza.GetComponent<MeshRenderer>().material = materialesEquipos[equipo];

    return pieza;
}


//colocar piezas
private void ColocarTodasLasPiezas()
{
    for(int x = 0; x < Total_Casillas_X; x++)
    {
        for(int y = 0; y < Total_Casillas_Y; y++)
        {
            if(piezasEnTablero[x,y] != null)
            {
                ColocarUnaPieza(x, y, true);
            }
        }
    }
}

private Vector3 CentroCasilla(int x, int y)
    {
        return new Vector3(x* tamanioCasilla, yOffset, y * tamanioCasilla)-bounds + new Vector3(tamanioCasilla/2,0, tamanioCasilla /2);
    }

private void ColocarUnaPieza(int x, int y, bool force = false)
{
    piezasEnTablero[x,y].xActual = x;
    piezasEnTablero[x,y].yActual = y;
    piezasEnTablero[x, y].setPosition(CentroCasilla(x, y), force);
}

}

//VIDEO 3/5 ELIMINAR PIEZAS MUERTAS IGNORADO REVISAR MAS ADELANTE 