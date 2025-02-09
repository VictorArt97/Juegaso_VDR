using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

[System.Serializable]
    public struct Accion // para hacer las diferentes acciones ya sea moverse o atacar
    {
        public string nombre;  // nombre de la accion
        public bool estatico;  //  si se mueve o no
        public bool objetivoSoyYoMismo;

        public string mensaje;   // indica que es lo que ha ocurrido
        public int argumento;    //  cantidad de lo que haga ya sea aumentar la defensa o el daño que le hago a alguien 
        public string animationTrigger;


        public int costoAccion;    // como solo posees 3 acciones , depende de lo que hagas se consumira mas o menos 

    }
public class Combate : MonoBehaviour
{
    private List<Accion> Acciones;   // opciones que tendra cada personaje 
    [SerializeField] private string nombreDelPersonaje;
    [SerializeField] DatosPersonaje datosDelPersonaje;

    public Animator animator;   // se ejecutara una animacion por cada accion que haga


    void Start()
    {
        animator= GetComponent<Animator>();

    }

    //public IEnumerator EjecutarAccion(Accion accion, Transform objetivo)
    //{
        
    //    if (accion.objetivoSoyYoMismo)  //  si el objetivo soy yo mismo ( chetarme )
    //    {
    //        objetivo = transform;
    //    }
    //    if(accion.estatico)   // no me muevo 
    //    {
    //        animator.SetTrigger(accion.animationTrigger);     // activa la animacion
    //        objetivo.SendMessage(accion.mensaje,accion.argumento);  
    //    }
    //    else   //  si la accion NO ES ESTATICA...
    //    {
    //        Vector3 PosInicial = transform.position;   // se guarda una posicion inicial 


    //    }
    //}
    
    void Update()
    {
        
    }
    private void RecibirDanio(float cantidadDanio)   
    {
        float nuevaCantidadDanio;                 // cantidad de danio para despues de la recuccion de daño
        nuevaCantidadDanio = cantidadDanio;                        // le doy valor con la cantidad de danio original
        nuevaCantidadDanio -= datosDelPersonaje.defensa;          // al ataque que me va a hacer le resto la defensa, reduciendo el daño 

        datosDelPersonaje.defensa -= cantidadDanio;             // se gasta la defensa , reduciendole el propio daño orginal que me iba a hacer         
        datosDelPersonaje.vida-=nuevaCantidadDanio;            //  me hacen el daño ya reducido
    }
}
