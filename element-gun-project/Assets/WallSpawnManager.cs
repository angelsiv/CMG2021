using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WallSpawnManager : MonoBehaviour
{
    [SerializeField] private GameObject mediumWall = null;
    [SerializeField] private Transform topSpawner = null;
    [SerializeField] private int spawnRate = 20;
    [SerializeField] private AudioSource audiosource = null;
        
    private void Awake()
    {
        InvokeRepeating(nameof(InstantiateWall),5,spawnRate);
    }

    private void InstantiateWall()
    {
        GameObject wall = Instantiate(mediumWall, topSpawner);
        wall.SetActive(true);
    }
}
