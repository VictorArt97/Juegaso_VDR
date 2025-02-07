using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "NuevosDatosPersonaje", menuName = "DatosPersonaje")]
public class DatosPersonaje : ScriptableObject  
{
    public float vida;
    public float vidaMaxima;
    
    public float defensa;
    public float defensaMaxima;
    public bool vivo;
    
    public float danio;

    public float barraUlti ;                   
    public float maxBarraUlti;             
}
