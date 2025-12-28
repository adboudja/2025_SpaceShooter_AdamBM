using UnityEngine;

public class AudioManager : MonoBehaviour
{
    [SerializeField] AudioSource musicSource;
    [SerializeField] AudioSource SFXSource;

    public AudioClip background;
    public AudioClip gamePlay;
    public AudioClip death;
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
        musicSource.Play();
    }
    public void musicSFX(AudioClip clip)
    {
        SFXSource.PlayOneShot(clip);
    }

    public void gameStart()
    {
        musicSource.clip = gamePlay;
        musicSource.Play();
    }
}
