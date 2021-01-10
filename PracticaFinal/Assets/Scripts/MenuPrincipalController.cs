using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using UnityEngine.SceneManagement;
using UnityEngine.EventSystems;

public class MenuPrincipalController : MonoBehaviour
{
    private string buttonClicked;

    // Use this for initialization
    void Start()
    {
        /*NuevaPartida.GetComponent<Button>();
        Controles.GetComponent<Button>();
        Salir.GetComponent<Button>();*/
    }

    // Update is called once per frame
    void Update()
    { 
        
    }

    public void ButtonClick()
    {
        buttonClicked = EventSystem.current.currentSelectedGameObject.name;

        if (buttonClicked == "EmpezarPartidaButton")
        {
            StartGame();
        }
        else if (buttonClicked == "ControlesButton")
        {
            ReadControles();
        }
        else if (buttonClicked == "SalirButton")
        {
            Exit();
        }
        else if (buttonClicked == "AtrasButton")
        {
            Debug.Log("boton atras");
            GoBack();
        }
    }

    public void StartGame()
    {
        SceneManager.LoadScene("GameFirstLevel");
    }

    public void ReadControles()
    {
        SceneManager.LoadScene("InfoControles");
    }

    public void Exit()
    {
        Application.Quit();
    }

    public void GoBack()
    {
        Debug.Log("dentro del boton atras");
        SceneManager.LoadScene("MenuPrincipal");
    }

}
