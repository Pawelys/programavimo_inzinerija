using UnityEngine;

public class CarHealth : MonoBehaviour
{
    [Header("Health Settings")]
    public int maxHealth = 5;
    private int _currentHealth;

    [Header("Armor Settings")]
    private int _currentArmor = 0;
    public int maxArmor = 1;

    void Start()
    {
        _currentHealth = maxHealth;
        _currentArmor = 0;
    }

    public void TakeDamage(int amount)
    {
        // Pirmiausia panaudojame armor jei turime
        if (_currentArmor > 0)
        {
            _currentArmor = 0;
            Debug.Log($"Armor sunaudotas! Likęs armor: {_currentArmor}");
        }
        else
        {
            // Jei neturime armor, mažiname health
            _currentHealth -= amount;
            Debug.Log($"Car health: {_currentHealth}");
        }

        if (_currentHealth <= 0)
        {
            Debug.Log("Automobilis sunaikintas! Žaidimas baigtas.");
            // Čia vėliau pridėsite Game Over logiką
        }
    }

    public void AddArmor()
    {
        if (_currentArmor < maxArmor)
        {
            _currentArmor = 1;
            Debug.Log($"Armor gautas! Dabartinis armor: {_currentArmor}");
        }
        else
        {
            Debug.Log("Jau turite maksimalų armor!");
        }
    }

    public int GetHealth()
    {
        return _currentHealth;
    }

    public int GetArmor()
    {
        return _currentArmor;
    }
}