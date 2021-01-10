using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.EventSystems;

public class MenuPrincipalController : MonoBehaviour
{
    private string buttonClicked;

    // Use this for initialization
    void Start()
    {

    }

    // Función que gestiona los clics de los botones de la página del menú. 
    public void ButtonClick()
    {
        // Obtenemos el nombre del botón clicado.
        buttonClicked = EventSystem.current.currentSelectedGameObject.name;

        // Comprobamos qué botón pulsamos para realizar una u otra acción.
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
            GoBack();
        }
        else if (buttonClicked == "ButtonReiniciar")
        {
            RestartLevel();
        }
    }

    // Función que inicia la escena de juego.
    public void StartGame()
    {
        SceneManager.LoadScene("GameFirstLevel");
    }

    // Función que inicia la escena de información de los controles.
    public void ReadControles()
    {
        SceneManager.LoadScene("InfoControles");
    }

    // Función que finaliza la partida.
    public void Exit()
    {
        Application.Quit();
    }

    // Función que vuelve a la escena del menú principal.
    public void GoBack()
    {
        SceneManager.LoadScene("MenuPrincipal");
    }

    // Función que reinicia la escena.
    public void RestartLevel()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

}
