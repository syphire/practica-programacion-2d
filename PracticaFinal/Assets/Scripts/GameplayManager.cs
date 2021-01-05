using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameplayManager : MonoBehaviour
{
    public CharacterController CharacterController;
    public GameObject Character;
    /*public Button StartButton;
    public Button ResetButton;
    public Text Victoria;
    public Text GameOver;
    public AudioSource Music;
    public AudioSource YouLose;
    public AudioSource Winner;
    public Animator MoveMushroom;
    public ParticleSystem Lluvia;

    public SpriteRenderer SpriteCharacter;

    public Transform Enemy;*/

    // Función Start.
    // Se inicializan las variables y se obtienen los componentes musicales.
    private void Start()
    {

        //MarioController.OnKilled += EndGameEnemy;
        //MarioController.OnReachedEndOfLevelFlagStick += EndGame;
        CharacterController.enabled = true;
        //MarioController.Mushroom = OnMushroom;
        //MarioController.GetSuperMario += GetSuperMario;

    }

    // Función que inicia la partida tras pulsar en el botón de inicio.
    // Se activa el movimiento del personaje, empieza a sonar la música y se oculta el botón.
    public void StartGame()
    {
        CharacterController.enabled = true;
    }

    // Función que reinicia la escena.
    public void RestartLevel()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    // Función a la que se llama cuando el juego se termina tras haber chocado con un enemigo.
    // Se desactiva la música, el movimiento del personaje, y se muestra el mensaje de fin.
    private void EndGameEnemy()
    {

        CharacterController.enabled = false;
    }

    // Función a la que se llama cuando se termina el juego tras haber alcanzado la meta.
    // Se desactiva la música, el movimiento del personaje y se muestra el mensaje de fin.
    private void EndGame()
    {

        CharacterController.enabled = false;
    }

    // Función a la que se llama cuando golpeamos el ladrillo y que inicia la animación de la seta.
    private void OnMushroom()
    {
        //MoveMushroom.SetTrigger("MoveMushroom");
    }

    // Función a la que se llama cuando el personaje coge la seta que lo transforma en Super Mario.
    private void GetSuperMario()
    {
        // Para ello se inicia una corrutina donde se cambia el color del personaje y se le da sus poderes.
        //StartCoroutine(Character.GetComponent<ChangeColor>().GetSuperMarioColor(SpriteCharacter));
    }
}