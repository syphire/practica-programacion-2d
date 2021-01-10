using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using System.Collections;

public class GameplayManager : MonoBehaviour
{
    public CharacterController CharacterController;
    public GameObject Character;
    public AudioSource Soundtrack;
    public AudioSource AudioGameOver;
    public AudioSource AudioFinish;

    public Text TextGameOver;
    public Text TextFinish;

    public Animator AbrirGranCofre;

    private float delay = 8f;

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
        CharacterController.GoToSecondLevel = GoToSecondLevel;
        CharacterController.EndGame = EndGame;
        CharacterController.FinishGame = FinishGame;

        CharacterController.enabled = true;

        Soundtrack.GetComponent<AudioSource>();
        AudioGameOver.GetComponent<AudioSource>();
        AudioFinish.GetComponent<AudioSource>();
        TextGameOver.GetComponent<Text>();
        TextFinish.GetComponent<Text>();
        AbrirGranCofre.GetComponent<Animator>();

        TextGameOver.enabled = false;
        TextFinish.enabled = false;

        Soundtrack.Play();
    }

    // Función que reinicia la escena.
    public void GoToSecondLevel()
    {
        Debug.Log("cargando second nivel");
        SceneManager.LoadScene("GameSecondLevel");
    }

    // Función que reinicia la escena.
    public void RestartLevel()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    // Función a la que se llama cuando el juego se termina tras haber perdido odos los corazones.
    // Se desactiva la música, el movimiento del personaje y se muestra el mensaje de fin.
    private void EndGame()
    {

        CharacterController.enabled = false;
        TextGameOver.enabled = true;
        Soundtrack.Stop();
        AudioGameOver.Play();
    }

    // Función a la que se llama cuando se termina el juego tras haber alcanzado la meta.
    // Se desactiva la música, el movimiento del personaje y se muestra el mensaje de fin.
    private void FinishGame()
    {
        CharacterController.enabled = false;
        TextFinish.enabled = true;
        AbrirGranCofre.SetTrigger("OpenGranCofre");
        Soundtrack.Stop();
        AudioFinish.Play();

        StartCoroutine(LoadCreditosAfterDelay(delay));
    }

    // Corrutina que carga la pantalla de créditos del juego.
    IEnumerator LoadCreditosAfterDelay(float delay)
    {
        yield return new WaitForSeconds(delay);
        SceneManager.LoadScene("Creditos");
    }


}