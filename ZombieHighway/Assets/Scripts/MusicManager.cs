using UnityEngine;
using UnityEngine.SceneManagement;

public class MusicManager : MonoBehaviour
{
    public static MusicManager Instance;

    public AudioClip menuMusic;
    public AudioClip gameMusic;

    [Range(0f, 1f)]
    public float volume = 0.5f;

    private AudioSource audioSource;
    private AudioClip currentClip;

    void Awake()
    {
        if (Instance != null && Instance != this)
        {
            Destroy(gameObject);
            return;
        }

        Instance = this;
        DontDestroyOnLoad(gameObject);

        audioSource = GetComponent<AudioSource>();
        if (audioSource == null)
            audioSource = gameObject.AddComponent<AudioSource>();

        audioSource.loop = true;
        audioSource.playOnAwake = false;
        audioSource.volume = volume;

        SceneManager.sceneLoaded += OnSceneLoaded;
        PlayMusicForScene(SceneManager.GetActiveScene().name);
    }

    void OnDestroy()
    {
        SceneManager.sceneLoaded -= OnSceneLoaded;
    }

    void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    {
        PlayMusicForScene(scene.name);
    }

    void PlayMusicForScene(string sceneName)
    {
        AudioClip clipToPlay = (sceneName == "Scene") ? gameMusic : menuMusic;

        if (clipToPlay == null || clipToPlay == currentClip)
            return;

        currentClip = clipToPlay;
        audioSource.clip = clipToPlay;
        audioSource.volume = volume;
        audioSource.Play();
    }

    public void SetVolume(float newVolume)
    {
        volume = Mathf.Clamp01(newVolume);
        if (audioSource != null)
            audioSource.volume = volume;
    }
}
