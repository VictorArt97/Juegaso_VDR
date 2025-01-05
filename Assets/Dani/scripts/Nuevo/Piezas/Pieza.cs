
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
    private Vector3 desiredScale;
} 
