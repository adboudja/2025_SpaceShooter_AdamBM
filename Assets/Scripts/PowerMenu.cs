using UnityEngine;

public class PowerMenu : MonoBehaviour
{
    [SerializeField] GameObject container;
    [SerializeField] PlayerShip player;
    public static PowerMenu instance;

    void Awake()
    {
        if (instance == null)
            instance = this;
        else
            Destroy(gameObject);
    }

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    public void LevelUp()
    {
        container.SetActive(true);
        Time.timeScale = 0f;
    }

    // Update is called once per frame
    public void attackUP()
    {
        player.damage += 5;
        container.SetActive(false);
        Time.timeScale = 1f;
    }

    public void speedUP()
    {
        player.maxSpeed += 1f;
        container.SetActive(false);
        Time.timeScale = 1f;
    }

}
