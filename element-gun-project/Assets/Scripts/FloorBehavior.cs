using System.Collections;
using System.Collections.Generic;
using System.Numerics;
using UnityEngine;
using Vector3 = UnityEngine.Vector3;

public class FloorBehavior : MonoBehaviour
{
    [SerializeField] private GameObject[] floorPrefab;

    private Transform playerTransform;
    private float spawnX = 0.0f;
    private float floorLength = 5;
    private int amountOfFloor = 3;

    // Start is called before the first frame update
    private void Start()
    {
        playerTransform = GameObject.FindGameObjectWithTag("Player").transform;
        spawnX = playerTransform.position.x;

        for (int i = 0; i < amountOfFloor; i++)
        {
            SpawnFloor();
        }
    }

    // Update is called once per frame
    private void FixedUpdate()
    {
        if (playerTransform.position.z > (spawnX - amountOfFloor * floorLength))
        {
            SpawnFloor();
        }
    }

    private void SpawnFloor(int prefabIndex = -1)
    {
        GameObject obj;
        obj = Instantiate(floorPrefab[0]) as GameObject;
        obj.transform.SetParent(transform);
        obj.transform.position = Vector3.right * spawnX;
        spawnX += floorLength;
    }
}
