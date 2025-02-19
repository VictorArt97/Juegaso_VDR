using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Tilemaps;
using UnityEngine.UIElements;

public class Tablero : MonoBehaviour
{
    [SerializeField] private GameObject virtualCameraEquipoRosa;
    [SerializeField] private  GameObject virtualCameraEquipoAzul;
    [SerializeField] private GameObject zoomRosa;
    [SerializeField] private  GameObject zoomAzul;

    private bool zoom = false;



    private Pieza[,] piezasEnTablero;
    private Renderer rend;

    private List<Pieza> rosasMuertos = new List<Pieza>();
    private List<Pieza> azulesMuertos = new List<Pieza>();
    [SerializeField] private float tamanioMuerto;
    [SerializeField] private float espacioMuertas;

    [SerializeField] private Material materialCasilla;
    [SerializeField] private Material materialSeleccion;
    [SerializeField] private Material materialIluminacion;


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


    private bool esTurnoRosa;



    private Pieza piezaArrastrada;
    private Pieza ultimaPiezaSeleccionada;

    public static Tablero instance;

    public Pieza UltimaPiezaSeleccionada { get => ultimaPiezaSeleccionada; }

    private void Awake()
    {
        esTurnoRosa = true;

        if(instance == null)
        {
            instance = this;
        }
        else if(instance != this)
        {
            Destroy(gameObject);
        }

        GenerarTodasLasCasillas(tamanioCasilla, Total_Casillas_X, Total_Casillas_Y);

        //RECORDAR COMENTAR LA SIGUIENTE LINEA

        //spwanearUnaSolaPieza(tipoPieza.peon, 0);


        spawnearTodasLasPiezas(UnityEngine.Random.Range(0, 2));

        ColocarTodasLasPiezas();

    }
    private void Update()
    {
        if(Input.GetMouseButtonDown(1) && zoom == false)
        {
            zoom = true;
        }
          if(Input.GetMouseButtonDown(1) && zoom == true)
        {
            zoom = false;
        }
    


        if (!camaraActual)
        {
            camaraActual = Camera.main;
            return;
        }
        if(esTurnoRosa == true)
        {
            if(zoom == false)
            {
                virtualCameraEquipoRosa.SetActive(true);
                virtualCameraEquipoAzul.SetActive(false);
                zoomAzul.SetActive(false);
                zoomRosa.SetActive(false);
            }
            if(zoom == true)
            {
                virtualCameraEquipoRosa.SetActive(false);
                virtualCameraEquipoAzul.SetActive(false);
                zoomAzul.SetActive(false);
                zoomRosa.SetActive(true);
            }

          
        }
        if(esTurnoRosa == false)
        {
             if(zoom == false)
            {
                virtualCameraEquipoRosa.SetActive(false);
                virtualCameraEquipoAzul.SetActive(true);
                zoomAzul.SetActive(false);
                zoomRosa.SetActive(false);
            }
            if(zoom == true)
            {
                virtualCameraEquipoRosa.SetActive(false);
                virtualCameraEquipoAzul.SetActive(false);
                zoomAzul.SetActive(true);
                zoomRosa.SetActive(false);
            }
        }




        RaycastHit info;
        Ray ray = camaraActual.ScreenPointToRay(Input.mousePosition);
        if (Physics.Raycast(ray, out info, 100, LayerMask.GetMask("Casilla", "Hover", "Iluminado")))
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
            if (currentHover != hitPosition)
            {
                casillas[currentHover.x, currentHover.y].GetComponent<Renderer>().material = materialCasilla;
                casillas[currentHover.x, currentHover.y].layer = (contieneUnMovimientoValido(ref movimientosDisponibles, currentHover)) ? LayerMask.NameToLayer("Iluminado") : LayerMask.NameToLayer("Casilla");

                currentHover = hitPosition;

                casillas[hitPosition.x, hitPosition.y].layer = LayerMask.NameToLayer("Hover");
                casillas[hitPosition.x, hitPosition.y].GetComponent<Renderer>().material = materialSeleccion;

            }



            if (Input.GetMouseButtonDown(0))
            {
                if (piezasEnTablero[hitPosition.x, hitPosition.y] != null)
                {
                    //es nuestro turno o no?
                    if ((piezasEnTablero[hitPosition.x, hitPosition.y].equipo == 0 && esTurnoRosa) || (piezasEnTablero[hitPosition.x, hitPosition.y].equipo == 1 && !esTurnoRosa))
                    {
                        piezaArrastrada = piezasEnTablero[hitPosition.x, hitPosition.y];


                        //consigue una lista de a donde se puede mover y cambia el color de las casillas
                        movimientosDisponibles = piezaArrastrada.GetMovimientosDisponibles(ref piezasEnTablero, Total_Casillas_X, Total_Casillas_Y);
                        iluminarCasillas();
                        if(esTurnoRosa == true)
                        {
                            virtualCameraEquipoRosa.SetActive(false);
                            virtualCameraEquipoAzul.SetActive(false);
                            zoomAzul.SetActive(false);
                            zoomRosa.SetActive(true);
                        }
                           if(esTurnoRosa == false)
                        {
                            virtualCameraEquipoRosa.SetActive(false);
                            virtualCameraEquipoAzul.SetActive(false);
                            zoomAzul.SetActive(true);
                            zoomRosa.SetActive(false);
                        }

                    }
                }
            }
            if (piezaArrastrada != null && Input.GetMouseButtonUp(0))
            {
               
                ultimaPiezaSeleccionada = piezaArrastrada;


                Vector2Int posicionAnterior = new Vector2Int(piezaArrastrada.xActual, piezaArrastrada.yActual);

                bool movimientoValido = MoverA(piezaArrastrada, hitPosition.x, hitPosition.y);
                if (!movimientoValido)
                {
                    piezaArrastrada.setPosition(CentroCasilla(posicionAnterior.x, posicionAnterior.y));
                    piezaArrastrada = null;

                }
                piezaArrastrada = null;
                QutarIluminarCasillas();
            }
            else
            {
              //  if (currentHover != -Vector2Int.one)
                //{
                 //   casillas[currentHover.x, currentHover.y].layer = (contieneUnMovimientoValido(ref movimientosDisponibles, currentHover))? LayerMask.NameToLayer("Iluminado") : LayerMask.NameToLayer("Casilla");
                  //  currentHover = -Vector2Int.one;

                //}

                if (piezaArrastrada && Input.GetMouseButtonUp(0))
                {
                    piezaArrastrada.setPosition(CentroCasilla(piezaArrastrada.xActual, piezaArrastrada.yActual));
                    piezaArrastrada = null;
                    QutarIluminarCasillas();
                }
            }


        }
        else
        {

            //Debug.Log("Hola!");
            //if (currentHover != Vector2Int.one)
            //{

            //    casillas[currentHover.x, currentHover.y].layer = LayerMask.NameToLayer("Casilla");

            //    currentHover = Vector2Int.one;
            //}
        }
    }

    private void iluminarCasillas()
    {
        for (int i = 0; i < movimientosDisponibles.Count; i++)
        {
            casillas[movimientosDisponibles[i].x, movimientosDisponibles[i].y].layer = LayerMask.NameToLayer("Iluminado");
            casillas[movimientosDisponibles[i].x, movimientosDisponibles[i].y].GetComponent<Renderer>().material = materialIluminacion;
            //movimientosDisponibles.Clear();
        }
    }
    private void QutarIluminarCasillas()
    {
        for (int i = 0; i < movimientosDisponibles.Count; i++)
        {
            casillas[movimientosDisponibles[i].x, movimientosDisponibles[i].y].layer = LayerMask.NameToLayer("Casilla");
            casillas[movimientosDisponibles[i].x, movimientosDisponibles[i].y].GetComponent<Renderer>().material = materialCasilla;
        }
    }

    private bool MoverA(Pieza piezaAMover, int x, int y)
    {
        if(!contieneUnMovimientoValido(ref movimientosDisponibles, new Vector2(x, y)))
        { 
            return false;
        }

        if (piezasEnTablero[x, y] != null) //Si hay pieza en donde pretendo mover...
        {
            Pieza piezaEnCasilla = piezasEnTablero[x, y]; //Obt�n informaci�n de esa pieza

            if (piezaAMover.equipo == piezaEnCasilla.equipo) //Y si es de mi equipo. no puedo moverme.
            {
                return false;
            }
            //que pasa cuando mueren las piezas
            if(piezaEnCasilla.equipo == 0)
            {
                if(piezaEnCasilla.tipo == tipoPieza.reinaAzul)
                {
                    CambiarEscenaRosa();
                }
                rosasMuertos.Add(piezaEnCasilla);
                piezaEnCasilla.setEscala(Vector3.one * tamanioCasilla);
                piezaEnCasilla.setPosition(new Vector3(80 * tamanioCasilla, yOffset, -80 * tamanioCasilla) - bounds + new Vector3(tamanioCasilla / 2, 0, tamanioCasilla / 2) + (Vector3.forward * espacioMuertas) * rosasMuertos.Count);

            }
            else
            {
                if (piezaEnCasilla.tipo == tipoPieza.reinaRosa)
                {
                    CambiarEscenaAzul();
                }
                azulesMuertos.Add(piezaEnCasilla);
                piezaEnCasilla.setEscala(Vector3.one * tamanioCasilla);
                piezaEnCasilla.setPosition(new Vector3(-80 * tamanioCasilla, yOffset, 80 * tamanioCasilla) - bounds + new Vector3(tamanioCasilla / 2, 0, tamanioCasilla / 2) + (Vector3.back * espacioMuertas) * rosasMuertos.Count);
            }
           
        }


        Vector2Int posicionAnterior = new Vector2Int(piezaAMover.xActual, piezaAMover.yActual);

        //Actualizo la posici�n de mi pieza a la coordenada x, y.
        piezasEnTablero[x, y] = piezaAMover;

        //Dejo mi posici�n en nulo.
        piezasEnTablero[posicionAnterior.x, posicionAnterior.y] = null;

        //la coloco en la nueva coordenada.
        ColocarUnaPieza(x, y);

        esTurnoRosa = !esTurnoRosa;

        return true;
    }

    //Tablero
    private void GenerarTodasLasCasillas(float tamanioCasilla, int contadorCasillasX, int contadorCasillasY)
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
        vertices[0] = new Vector3(x * tamanioCasilla, yOffset, y * tamanioCasilla) - bounds;
        vertices[1] = new Vector3(x * tamanioCasilla, yOffset, (y + 1) * tamanioCasilla) - bounds;
        vertices[2] = new Vector3((x + 1) * tamanioCasilla, yOffset, y * tamanioCasilla) - bounds;
        vertices[3] = new Vector3((x + 1) * tamanioCasilla, yOffset, (y + 1) * tamanioCasilla) - bounds;

        int[] tris = new int[] { 0, 1, 2, 1, 3, 2 };

        mesh.vertices = vertices;
        mesh.triangles = tris;

        objetoCasilla.layer = LayerMask.NameToLayer("Casilla");
        mesh.RecalculateNormals();
        objetoCasilla.AddComponent<BoxCollider>();

        return objetoCasilla;

    }

    private Vector2Int MirarInformacionCasilla(GameObject hitInfo)
    {
        for (int x = 0; x < Total_Casillas_X; x++)
        {
            for (int y = 0; y < Total_Casillas_Y; y++)
            {
                if (casillas[x, y] == hitInfo)
                {
                    return new Vector2Int(x, y);
                }
            }
        }
        return -Vector2Int.one; //invalido
    }


    //Spawnear Piezas

    private void spawnearTodasLasPiezas(int equipo)
    {
        piezasEnTablero = new Pieza[Total_Casillas_X, Total_Casillas_Y];

        int equipoRosa = 0, equipoAzul = 1;




        piezasEnTablero[0, 5] = SpwanearUnaSolaPieza(tipoPieza.peonRosa, equipoRosa);
        piezasEnTablero[0, 6] = SpwanearUnaSolaPieza(tipoPieza.alfilRosa, equipoRosa);
        piezasEnTablero[0, 8] = SpwanearUnaSolaPieza(tipoPieza.peonRosa, equipoRosa);
        piezasEnTablero[0, 9] = SpwanearUnaSolaPieza(tipoPieza.alfilRosa, equipoRosa);
        piezasEnTablero[2, 1] = SpwanearUnaSolaPieza(tipoPieza.peonRosa, equipoRosa);
        piezasEnTablero[2, 10] = SpwanearUnaSolaPieza(tipoPieza.reinaRosa, equipoRosa);
        piezasEnTablero[2, 6] = SpwanearUnaSolaPieza(tipoPieza.peonRosa, equipoRosa);
        piezasEnTablero[3, 3] = SpwanearUnaSolaPieza(tipoPieza.peonRosa, equipoRosa);
        piezasEnTablero[3, 5] = SpwanearUnaSolaPieza(tipoPieza.peonRosa, equipoRosa);
        piezasEnTablero[3, 6] = SpwanearUnaSolaPieza(tipoPieza.caballeroRosa, equipoRosa);
        piezasEnTablero[3, 7] = SpwanearUnaSolaPieza(tipoPieza.peonRosa, equipoRosa);
        piezasEnTablero[3, 9] = SpwanearUnaSolaPieza(tipoPieza.peonRosa, equipoRosa);
        piezasEnTablero[4, 0] = SpwanearUnaSolaPieza(tipoPieza.torreRosa, equipoRosa);
        piezasEnTablero[4, 11] = SpwanearUnaSolaPieza(tipoPieza.torreRosa, equipoRosa);

        piezasEnTablero[11, 11] = SpwanearUnaSolaPieza(tipoPieza.reinaAzul, equipoAzul);
        piezasEnTablero[11, 6] = SpwanearUnaSolaPieza(tipoPieza.alfilAzul, equipoAzul);
        piezasEnTablero[10, 1] = SpwanearUnaSolaPieza(tipoPieza.alfilAzul, equipoAzul);
        piezasEnTablero[10, 2] = SpwanearUnaSolaPieza(tipoPieza.peonAzul, equipoAzul);
        piezasEnTablero[10, 5] = SpwanearUnaSolaPieza(tipoPieza.caballeroAzul, equipoAzul);
        piezasEnTablero[10, 6] = SpwanearUnaSolaPieza(tipoPieza.peonAzul, equipoAzul);
        piezasEnTablero[10, 7] = SpwanearUnaSolaPieza(tipoPieza.caballeroAzul, equipoAzul);
        piezasEnTablero[9, 1] = SpwanearUnaSolaPieza(tipoPieza.peonAzul, equipoAzul);
        piezasEnTablero[9, 11] = SpwanearUnaSolaPieza(tipoPieza.torreAzul, equipoAzul);
        piezasEnTablero[8, 2] = SpwanearUnaSolaPieza(tipoPieza.torreAzul, equipoAzul);
        piezasEnTablero[8, 5] = SpwanearUnaSolaPieza(tipoPieza.peonAzul, equipoAzul);
        piezasEnTablero[8, 7] = SpwanearUnaSolaPieza(tipoPieza.peonAzul, equipoAzul);
        piezasEnTablero[8, 10] = SpwanearUnaSolaPieza(tipoPieza.peonAzul, equipoAzul);

    }
    private Pieza SpwanearUnaSolaPieza(tipoPieza tipo, int equipo)
    {
        GameObject piezaGO = Instantiate(prefabs[(int)tipo - 1], Vector3.zero, Quaternion.identity);
        piezaGO.transform.SetParent(transform);
        Pieza pieza = piezaGO.GetComponent<Pieza>();

        pieza.tipo = tipo;
        pieza.equipo = equipo;
        
       
       

        return pieza;
    }


    //colocar piezas
    private void ColocarTodasLasPiezas()
    {
        for (int x = 0; x < Total_Casillas_X; x++)
        {
            for (int y = 0; y < Total_Casillas_Y; y++)
            {
                if (piezasEnTablero[x, y] != null)
                {
                    ColocarUnaPieza(x, y, true);
                }
            }
        }
    }

    private Vector3 CentroCasilla(int x, int y)
    {
        return new Vector3(x * tamanioCasilla, yOffset, y * tamanioCasilla) - bounds + new Vector3(tamanioCasilla / 2, 0, tamanioCasilla / 2);
    }

    private void ColocarUnaPieza(int x, int y, bool force = false)
    {
        piezasEnTablero[x, y].xActual = x;
        piezasEnTablero[x, y].yActual = y;
        piezasEnTablero[x, y].setPosition(CentroCasilla(x, y), force);
    }



    private bool contieneUnMovimientoValido(ref List<Vector2Int> movimientos, Vector2 pos)
    {
        for (int i = 0; i < movimientos.Count; i++)
        {
            if (movimientos[i].x == pos.x && movimientos[i].y == pos.y)
            {
                return true;
            }
        }
        return false;

    }

    private void CambiarEscenaRosa()
    {
        SceneManager.LoadScene(4);
    }
    private void CambiarEscenaAzul()
    {
        SceneManager.LoadScene(3);
    }
}

//VIDEO 3/5 ELIMINAR PIEZAS MUERTAS IGNORADO REVISAR MAS ADELANTE 