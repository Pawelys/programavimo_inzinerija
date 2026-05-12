using UnityEngine;
using UnityEngine.SceneManagement;

public class MusicManager : MonoBehaviour
{
    public static MusicManager Instance;

    [Header("Music")]
    public AudioClip menuMusic;
    public AudioClip gameMusic;

    [Range(0f, 1f)]
    public float musicVolume = 0.5f;

    [Header("Sound Effects")]
    public AudioClip shieldPickupSfx;
    public AudioClip zombieHitSfx;
    public AudioClip crashSfx;

    [Range(0f, 1f)]
    public float sfxVolume = 1f;

    private AudioSource musicSource;
    private AudioSource sfxSource;
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

        var sources = GetComponents<AudioSource>();
        if (sources.Length >= 1) musicSource = sources[0];
        else musicSource = gameObject.AddComponent<AudioSource>();

        if (sources.Length >= 2) sfxSource = sources[1];
        else sfxSource = gameObject.AddComponent<AudioSource>();

        musicSource.loop = true;
        musicSource.playOnAwake = false;
        musicSource.volume = musicVolume;

        sfxSource.loop = false;
        sfxSource.playOnAwake = false;
        sfxSource.volume = sfxVolume;

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
        musicSource.clip = clipToPlay;
        musicSource.volume = musicVolume;
        musicSource.Play();
    }

    public void PlayShieldPickup()
    {
        PlaySfx(shieldPickupSfx);
    }

    public void PlayZombieHit()
    {
        PlaySfx(zombieHitSfx);
    }

    public void PlayCrash()
    {
        PlaySfx(crashSfx);
    }

    void PlaySfx(AudioClip clip)
    {
        if (clip == null || sfxSource == null) return;
        sfxSource.PlayOneShot(clip, sfxVolume);
    }

    public void SetMusicVolume(float v)
    {
        musicVolume = Mathf.Clamp01(v);
        if (musicSource != null) musicSource.volume = musicVolume;
    }

    public void SetSfxVolume(float v)
    {
        sfxVolume = Mathf.Clamp01(v);
        if (sfxSource != null) sfxSource.volume = sfxVolume;
    }
}
