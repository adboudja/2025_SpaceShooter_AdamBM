using UnityEngine;

public class GameOverMenu : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    [SerializeField] GameObject containerWin;
    [SerializeField] GameObject containerLose;
    public static GameOverMenu instance;

    void Awake()
    {
        if (instance == null)
            instance = this;
        else
            Destroy(gameObject);
    }

    public void Win()
    {
        containerWin.SetActive(true);
        Time.timeScale = 0f;
    }

    public void Lose()
    {
        containerLose.SetActive(true);
        Time.timeScale = 0f;
    }
}
