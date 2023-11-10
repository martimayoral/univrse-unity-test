using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody), typeof(Collider2D))]
public class PlayerMovement : MonoBehaviour
{
    [SerializeField] float speed = 5;
    [SerializeField] KeyCode sprintKey = KeyCode.LeftShift;
    float radius;

    private void Awake()
    {
        radius = GetComponent<CircleCollider2D>().radius * transform.localScale.x;
    }

    // Update is called once per frame
    void Update()
    {
        // Get the horizontal and vertical axis.
        float x = Input.GetAxis("Horizontal");
        float y = Input.GetAxis("Vertical");

        float inputSpeed = Mathf.Max(Mathf.Abs(x), Mathf.Abs(y));

        if (Input.GetKey(sprintKey))
            inputSpeed *= 2;

        // Move translation
        transform.Translate(Time.deltaTime * speed * inputSpeed, 0, 0);

        // collision with bounds
        transform.position = new Vector2(Mathf.Clamp(transform.position.x, SceneBounds.bounds.min.x + radius, SceneBounds.bounds.max.x - radius),
            Mathf.Clamp(transform.position.y, SceneBounds.bounds.min.y + radius, SceneBounds.bounds.max.y - radius));


        if (inputSpeed > 0.1f)
            transform.rotation = Quaternion.Euler(0, 0, Mathf.Atan2(y, x) * Mathf.Rad2Deg);
    }
}
