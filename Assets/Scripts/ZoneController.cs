using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Collider2D))]
public class ZoneController : MonoBehaviour
{
    [SerializeField] ZoneController[] neighbourZones;

    // positive when player is inside
    // 0 if player is not inside
    int zoneStrength = 0;
    List<EnemyVisibility> enemiesInside;

    // Start is called before the first frame update
    void Start()
    {
        enemiesInside = new List<EnemyVisibility>();
    }

    private void OnPlayerEnter()
    {
        zoneStrength++;
        enemiesInside.ForEach(e =>
        {
            e.Show(1);
        });
    }
    private void OnPlayerExit()
    {
        zoneStrength--;
        enemiesInside.ForEach(e =>
        {
            e.Hide(1);
        });
    }

    private void OnEnemyEnter(Transform enemy)
    {
        EnemyVisibility enemyVisibility = enemy.GetComponent<EnemyVisibility>();
        enemiesInside.Add(enemyVisibility);

        if (zoneStrength > 0)
            enemyVisibility.Show(zoneStrength);
    }
    private void OnEnemyExit(Transform enemy)
    {
        EnemyVisibility enemyVisibility = enemy.GetComponent<EnemyVisibility>();
        enemiesInside.Remove(enemyVisibility);

        if (zoneStrength > 0)
            enemyVisibility.Hide(zoneStrength);
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
}
