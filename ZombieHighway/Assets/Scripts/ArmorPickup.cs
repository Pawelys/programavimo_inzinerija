using UnityEngine;

public class ArmorPickup : MonoBehaviour
{
    public int armorAmount = 25;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            Debug.Log("Picked armor: +" + armorAmount);
            Destroy(gameObject);
        }
    }
}