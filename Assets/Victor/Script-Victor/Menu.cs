using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using static UnityEditor.ShaderData;

public class Menu : MonoBehaviour
{
    [SerializeField] GameObject menuPausa;
    private bool pausa;

    [SerializeField] AudioClip sonidoApretar;
    [SerializeField] Audio_Manager manager;
    [SerializeField] GameObject InfoCharactMenu;
    void Start()
    {
        InfoCharactMenu.SetActive(false);
    }

    
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (pausa == false)
            {
                pausa = true;
                menuPausa.SetActive(true);

                Time.timeScale = 0f;

            

            }
        }
    }

    public void Reanudar ()
    {
        new WaitForSeconds(300);
        menuPausa.SetActive(false);
        pausa = false;

        Time.timeScale = 1;

       
    }
    public void Empezar()
    {
        new WaitForSecondsRealtime(3);
        SceneManager.LoadScene(2);
    }
    public void Configuracion()
    {
        new WaitForSecondsRealtime(3);
        SceneManager.LoadScene(1);
    }
    public void Salir()
    {
        
        Application.Quit();
    }
    public void TittleScreen()
    {
        SceneManager.LoadScene(0);
    }

    public void InfoCharacters()
    {
        InfoCharactMenu.SetActive(true);
    }

}
