using UnityEngine;
using UnityEngine.UI;

public class HPBar : MonoBehaviour
{
    [SerializeField] Slider HealthBar;

    public int maxHealth;
    public int currHealth;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        currHealth = maxHealth;
    }

    // Update is called once per frame
    void Update()
    {
        HealthBar.value = currHealth;
        HealthBar.maxValue = maxHealth;
    }
}
