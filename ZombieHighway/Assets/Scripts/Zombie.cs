using UnityEngine;

public class Zombie : MonoBehaviour
{
    [Header("Settings")]
    public float moveSpeed = 2f;       // Greitis einant link kelio
    public int damageAmount = 1;       // Žala automobiliui susidūrus

    private Transform _carTransform;
    private bool _hasDamaged = false;  // Kad žala būtų padaryta tik vieną kartą

    void Start()
    {
        // Randame automobilio objektą pagal tagą
        GameObject car = GameObject.FindGameObjectWithTag("Player");
        if (car != null)
            _carTransform = car.transform;
    }

    void Update()
    {
        if (_carTransform == null) return;

        // Zombie juda link automobilio X ašimi (eina į kelią)
        Vector3 direction = (_carTransform.position - transform.position).normalized;
        direction.z = 0f; // 2D žaidimas — ignoruojame Z ašį

        transform.position += direction * moveSpeed * Time.deltaTime;
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
