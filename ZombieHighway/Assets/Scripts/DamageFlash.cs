using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class DamageFlash : MonoBehaviour
{
    public static DamageFlash Instance;

    [RuntimeInitializeOnLoadMethod(RuntimeInitializeLoadType.BeforeSceneLoad)]
    static void AutoCreate()
    {
        if (Instance == null)
        {
            GameObject go = new GameObject("DamageFlash");
            go.AddComponent<DamageFlash>();
        }
    }

    [Header("Flash Settings")]
    public Color flashColor = new Color(1f, 0f, 0f, 0.5f);
    public float flashDuration = 0.25f;

    private Image flashImage;
    private float flashTimer;

    void Awake()
    {
        if (Instance != null && Instance != this)
        {
            Destroy(gameObject);
            return;
        }

        Instance = this;
        DontDestroyOnLoad(gameObject);

        CreateFlashUI();
        SceneManager.sceneLoaded += OnSceneLoaded;
    }

    void OnDestroy()
    {
        SceneManager.sceneLoaded -= OnSceneLoaded;
    }

    void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    {
        if (flashImage == null)
            CreateFlashUI();
    }

    void CreateFlashUI()
    {
        GameObject canvasGO = new GameObject("DamageFlashCanvas");
        canvasGO.transform.SetParent(transform);

        Canvas canvas = canvasGO.AddComponent<Canvas>();
        canvas.renderMode = RenderMode.ScreenSpaceOverlay;
        canvas.sortingOrder = 999;

        canvasGO.AddComponent<CanvasScaler>();
        canvasGO.AddComponent<GraphicRaycaster>();

        GameObject imageGO = new GameObject("FlashImage");
        imageGO.transform.SetParent(canvasGO.transform, false);

        flashImage = imageGO.AddComponent<Image>();
        flashImage.color = new Color(flashColor.r, flashColor.g, flashColor.b, 0f);
        flashImage.raycastTarget = false;

        RectTransform rt = flashImage.rectTransform;
        rt.anchorMin = Vector2.zero;
        rt.anchorMax = Vector2.one;
        rt.offsetMin = Vector2.zero;
        rt.offsetMax = Vector2.zero;
    }

    void Update()
    {
        if (flashImage == null) return;

        if (flashTimer > 0f)
        {
            flashTimer -= Time.deltaTime;
            float t = Mathf.Clamp01(flashTimer / flashDuration);
            Color c = flashImage.color;
            c.a = flashColor.a * t;
            flashImage.color = c;
        }
    }

    public void Flash()
    {
        if (flashImage == null) CreateFlashUI();
        flashTimer = flashDuration;
        Color c = flashColor;
        c.a = flashColor.a;
        flashImage.color = c;
    }

    public void FlashStrong()
    {
        flashTimer = flashDuration * 2f;
        Color c = flashColor;
        c.a = 0.8f;
        flashImage.color = c;
    }
}
