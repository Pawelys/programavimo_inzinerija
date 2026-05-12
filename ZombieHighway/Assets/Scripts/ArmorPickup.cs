using UnityEngine;

public class ArmorPickup : MonoBehaviour
{
    public int armorAmount = 1;
    private Transform _carTransform;
    private CarHealth _carHealth;

    void Start()
    {
        GameObject car = GameObject.FindGameObjectWithTag("Player");
        if (car != null)
        {
            _carTransform = car.transform;
            _carHealth = car.GetComponent<CarHealth>();
        }
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
            if (_carHealth != null)
            {
                _carHealth.AddArmor();
                if (MusicManager.Instance != null)
                    MusicManager.Instance.PlayShieldPickup();
                Debug.Log("Picked armor: +" + armorAmount);
                Destroy(gameObject);
            }
        }
    }
}