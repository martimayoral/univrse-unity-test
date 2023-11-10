using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JumpBetweenZones : MonoBehaviour
{
    [SerializeField] KeyCode keyToPress = KeyCode.Space;
    [SerializeField] Transform[] zones;

    int zoneCursor = 0;

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(keyToPress) && zones.Length > 0)
        {
            transform.position = zones[zoneCursor].position;

            zoneCursor = (zoneCursor + 1) % zones.Length;
        }
    }
}
