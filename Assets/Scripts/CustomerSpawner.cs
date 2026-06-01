using Unity.Collections;
using UnityEngine;

public class CustomerSpawner : MonoBehaviour
{
    public GameObject customerPrefab;
    public Transform spawnPoint;

    public float spawnInterval = 5f;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        InvokeRepeating(nameof(SpawnCustomer), 2f, spawnInterval);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
