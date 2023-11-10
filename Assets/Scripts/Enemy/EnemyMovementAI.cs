using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[RequireComponent(typeof(Rigidbody), typeof(Collider2D))]
public class EnemyMovementAI : MonoBehaviour
{
    float maxSpeed;
    [MinTo(0, 20)]
    [SerializeField] Vector2 maxSpeedRange = new Vector2(3, 10);

    float steerStrength;
    [MinTo(5, 30)]
    [SerializeField] Vector2 steerStrengthRange = new Vector2(15, 20);

    float randomDirectionStrength;
    [MinTo(0, 1)]
    [SerializeField] Vector2 randomDirectionStrengthRange = new Vector2(.1f, .2f);

    float roateAngleOnLeaveScene;
    [MinTo(-Mathf.PI, Mathf.PI)]
    [SerializeField] Vector2 roateAngleOnLeaveSceneRange = new Vector2(-Mathf.PI / 2, Mathf.PI / 2);

    Vector2 direction;
    Vector2 velocity;

    private void Awake()
    {
        maxSpeed = Random.Range(maxSpeedRange.x, maxSpeedRange.y);
        steerStrength = Random.Range(steerStrengthRange.x, steerStrengthRange.y);
        randomDirectionStrength = Random.Range(randomDirectionStrengthRange.x, randomDirectionStrengthRange.y);
        roateAngleOnLeaveScene = Random.Range(roateAngleOnLeaveSceneRange.x, roateAngleOnLeaveSceneRange.y);
    }

    Vector2 ComputeMaxDirectionDirection()
    {
        // Enemies move randomly within the boundaries of the scene
        direction = (direction + Random.insideUnitCircle * randomDirectionStrength).normalized;
        Vector2 goalPosition = (Vector2)transform.position + direction * maxSpeed * .5f;

        // if exit scene go to center and rotate direction
        if (!SceneBounds.bounds.Contains(goalPosition))
        {
            Debug.DrawLine(transform.position, goalPosition, Color.red);

            // rotate direction
            direction = Quaternion.AngleAxis(roateAngleOnLeaveScene, Vector3.forward) * direction;

            // go to center
            return (new Vector2() - (Vector2)transform.position).normalized;
        }
        else
        {
            Debug.DrawLine(transform.position, goalPosition, Color.white);

            return direction * maxSpeed;
        }
    }

    void Update()
    {
        Vector2 maxDirection = ComputeMaxDirectionDirection();

        Vector2 acceleration = Vector2.ClampMagnitude((maxDirection - velocity) * steerStrength, steerStrength);

        velocity = Vector2.ClampMagnitude(velocity + acceleration * Time.deltaTime, maxSpeed);

        Vector2 newPosition = (Vector2)transform.position + velocity * Time.deltaTime;

        float angle = Mathf.Atan2(velocity.y, velocity.x) * Mathf.Rad2Deg;

        //transform.rotation = Quaternion.Euler(0, 0, angle);
        transform.SetPositionAndRotation(newPosition, Quaternion.Euler(0, 0, angle));
    }

    public void SlowDown()
    {
        maxSpeed *= .99f;
    }
}
