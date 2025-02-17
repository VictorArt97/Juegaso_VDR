
using System.Collections.Generic;
using UnityEngine;

public enum tipoPieza
{
    ninguna = 0,
    peonRosa = 1,
    torreRosa = 2,
    caballeroRosa = 3,
    alfilRosa = 4,
    reinaRosa = 5,
    
    
    peonAzul = 1,
    torreAzul =2,
    caballeroAzul =3,
    alfilAzul=4,
    reinaAzul=5,
}

public class Pieza : MonoBehaviour
{
    public int equipo;
    public tipoPieza tipo;
    public int xActual;
    public int yActual;

    private Vector3 posicionDeseada;
    private Vector3 desiredScale = Vector3.one ;

    [SerializeField]
    private MeshRenderer[] partesPrincipales;

    [SerializeField]
    private MeshRenderer[] partesSecundarias;

    [SerializeField]
    private DatosPersonaje datos;



    public MeshRenderer[] PartesPrincipales { get => partesPrincipales;  }
    public MeshRenderer[] PartesSecundarias { get => partesSecundarias; }
    public DatosPersonaje Datos { get => datos; }

    private void Update()
    {
       transform.position = Vector3.Lerp(transform.position, posicionDeseada, Time.deltaTime * 10);
       transform.localScale = Vector3.Lerp(transform.localScale, desiredScale, Time.deltaTime * 10);
    }

    public virtual List<Vector2Int> GetMovimientosDisponibles(ref Pieza[,] tablero, int cuentaCasillasX, int cuentaCasillasY)
    {
        List<Vector2Int> r = new List<Vector2Int>();
        r.Add(new Vector2Int(3,3));
        r.Add(new Vector2Int(3,4));
        r.Add(new Vector2Int(4,3));
        r.Add(new Vector2Int(4,4));
        return r;
    }


    public virtual void setPosition(Vector3 posicion, bool force = false)
    {
        posicionDeseada = posicion;
        if (force)
        {
            transform.position = posicionDeseada;
        }

    }


    public virtual void setEscala(Vector3 escala, bool force = false)
    {
        desiredScale = escala;
        if (force)
        {
            transform.localScale = desiredScale;
        }

    }
}
   
