using UnityEngine;

public class CarHealth : MonoBehaviour
{
    [Header("Health Settings")]
    public int maxHealth = 5;
    private int _currentHealth;

    void Start()
    {
        _currentHealth = maxHealth;
    }

    public void TakeDamage(int amount)
    {
        _currentHealth -= amount;
        Debug.Log($"Car health: {_currentHealth}");

        if (_currentHealth <= 0)
        {
            Debug.Log("Automobilis sunaikintas! Žaidimas baigtas.");
            // Čia vėliau pridėsite Game Over logiką
        }
    }

    public int GetHealth()
    {
        return _currentHealth;
    }
}
