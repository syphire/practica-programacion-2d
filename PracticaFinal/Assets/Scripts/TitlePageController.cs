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

    IEnumerator LoadLevelAfterDelay(float delay)
    {
        yield return new WaitForSeconds(delay);
        SceneManager.LoadScene("MenuPrincipal");
    }
}