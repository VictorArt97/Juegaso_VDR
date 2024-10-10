using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Layout Tablero")]
public class Layout_Tablero : MonoBehaviour
{
    [Serializable]
    private class SetupTablero
    {
        public Vector2Int posicion;
        public Tipo tipoPieza;
        public Equipo colorEquipo;
    }
    [SerializeField] private SetupTablero[] cuadrantesTablero;
    public int obtenerContadorPiezas()
    {
        return cuadrantesTablero.Length;
    }
    public Vector2Int obtenerCoordenadasCuadrante(int index)
    {
        if(cuadrantesTablero.Length <= index)
        {
            Debug.LogError("Index fuera de limites");
            return new Vector2Int(-1, -1);
        }
        return new Vector2Int(cuadrantesTablero [index].posicion.x -1, cuadrantesTablero[index].posicion.y -1);
    }
    public string obtenerTipoPieza(int index)
    {
        if (cuadrantesTablero.Length <= index)
        {
            Debug.LogError("Index fuera de limites");
            return "";
        }
        return cuadrantesTablero [index].tipoPieza.ToString();
    }
    public Equipo obtenerColorEquipo(int index) 
    {
        if (cuadrantesTablero.Length <= index)
        {
            Debug.LogError("Index fuera de limites");
            return Equipo.negro;
        }
        return cuadrantesTablero[index].colorEquipo;
    }
}
