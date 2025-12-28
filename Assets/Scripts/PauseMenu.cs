using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{
    [SerializeField] GameObject container;
    public static PauseMenu instance;

    void Awake()
    {
        if (instance == null)
            instance = this;
        else
            Destroy(gameObject);
    }

    public void Pause()
    {
        container.SetActive(true);
        Time.timeScale = 0f;
    }

    public void Resume()
    {
        container.SetActive(false);
        Time.timeScale = 1f;
    }
    public void Menu()
    {
        StopAllCoroutines();
        AudioManager.instance.gameMenu();
        Time.timeScale = 1f;
        SceneManager.LoadScene("Menu");
    }

}
