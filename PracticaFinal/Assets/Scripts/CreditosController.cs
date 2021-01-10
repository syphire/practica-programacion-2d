using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class CreditosController : MonoBehaviour
{
    public float delay = 5f;

    // Use this for initialization
    void Start()
    {
        StartCoroutine(LoadMenuAfterDelay(delay));
    }

    // Corrutina que carga la pantalla de título del juego tras un pequeño delay.
    IEnumerator LoadMenuAfterDelay(float delay)
    {
        yield return new WaitForSeconds(delay);
        SceneManager.LoadScene("MenuPrincipal");
    }
}
