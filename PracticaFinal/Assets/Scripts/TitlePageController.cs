using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class TitlePageController : MonoBehaviour
{
    public float delay = 3f;

    // Use this for initialization
    void Start()
    {
        StartCoroutine(LoadLevelAfterDelay(delay));
    }

    // Corrutina que carga la pantalla del menú principal tras un pequeño delay.
    IEnumerator LoadLevelAfterDelay(float delay)
    {
        yield return new WaitForSeconds(delay);
        SceneManager.LoadScene("MenuPrincipal");
    }
}