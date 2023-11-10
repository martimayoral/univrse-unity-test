using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KillEnemyOnHit : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.transform.CompareTag("Enemy"))
            collision.GetComponent<EnemyMovementAI>().die();
    }
}
