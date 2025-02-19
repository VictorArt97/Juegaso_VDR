
using System.Collections.Generic;
using UnityEngine;

public class Peon : Pieza
{
    public override List<Vector2Int> GetMovimientosDisponibles(ref Pieza[,] tablero, int cuentaCasillasX, int cuentaCasillasY)
    {

        List<Vector2Int> r = new List<Vector2Int>();

        if(xActual +1 < cuentaCasillasX)
        {
            if (tablero[xActual + 1, yActual] == null)
            {
                r.Add(new Vector2Int(xActual +1, yActual));
            }
            else if(tablero[xActual + 1, yActual].equipo != equipo)
            {
                r.Add(new Vector2Int(xActual + 1, yActual));
            }

            if(yActual +1 < cuentaCasillasY)
            {
                if (tablero[xActual + 1, yActual +1] == null)
                {
                    r.Add(new Vector2Int(xActual + 1, yActual + 1));
                }
                else if (tablero[xActual + 1, yActual + 1].equipo != equipo)
                {
                    r.Add(new Vector2Int(xActual + 1, yActual + 1));
                }
            }
            if (yActual -1 < cuentaCasillasY)
            {
                if (tablero[xActual + 1, yActual -1] == null)
                {
                    r.Add(new Vector2Int(xActual + 1, yActual - 1));
                }
                else if (tablero[xActual + 1, yActual - 1].equipo != equipo)
                {
                    r.Add(new Vector2Int(xActual + 1, yActual - 1));
                }
            }
        }
        if (xActual - 1 >= 0)
        {
            if (tablero[xActual - 1, yActual] == null)
            {
                r.Add(new Vector2Int(xActual - 1, yActual));
            }
            else if (tablero[xActual - 1, yActual].equipo != equipo)
            {
                r.Add(new Vector2Int(xActual - 1, yActual));
            }

            if (yActual - 1 < cuentaCasillasY)
            {
                if (tablero[xActual - 1, yActual + 1] == null)
                {
                    r.Add(new Vector2Int(xActual - 1, yActual + 1));
                }
                else if (tablero[xActual - 1, yActual + 1].equipo != equipo)
                {
                    r.Add(new Vector2Int(xActual - 1, yActual + 1));
                }
            }
            if (yActual - 1 < cuentaCasillasY)
            {
                if (tablero[xActual - 1, yActual - 1] == null)
                {
                    r.Add(new Vector2Int(xActual - 1, yActual - 1));
                }
                else if (tablero[xActual - 1, yActual - 1].equipo != equipo)
                {
                    r.Add(new Vector2Int(xActual - 1, yActual - 1));
                }
            }
        }

      //  if(yActual +1 < cuentaCasillasY)
      //  {
      //      if (tablero[xActual, yActual + 1] == null || tablero[xActual, yActual +1].equipo != equipo)
      //      {
      //          r.Add(new Vector2Int(xActual, yActual + 1));
       //     }

       // }
        //if (yActual - 1 >= 0)
       // {
       //     if (tablero[xActual, yActual - 1] == null || tablero[xActual, yActual - 1].equipo != equipo)
        //    {
       //         r.Add(new Vector2Int(xActual, yActual - 1));
       //     }

       // }


        return r;
       
    }
}
