using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyOnPressAnyKey : MonoBehaviour
{
    // Update is called once per frame
    void Update()
    {
        if (Input.anyKeyDown)
            Destroy(gameObject);
    }
}
