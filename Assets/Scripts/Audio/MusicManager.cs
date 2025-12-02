using UnityEngine;

public class MusicManager : MonoBehaviour
{
    public static MusicManager Instance;
    public AudioSource audioSource;

    void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
            return;
        }
    }

    void Start()
    {
        ApplyMusicPrefs();
    }

    public void ApplyMusicPrefs()
    {
        int musicaOn = PlayerPrefs.GetInt("musica", 1);
        bool isOn = (musicaOn == 1);
        if (audioSource != null)
            audioSource.mute = !isOn;
    }

    // Método público para alternar desde inspector o botones si prefieres
    public void ToggleMusic()
    {
        bool newState = (PlayerPrefs.GetInt("musica", 1) == 0);
        PlayerPrefs.SetInt("musica", newState ? 1 : 0);
        PlayerPrefs.Save();
        ApplyMusicPrefs();
    }
}

