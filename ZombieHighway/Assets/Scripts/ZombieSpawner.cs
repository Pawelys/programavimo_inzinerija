using UnityEngine;

public class ZombieSpawner : MonoBehaviour
{
    [Header("Zombie Prefab")]
    public GameObject zombiePrefab;

    [Header("Spawn Settings")]
    public float spawnInterval = 2f;        // Kas kiek sekundžių
    public float spawnAheadDistance = 8f;   // Kiek priekyje automobilio
    public float roadHalfWidth = 1.5f;      // Pusė kelio pločio
    public float sideSpread = 1f;           // Papildomas atstumas į šoną nuo kelio

    private Transform _carTransform;
    private float _timer = 0f;

    void Start()
    {
        GameObject car = GameObject.FindGameObjectWithTag("Player");
        if (car != null)
            _carTransform = car.transform;
        else
            Debug.LogWarning("ZombieSpawner: Nerasta 'Player' tagu pazymetas objektas!");
    }

    void Update()
    {
        if (_carTransform == null) return;

        _timer += Time.deltaTime;
        if (_timer >= spawnInterval)
        {
            _timer = 0f;
            SpawnZombie();
        }
    }

    void SpawnZombie()
    {
        // Kairė arba dešinė kelio pusė
        float side = Random.value > 0.5f ? 1f : -1f;
        float xPos = side * (roadHalfWidth + sideSpread);

        // Priekyje automobilio pagal Y ašį
        float yPos = _carTransform.position.y + spawnAheadDistance;

        Vector3 spawnPos = new Vector3(xPos, yPos, 0f);
        Instantiate(zombiePrefab, spawnPos, Quaternion.identity);
    }
}
