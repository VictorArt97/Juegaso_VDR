
using System.Collections.Generic;
using UnityEngine;

public class Peon : Pieza
{
    public override List<Vector2Int> GetMovimientosDisponibles(ref Pieza[,] tablero, int cuentaCasillasX, int cuentaCasillasY)
    {
        List<Vector2Int> r = new List<Vector2Int>();

        int direccion = (equipo == 0) ? 1 : -1;

        // uno al frente

        if (tablero[xActual, yActual + direccion] == null)
            r.Add(new Vector2Int(xActual, yActual + direccion));

        //dos al frente
        //if (tablero[xActual, yActual + direccion] == null)
        //{
       //     if (equipo == 0 && yActual == 1 && tablero[xActual, yActual + (direccion * 2)] == null)
        //    {
       //         r.Add(new Vector2Int(xActual, yActual + (direccion * 2)));
        //    }
        //    if (equipo == 1 && yActual == 6 && tablero[xActual, yActual + (direccion * 2)] == null)
        //    {
        //        r.Add(new Vector2Int(xActual, yActual + (direccion * 2)));
        //    }


            return r;
        }
    }
}
