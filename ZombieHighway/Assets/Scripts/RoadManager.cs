using UnityEngine;

public class RoadManager : MonoBehaviour
{
    public GameObject Road;
    public Camera Camera;

    public float roadLenght = 25f;
    private float nextRoadY = 0f;

    void Start ()
    {
        nextRoadY = roadLenght;
    }

    void Update()
    {
        // Check if camera passed the middle of current road
        if (Camera.transform.position.y >= nextRoadY - roadLenght)
        {
            SpawnNewRoad();
        }
    }

    void SpawnNewRoad()
    {
        // Create a new road piece at the next position
        Instantiate(Road, new Vector3(0, nextRoadY, 0), Quaternion.identity);

        nextRoadY += roadLenght;
    }
}