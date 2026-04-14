using UnityEngine;
using UnityEngine.UI;

public class ScoreManager : MonoBehaviour
{
    public static ScoreManager Instance;
    private Text _scoreText;
    private int _score = 0;

    void Awake()
    {
        if (Instance == null)
            Instance = this;
        else
        {
            Destroy(gameObject);
            return;
        }

        CreateUI();
    }

    void CreateUI()
    {
        GameObject canvasObj = new GameObject("ScoreCanvas");
        Canvas canvas = canvasObj.AddComponent<Canvas>();
        canvas.renderMode = RenderMode.ScreenSpaceOverlay;
        canvasObj.AddComponent<CanvasScaler>();
        canvasObj.AddComponent<GraphicRaycaster>();

        GameObject textObj = new GameObject("ScoreText");
        textObj.transform.SetParent(canvasObj.transform);
        _scoreText = textObj.AddComponent<Text>();
        _scoreText.font = Resources.GetBuiltinResource<Font>("LegacyRuntime.ttf");
        _scoreText.fontSize = 32;
        _scoreText.color = Color.white;
        _scoreText.alignment = TextAnchor.UpperLeft;
        _scoreText.text = "Score: 0";

        RectTransform rt = _scoreText.GetComponent<RectTransform>();
        rt.anchorMin = new Vector2(0, 1);
        rt.anchorMax = new Vector2(0, 1);
        rt.pivot = new Vector2(0, 1);
        rt.anchoredPosition = new Vector2(20, -20);
        rt.sizeDelta = new Vector2(300, 50);

        Outline outline = textObj.AddComponent<Outline>();
        outline.effectColor = Color.black;
        outline.effectDistance = new Vector2(2, -2);
    }

    void Start()
    {
        UpdateUI();
    }

    public void AddScore(int amount)
    {
        _score += amount;
        UpdateUI();
    }

    public int GetScore()
    {
        return _score;
    }

    private void UpdateUI()
    {
        if (_scoreText != null)
            _scoreText.text = "Score: " + _score;
    }
}
