
//using System;
using System.Collections.Generic;
using UnityEngine;


public class Caballero : Pieza
{
 public override List<Vector2Int> GetMovimientosDisponibles(ref Pieza[,] tablero, int cuentaCasillasX, int cuentaCasillasY)
    {
        List<Vector2Int> r = new List<Vector2Int>();

        int x = xActual + 1;
        int y = yActual + 2;

        if(x < cuentaCasillasX && y < cuentaCasillasY)
        {
            if(tablero[x,y] == null || tablero[x,y].equipo != equipo)
            {
                r.Add(new Vector2Int(x,y));
            }
        }

        x = xActual + 2;
        y = yActual + 1;

        if(x < cuentaCasillasX && y < cuentaCasillasY)
        {
            if(tablero[x,y] == null || tablero[x,y].equipo != equipo)
            {
                r.Add(new Vector2Int(x,y));
            }
        }

        x = xActual - 1;
        y = yActual + 2;

        if(x >= 0 && y < cuentaCasillasY)
        {
            if(tablero[x,y] == null || tablero[x,y].equipo != equipo)
            {
                r.Add(new Vector2Int(x,y));
            }
        }

        x = xActual - 2;
        y = yActual + 1;

        if(x >= 0 && y < cuentaCasillasY)
        {
            if(tablero[x,y] == null || tablero[x,y].equipo != equipo)
            {
                r.Add(new Vector2Int(x,y));
            }
        }

        x = xActual + 1;
        y = yActual - 2;

        if(x < cuentaCasillasX && y >= 0 )
        {
            if(tablero[x,y] == null || tablero[x,y].equipo != equipo)
            {
                r.Add(new Vector2Int(x,y));
            }
        }

        x = xActual + 2;
        y = yActual - 1;

        if(x < cuentaCasillasX && y >= 0 )
        {
            if(tablero[x,y] == null || tablero[x,y].equipo != equipo)
            {
                r.Add(new Vector2Int(x,y));
            }
        }

        x = xActual - 1;
        y = yActual - 2;

        if(x >= 0 && y >= 0 )
        {
            if(tablero[x,y] == null || tablero[x,y].equipo != equipo)
            {
                r.Add(new Vector2Int(x,y));
            }
        }

          x = xActual - 2;
        y = yActual - 1;

        if(x >= 0 && y >= 0 )
        {
            if(tablero[x,y] == null || tablero[x,y].equipo != equipo)
            {
                r.Add(new Vector2Int(x,y));
            }
        }



        return r;
    }
}
