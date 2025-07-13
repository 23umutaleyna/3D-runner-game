using UnityEngine;

public class LocationSpawner : MonoBehaviour
{
    [SerializeField] GameObject[] locationPrefabs;
    [SerializeField] GameObject firstLocation;
    float locationLength = 15f;

    private float playerPositionZ;
    private float lastSpawnPositionZ;
    public int additionalLocationsCount = 10;
    public Transform player;
    [SerializeField] GameObject bonus;

    void Start()
    {
        lastSpawnPositionZ = firstLocation.transform.position.z;
    }
    void Update()
    {
        playerPositionZ = player.position.z;
        if (playerPositionZ > lastSpawnPositionZ - locationLength * additionalLocationsCount)
        {
            GenerateAdditionalLocations();
        }
        if(Random.value<0.03f)
        {
            Instantiate(bonus, player.position + new Vector3(0, 2, 50), Quaternion.identity);
        }
    }
    void GenerateAdditionalLocations()
    {
        for (int i = 0; i < additionalLocationsCount; i++)
        {
            lastSpawnPositionZ = lastSpawnPositionZ + locationLength;
            int randomIndex = Random.Range(0, locationPrefabs.Length);
            GameObject selectedPrefab = locationPrefabs[randomIndex];
            GameObject newLocation = Instantiate(selectedPrefab, new Vector3(0, 0, lastSpawnPositionZ), Quaternion.identity);
        }
    }
}
