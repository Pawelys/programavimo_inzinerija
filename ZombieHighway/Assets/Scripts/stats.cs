using UnityEngine;
using TMPro;

public class stats : MonoBehaviour
{
    public Transform Score;
    public TextMeshProUGUI Stats;
    public CarHealth carHealth;

    // Update is called once per frame
    void Update()
    {
        Stats.text = $"{Score.position.y.ToString("0")}\n" +
                     $"{carHealth.GetHealth()}\n" +
                     $"{carHealth.GetArmor()}";
    }
}
