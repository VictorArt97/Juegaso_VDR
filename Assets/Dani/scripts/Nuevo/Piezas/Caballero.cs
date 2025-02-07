
using System;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Caballero : Pieza
{


    [SerializeField] DatosPersonaje caballero;
    public int accionesDisponibles = 3;            // Ejemplo de barra de acciones
    public float barraUlti = 0;                   // Barra de ultimate
    public float maxBarraUlti = 100;             // Máximo de la barra de ultimate

    [SerializeField] Animator animator;

    private void OnEnable()
    {
        animator = GetComponent<Animator>();
    }
    
    
    // Para comprobar cuantas acciones me quedan 
    public void Update()
    {
        Debug.Log("Acciones :" + accionesDisponibles);
        if (caballero.vida > caballero.vidaMaxima) caballero.vida=caballero.vidaMaxima;     // evitar que su vida sobrepase su vida maxima 
    }



    // Este metodo se lo meto al boton para que active la habilidad 1 del caballero 
    public void BotonHabilidad1()
    {
        //HabilidadAtaque();
    }


    /// metodo que representa la habilidad 1 del caballero
    public void Habilidad_1(Vector2Int posicionAtaque, GameObject enemigo)   // ataque a mele en un rango de 1x1
    {
        /// Comprobar acciones disponibles
        if ( accionesDisponibles > 0)
        {

            /// Seleccionar a quien atacar en el área de ataque (1x1)
            

            /// Reducir acciones
            accionesDisponibles -= 1; 

            /// Activar animación de ataque y recibir daño
            AnimacionAtaque();
           // enemigo.GetComponent<Enemigo>().RecibirDaño();  // daño al enemigo


            /// Cargar barra de ultimate
            
            barraUlti += 15; // Ejemplo de carga
            if (barraUlti > maxBarraUlti) barraUlti = maxBarraUlti;  // para evitar 

            /// Comprobar si el enemigo ha muerto
           // if (enemigo.GetComponent<Enemigo>().)   // comprueba que el enemigo esta muerto
          //  {
            //    OcuparCasilla();    // ocupa la casilla del enemigo que acaba de matar
           // }
            else
            {
                return; // basicamente no se mueve (Solo en caso de que sea un ataque fisico)
            }
        }
        else if (accionesDisponibles < 1)
        {
            Debug.Log("No tienes acciones suficientes.");
            return;
        }
    }
    private void Ulti()
    {
        if (barraUlti==maxBarraUlti)
        {

        }
        else
        {
            Debug.Log("No puedes usar esta habilidad todavia");
        }
    }
 
    private void recibirDanio()
    {

    }
    private void OcuparCasilla()  
    {
        
    }
    private void AnimacionAtaque()  //el personaje se gira a mirar al enemigo y activa la animacion 
    {
       
    }

   
    
    
    
   // --------------------------/// APUNTES ///-------------------------------//



    // preguntas para fernando : como puedo hacer para que se distinga al enemigo del jugador de la forma mas facil y acceda a sus datos





    // lograr comunicar el personaje con el tablero para saber info de posciones y demas 
    




    /// Habilidad de ataque 

    // Al haberle dado al boton del ataque ,

    // 1 comprueba que tengas acciones ,
    // 2 te deja seleccionar (Apuntar) a donde lanzas el ataque en un area de 1x1,
    // 6  Quita 1 o 2 de la barra de acciones
    // 3 se activa mi animacion de ataque y se activa la animacion de recibir daño del enemigo
    // 4 hace el daño en el personaje enemigo  ---> se reduce con la defensa del enemigo 
    //  Se carga la barra de ulti 
    // 5 comprueba si lo has matado ---> ocupar su casilla ( matado) / no moverse ( ya sea ataque a distancia o fisico)



    /// Habilidad de Suport

    // Al darle al boton hace; 

    // 1) comprueba que tengas acciones para hacerla ----> si no tienes te salta mensaje de que no tienes ( el mensaje se cierra cuando le das clic a cualquier cosa)
    // 2)  Selecciona donde aplicar la habilidad 
    // 7) Quita 1 o 2 de la barra de acciones
    // 3) Se activa la animacion de buffo o suport
    // 4) se realiza el buffo
    // 5) se aplica un cool down de 2-3 turnos donde el boton sale en gris y no se puede utilizar
    // 6) se carga la barra de ulti 


    /// Habilidad Ulti

    /// - caballero : 
    // 1) animacion de buffo 
    // 2) se activa un particle sistem que representa el estado de buffeado
    // 3) se aplican los buffos que iran contando cada turno cuando le quedan de vida para desactvasrse 
    // se reinicia el valor de la barra de ulti

    /// (Cuando termina la ulti)
    // se desactiva el particle sistem y los buffos 


    /// - torre : 
    // selecciona a que 2 personajes les da los escudos
    // hace la animacion de la ulti 
    // se desactivan los escudos de la geo 
    // se activa el prefab de escudos para personajes y desciende del cielo hasta llegar al personaje seleccionado  ---> el escudo sube hacia arriba cada vez que el personaje que lo posee hace algun ataque , y cuando termina vuelve a su poscion 
    // se aplica el buffeo que da el escudo 
    // se reinicia el valor de la barra de ulti

    /// - alfil : 
    // Apuntar hacia que direccion realiza el disparo 
    // se activa la animacion 
    // todos los personajes en el area del disparo activan su animacion de recibir daño y reciben el daño por codigo
    // se reinicia el valor de la barra de ulti


    /// - reina :   

    // 1) se realiza la animacion 
    // 2) todos los enemigos en el area definida de la ulti reciben daño y realizan la animacion de recibir daño 
    // se reinicia el valor de la barra de ulti
}
