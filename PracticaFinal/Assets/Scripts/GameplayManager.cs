using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using System.Collections;

public class GameplayManager : MonoBehaviour
{
    public CharacterController CharacterController;
    public MenuPrincipalController MenuPrincipalController;
    public GameObject Character;
    public AudioSource Soundtrack;
    public AudioSource AudioGameOver;
    public AudioSource AudioFinish;

    public Text TextGameOver;
    public Text TextFinish;
    public GameObject ButtonResetLevel;

    public Animator AbrirGranCofre;

    private float delay = 8f;

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
        ButtonResetLevel.GetComponent<GameObject>();
        AbrirGranCofre.GetComponent<Animator>();

        TextGameOver.enabled = false;
        TextFinish.enabled = false;
        ButtonResetLevel.SetActive(false);

        Soundtrack.Play();
    }

    // Función que reinicia la escena.
    public void GoToSecondLevel()
    {
        Debug.Log("cargando second nivel");
        SceneManager.LoadScene("GameSecondLevel");
    }

    // Función que reinicia la escena.
    /*public void RestartLevel()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }*/

    // Función a la que se llama cuando el juego se termina tras haber perdido todos los corazones.
    // Se desactiva la música, el movimiento del personaje y se muestra el mensaje de fin.
    private void EndGame()
    {

        CharacterController.enabled = false;
        TextGameOver.enabled = true;
        ButtonResetLevel.SetActive(true);
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