using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameOver : MonoBehaviour
{

    [SerializeField] TextMeshProUGUI points;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    public void LoseScreem(int score)
    {
        SceneManager.LoadScene("Lose");
    }
}
