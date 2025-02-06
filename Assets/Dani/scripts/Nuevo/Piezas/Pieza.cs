
using System.Collections.Generic;
using UnityEngine;

public enum tipoPieza
{
    ninguna = 0,
    peon = 1,
    torre =2,
    caballero =3,
    alfil=4,
    reina=5,
}

public class Pieza : MonoBehaviour
{
    public int equipo;
    public tipoPieza tipo;
    public int xActual;
    public int yActual;

    private Vector3 posicionDeseada;
    private Vector3 desiredScale = Vector3.one ;


    private void Update()
    {
       transform.position = Vector3.Lerp(transform.position, posicionDeseada, Time.deltaTime * 10);
       transform.localScale = Vector3.Lerp(transform.localScale, desiredScale, Time.deltaTime * 10);
    }

    public List<Vector2Int> GetMovimientosDisponibles(ref Pieza[,] tablero, int cuentaCasillasX, int cuentaCasillasY)
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
   
