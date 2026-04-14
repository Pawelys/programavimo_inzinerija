using UnityEngine;

public class Zombie : MonoBehaviour
{
    [Header("Settings")]
    public float moveSpeed = 2f;       // Greitis einant link kelio
    public int damageAmount = 1;       // Žala automobiliui susidūrus

    private Transform _carTransform;
    private bool _hasDamaged = false;  // Kad žala būtų padaryta tik vieną kartą
    private Vector3 _moveDirection;    // Fiksuota kryptis — zombie eina tiesiai

    void Start()
    {
        // Randame automobilio objektą pagal tagą
        GameObject car = GameObject.FindGameObjectWithTag("Player");
        if (car != null)
        {
            _carTransform = car.transform;
            // Apskaičiuojame kryptį vieną kartą — zombie eis tiesiai
            _moveDirection = (car.transform.position - transform.position).normalized;
            _moveDirection.z = 0f;
        }
    }

    void Update()
    {
        if (_carTransform == null) return;

        // Zombie juda tiesiai fiksuota kryptimi
        transform.position += _moveDirection * moveSpeed * Time.deltaTime;

        // Pašaliname zombie, kuris praėjo pro automobilį (missed)
        if (transform.position.y < _carTransform.position.y - 10f)
        {
            Destroy(gameObject);
        }
    }

    // Kai zombie susiduria su automobiliu
    void OnTriggerEnter2D(Collider2D other)
    {
        if (_hasDamaged) return;

        if (other.CompareTag("Player"))
        {
            _hasDamaged = true;

            // Padarome žalą automobiliui
            CarHealth carHealth = other.GetComponent<CarHealth>();
            if (carHealth != null)
                carHealth.TakeDamage(damageAmount);

            // Sunaikinamas zombie po susidūrimo
            Destroy(gameObject, 0.1f);
        }
    }
}
