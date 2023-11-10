using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody), typeof(Collider2D))]
public class PlayerMovement : MonoBehaviour
{
    [SerializeField] float speed = 5;
    Vector2 direction;

    // Update is called once per frame
    void Update()
    {
        // Get the horizontal and vertical axis.
        float x = Input.GetAxis("Horizontal");
        float y = Input.GetAxis("Vertical");

        float inputSpeed = Mathf.Max(Mathf.Abs(x), Mathf.Abs(y));

        // Move translation
        transform.Translate(Time.deltaTime * speed * inputSpeed, 0, 0);

        if (inputSpeed > 0.1f)
            transform.rotation = Quaternion.Euler(0, 0, Mathf.Atan2(y, x) * Mathf.Rad2Deg);
    }
}
