
using System.Collections.Generic;
using UnityEngine;

public class Torre : Pieza
{
    public override List<Vector2Int> GetMovimientosDisponibles(ref Pieza[,] tablero, int cuentaCasillasX, int cuentaCasillasY)
    {
        List<Vector2Int> r = new List<Vector2Int>();

        for(int i = yActual - 1; i >= 0; i--)
        {
            if(tablero[xActual, i] == null)
            {
                r.Add(new Vector2Int(xActual, i));
            }
            if(tablero[xActual, i] != null)
            {
                if(tablero[xActual, i].equipo != equipo)
                {
                    r.Add(new Vector2Int(xActual, i));
                
                }
                break;

            }

        }

         for(int i = yActual + 1; i < cuentaCasillasY; i++)
        {
            if(tablero[xActual, i] == null)
            {
                r.Add(new Vector2Int(xActual, i));
            }
            if(tablero[xActual, i] != null)
            {
                if(tablero[xActual, i].equipo != equipo)
                {
                    r.Add(new Vector2Int(xActual, i));
                
                }
                break;

            }

        }
        for(int i = xActual - 1; i >= 0; i--)
        {
            if(tablero[i, yActual] == null)
            {
                r.Add(new Vector2Int(i, yActual));
            }
            if(tablero[i, yActual] != null)
            {
                if(tablero[i, yActual].equipo != equipo)
                {
                    r.Add(new Vector2Int(i, yActual));
                
                }
                break;

            }

        }
        for(int i = xActual + 1; i < cuentaCasillasX; i++)
        {
            if(tablero[i, yActual] == null)
            {
                r.Add(new Vector2Int(i, yActual));
            }
            if(tablero[i, yActual] != null)
            {
                if(tablero[i, yActual].equipo != equipo)
                {
                    r.Add(new Vector2Int(i, yActual));
                
                }
                break;

            }

        }

        return r;
    }
}
