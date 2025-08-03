using System;
using System.Collections;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEditor;
using UnityEngine.InputSystem;
using UnityEngine.UIElements;

public class EnemySpawner : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created

    [SerializeField] GameObject greenEnemy;
    [SerializeField] GameObject redEnemy;

    private float spawnLocation;
    private float spawnCooldown = 20f;
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {

    }

    private void FixedUpdate()
    {
        if(UnityEngine.Random.Range(1, 150) == 1)
        {
            Spawn();
        }
    }

    private void Spawn()
    {
        Vector3 currentPosition = transform.position;
        if (UnityEngine.Random.Range(1, 3) == 1)
        {
            currentPosition.x = currentPosition.x + 10;
        }
        else
        {
            currentPosition.x = currentPosition.x - 10;
        }

        GameObject enemyInstance;

        if (UnityEngine.Random.Range(1, 3) == 1)
        {
            enemyInstance = Instantiate(redEnemy, currentPosition, Quaternion.identity);
        }
        else
        {
            enemyInstance = Instantiate(greenEnemy, currentPosition, Quaternion.identity);
        }
    }
}
