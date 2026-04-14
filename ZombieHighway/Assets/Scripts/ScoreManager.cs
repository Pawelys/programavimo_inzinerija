using UnityEngine;
using UnityEngine.UI;

public class ScoreManager : MonoBehaviour
{
    public static ScoreManager Instance;

    [Header("UI")]
    public Text scoreText;

    private int _score = 0;

    void Awake()
    {
        if (Instance == null)
            Instance = this;
        else
            Destroy(gameObject);
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
        if (scoreText != null)
            scoreText.text = "Score: " + _score;
    }
}
