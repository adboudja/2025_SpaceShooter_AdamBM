using UnityEngine;

public class AudioManager : MonoBehaviour
{
    [SerializeField] AudioSource musicSource;
    [SerializeField] AudioSource SFXSource;

    public AudioClip background;
    public AudioClip levelUp;
    public AudioClip hit;
    public AudioClip gamePlay;
    public AudioClip death;
    public AudioClip playerDeath;
    public AudioClip bossDeath;
    public AudioClip shoot;

    
    public static AudioManager instance;
    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
            
    }
    private void Start()
    {
        musicSource.clip = background;
        musicSource.loop = true;
        musicSource.Play();
    }
    public void musicSFX(AudioClip clip)
    {
        SFXSource.PlayOneShot(clip);
    }

    public void gameStart()
    {
        musicSource.clip = gamePlay;
        musicSource.loop = true;
        musicSource.Play();
    }

    public void gameMenu()
    {
        musicSource.clip = gamePlay;
        musicSource.loop = true;
        musicSource.Play();
    }

    public void musicTheme(AudioClip clip)
    {
        musicSource.clip = clip;
        musicSource.loop = true;
        musicSource.Play();
    }

}
