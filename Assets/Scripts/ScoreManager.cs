using TMPro;
using UnityEngine;
using UnityEngine.SocialPlatforms.Impl;

public class ScoreManager : MonoBehaviour
{
    public static ScoreManager instance;

    [SerializeField] TextMeshProUGUI pointsText;
    private int points;


    void Awake()
    {
        if (instance == null)
            instance = this;
        else
            Destroy(gameObject);
    }
    void Start()
    {
        UpdateScoreText();
    }
    public void AddScore(int amount)
    {
        points += amount;
        UpdateScoreText();
    }

    void UpdateScoreText()
    {
        pointsText.text = $"Points: {points}";
    }
}
