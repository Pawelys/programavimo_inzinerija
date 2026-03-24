using UnityEngine;

public class RoadManager : MonoBehaviour
{
    public GameObject Road;
    public Camera Camera;
    private GameObject Road2;

    public float roadLength = 25f;
    private float nextRoadY = 0f;

    private ArmorSpawner armorSpawner;

    void Start()
    {
        armorSpawner = GetComponent<ArmorSpawner>();

        nextRoadY = roadLength;

        Road2 = Instantiate(Road, new Vector3(0, nextRoadY, 0), Quaternion.identity);

        if (armorSpawner != null)
        {
            armorSpawner.roadLength = roadLength;
            armorSpawner.SpawnArmorOnRoad(Road);
            armorSpawner.SpawnArmorOnRoad(Road2);
        }

        nextRoadY += roadLength;
    }

    void Update()
    {
        if (Camera.transform.position.y >= nextRoadY - roadLength)
        {
            SpawnNewRoad();
        }
    }

    void SpawnNewRoad()
    {
        GameObject movedRoad = null;

        if (Road.transform.position.y <= Camera.transform.position.y - roadLength)
        {
            Road.transform.position = new Vector3(0, nextRoadY, 0);
            movedRoad = Road;
        }
        else if (Road2.transform.position.y <= Camera.transform.position.y - roadLength)
        {
            Road2.transform.position = new Vector3(0, nextRoadY, 0);
            movedRoad = Road2;
        }

        if (movedRoad != null && armorSpawner != null)
        {
            armorSpawner.ClearOldArmor(movedRoad);
            armorSpawner.roadLength = roadLength;
            armorSpawner.SpawnArmorOnRoad(movedRoad);
        }

        nextRoadY += roadLength;
    }
}