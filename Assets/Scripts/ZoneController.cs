using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Collider2D))]
public class ZoneController : MonoBehaviour
{
    [SerializeField] ZoneController[] neighbourZones;

    List<EnemyController> enemiesInside;

    // positive when player is inside
    // 0 if player is not inside
    int zoneStrength = 0;

    // Start is called before the first frame update
    void Start()
    {
        enemiesInside = new List<EnemyController>();
    }

    private void OnPlayerEnter()
    {
        zoneStrength++;
        enemiesInside.ForEach(e =>
        {
            e.OnEnterZone(this);
        });
    }
    private void OnPlayerExit()
    {
        zoneStrength--;
        enemiesInside.ForEach(e =>
        {
            e.OnExitZone(this);
        });
    }

    private void OnEnemyEnter(Transform enemy)
    {
        EnemyController enemyVisibility = enemy.GetComponent<EnemyController>();
        enemiesInside.Add(enemyVisibility);

        if (zoneStrength > 0)
        {
            enemyVisibility.OnEnterZone(this, zoneStrength);
        }
    }
    private void OnEnemyExit(Transform enemy)
    {
        EnemyController enemyVisibility = enemy.GetComponent<EnemyController>();
        enemiesInside.Remove(enemyVisibility);

        if (zoneStrength > 0)
        {
            enemyVisibility.OnExitZone(this, zoneStrength);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.transform.CompareTag("Player"))
        {
            OnPlayerEnter();
            foreach (var zone in neighbourZones)
            {
                zone.OnPlayerEnter();
            }
        }
        else if (collision.transform.CompareTag("Enemy"))
            OnEnemyEnter(collision.transform);
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.transform.CompareTag("Player"))
        {
            OnPlayerExit();
            foreach (var zone in neighbourZones)
            {
                zone.OnPlayerExit();
            }
        }
        else if (collision.transform.CompareTag("Enemy"))
            OnEnemyExit(collision.transform);
    }

    public void RemoveEnemy(EnemyController enemy)
    {
        enemiesInside.Remove(enemy);
    }
}
