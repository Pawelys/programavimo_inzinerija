using UnityEngine;

public class ArmorPickup : MonoBehaviour
{
    public int armorAmount = 25;
    private Transform _carTransform;

    void Start()
    {
        GameObject car = GameObject.FindGameObjectWithTag("Player");
        if (car != null)
            _carTransform = car.transform;
    }

    void Update()
    {
        if (_carTransform == null) return;
        if (transform.position.y < _carTransform.position.y - 15f)
        {
            Destroy(gameObject);
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            Debug.Log("Picked armor: +" + armorAmount);
            Destroy(gameObject);
        }
    }
}