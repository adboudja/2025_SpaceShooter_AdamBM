using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using UnityEngine.Audio;
public class Botones : MonoBehaviour
{

    [SerializeField] private GameObject optionsMenu;

    [SerializeField] private GameObject mainMenu;

    [SerializeField] private Slider musicSlider;
    [SerializeField] private Slider SFXSlider;

    [SerializeField] private AudioMixer miMixer;

    private void Start()
    {
        float volume = musicSlider.value;
        miMixer.SetFloat("Music", Mathf.Log10(volume) * 20);

        volume = SFXSlider.value;
        miMixer.SetFloat("SFX", Mathf.Log10(volume) * 20);
    }
    public void BOpciones()
    {
        mainMenu.SetActive(false);
        optionsMenu.SetActive(true);
    }

    public void BAtras()
    {
        mainMenu.SetActive(true);
        optionsMenu.SetActive(false);
    }

    public void BSalir()
    {
        Application.Quit();
    }

    public void BJugar()
    {
        SceneManager.LoadScene(1);
    }

    public void MusicSlide()
    {
        float volume = musicSlider.value;
        miMixer.SetFloat("Music", Mathf.Log10(volume)*20);
    }

    public void SFXSlide()
    {
        float volume = SFXSlider.value;
        miMixer.SetFloat("SFX", Mathf.Log10(volume) * 20);
    }

}
