using System;
using TMPro;
using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.UI;

public class EXPManager : MonoBehaviour
{
    public static EXPManager instance;
    [SerializeField] AnimationCurve expCurve;

    int currLevel,totalEXP,currEXP;
    int prevLevelXP, nextLevelXP;

    [SerializeField] TextMeshProUGUI LVLText;
    [SerializeField] Slider EXPSlide;

    void Awake()
    {
        if (instance == null)
            instance = this;
        else
            Destroy(gameObject);
    }
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        UpdateLevel();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        //AddEXP(1);
    }

    public void AddEXP(int amount)
    {
        totalEXP += amount;
        currEXP += amount;
        CheckLevelUp();
        UpdateInterfece();
    }

    private void CheckLevelUp()
    {
        if(totalEXP > nextLevelXP)
        {
            currLevel++;
            UpdateLevel();
        }
    }

    private void UpdateLevel()
    {
        currEXP = 0;
        AudioManager.instance.musicSFX(AudioManager.instance.levelUp);
        prevLevelXP = (int)expCurve.Evaluate(currLevel);
        nextLevelXP =(int)expCurve.Evaluate(currLevel+1);
        if (currLevel > 0)
        {
            PowerMenu.instance.LevelUp();
        }
        
        UpdateInterfece();
        
    }

    private void UpdateInterfece()
    {
        LVLText.text = $"Level:{currLevel}";
        EXPSlide.value = currEXP;
        EXPSlide.maxValue = nextLevelXP;
    }
}
