using UnityEngine;

public class ObstacleSpawner : MonoBehaviour
{
    public GameObject obstacleGroupPrefab; // Assign the ObstacleGroup prefab
    public float spawnRate = 2f; // Time interval between spawns
    public float minHeight = -2f; // Minimum height for the group
    public float maxHeight = 2f;  // Maximum height for the group

    private void Start()
    {
        // Start spawning obstacle groups
        InvokeRepeating("SpawnObstacleGroup", 2f, spawnRate);
    }

    void SpawnObstacleGroup()
    {
        // Randomize the vertical position of the group
        float spawnYPosition = Random.Range(minHeight, maxHeight);

        // Instantiate the obstacle group
        Vector3 spawnPosition = new Vector3(transform.position.x, spawnYPosition, 0);
        Instantiate(obstacleGroupPrefab, spawnPosition, Quaternion.identity);
    }
}