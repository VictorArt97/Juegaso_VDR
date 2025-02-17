
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Alfil : Pieza
{
     public override List<Vector2Int> GetMovimientosDisponibles(ref Pieza[,] tablero, int cuentaCasillasX, int cuentaCasillasY)
    {
        List<Vector2Int> r = new List<Vector2Int>();

        for(int x = xActual +1, y = yActual + 1; x < cuentaCasillasX && y < cuentaCasillasY; x++, y++)
        {
           if(tablero[x,y] == null)
           {
            r.Add(new Vector2Int(x,y));
           } 
           else
            {
                if(tablero[x,y].equipo != equipo)
                {
                    r.Add(new Vector2Int(x,y));
                }
                break;
            }
        }

        for(int x = xActual - 1, y = yActual + 1; x >= 0 && y < cuentaCasillasY; x--, y++)
        {
           if(tablero[x,y] == null)
           {
            r.Add(new Vector2Int(x,y));
           } 
           else
            {
                if(tablero[x,y].equipo != equipo)
                {
                    r.Add(new Vector2Int(x,y));
                }
                break;
            }
        }

        for(int x = xActual + 1, y = yActual - 1; x < cuentaCasillasX && y >= 0 ; x++, y--)
        {
           if(tablero[x,y] == null)
           {
            r.Add(new Vector2Int(x,y));
           } 
           else
            {
                if(tablero[x,y].equipo != equipo)
                {
                    r.Add(new Vector2Int(x,y));
                }
                break;
            }
        }

        for(int x = xActual - 1, y = yActual - 1; x >= 0  && y >= 0 ; x--, y--)
        {
           if(tablero[x,y] == null)
           {
            r.Add(new Vector2Int(x,y));
           } 
           else
            {
                if(tablero[x,y].equipo != equipo)
                {
                    r.Add(new Vector2Int(x,y));
                }
                break;
            }
        }

        return r;
    }
}
