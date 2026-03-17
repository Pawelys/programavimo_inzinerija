using UnityEngine;

public class RoadManager : MonoBehaviour
{
    public GameObject Road;
    public Camera Camera;
    private GameObject Road2;

    public float roadLength = 25f;
    private float nextRoadY = 0f;

    void Start ()
    {
        nextRoadY = roadLength;
        
        // Create second road
        Road2 = Instantiate(Road, new Vector3(0, nextRoadY, 0), Quaternion.identity);

        nextRoadY += roadLength;
    }

    void Update()
    {
        // Check if camera passed the middle of current road
        if (Camera.transform.position.y >= nextRoadY - roadLength)
        {
            SpawnNewRoad();
        }
    }

    void SpawnNewRoad()
    {
        // Find whitch road to move
        if (Road.transform.position.y <= Camera.transform.position.y - roadLength)
        {
            Road.transform.position = new Vector3(0, nextRoadY, 0);
        }
        else if (Road2.transform.position.y <= Camera.transform.position.y - roadLength)
        {
            Road2.transform.position = new Vector3(0, nextRoadY, 0);
        }

        nextRoadY += roadLength;
    }
}