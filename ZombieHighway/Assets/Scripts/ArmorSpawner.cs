using UnityEngine;

public class ArmorSpawner : MonoBehaviour
{
    public GameObject armorPickupPrefab;
    public float armorSpawnChance = 0.3f;
    public float roadLength = 25f;

    public void SpawnArmorOnRoad(GameObject roadObject)
    {
        if (armorPickupPrefab == null) return;
        if (Random.value > armorSpawnChance) return;

        float[] lanesX = { -3.70f, -1.3f, 1.3f, 3.70f };
        float randomX = lanesX[Random.Range(0, lanesX.Length)];

        float minY = roadObject.transform.position.y - roadLength / 2f + 2f;
        float maxY = roadObject.transform.position.y + roadLength / 2f - 2f;
        float randomY = Random.Range(minY, maxY);

        Vector3 spawnPosition = new Vector3(randomX, randomY, 0f);

        GameObject armor = Instantiate(armorPickupPrefab, spawnPosition, Quaternion.identity);
        armor.transform.SetParent(roadObject.transform);
    }

    public void ClearOldArmor(GameObject roadObject)
    {
        for (int i = roadObject.transform.childCount - 1; i >= 0; i--)
        {
            Transform child = roadObject.transform.GetChild(i);

            if (child.name.Contains("ArmorPickup"))
            {
                Destroy(child.gameObject);
            }
        }
    }
}