using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Collider2D))]
public class SceneBounds : MonoBehaviour
{
    public static Bounds bounds;

    // Start is called before the first frame update
    void Start()
    {
        bounds = GetComponent<Collider2D>().bounds;
    }
}
