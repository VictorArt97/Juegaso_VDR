
using System.Collections.Generic;
using UnityEngine;

public class Reina : Pieza
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
