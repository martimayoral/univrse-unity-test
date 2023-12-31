using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    [SerializeField] KeyCode keyToPress = KeyCode.X;
    [SerializeField] Transform enemyPrefab;
    [SerializeField] Transform enemyRoot;
    [SerializeField] float delayBetweenSpawn;
    float lastSpawn;

    private void Start()
    {
        lastSpawn = Time.time;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(keyToPress) && Time.time > lastSpawn + delayBetweenSpawn ||
            // faster with shift
            Input.GetKey(keyToPress) && Input.GetKey(KeyCode.LeftShift) && Time.time > lastSpawn + delayBetweenSpawn * .1f)
        {
            Instantiate(enemyPrefab, enemyRoot);
            lastSpawn = Time.time;
        }
    }
}
