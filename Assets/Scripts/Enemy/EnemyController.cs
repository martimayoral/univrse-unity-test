using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    List<ZoneController> zones;
    EnemyVisibility enemyVisibility;

    [SerializeField] float timeToDie = .5f;
    bool isDead = false;
    float timeOfDeath;

    EnemyMovementAI movementAI;

    // number of zones that make enemy visible
    // when it is 0, enemy is not visible
    int zoneStrengthThatMakesMeVisible;

    private void Awake()
    {
        zones = new List<ZoneController>();
        enemyVisibility = GetComponent<EnemyVisibility>();
        movementAI = GetComponent<EnemyMovementAI>();

        zoneStrengthThatMakesMeVisible = 0;
    }

    public void OnEnterZone(ZoneController zone, int zoneStrength = 1)
    {
        if (isDead)
            return;

        zoneStrengthThatMakesMeVisible += zoneStrength;
        zones.Add(zone);
        enemyVisibility.Show();
    }

    public void OnExitZone(ZoneController zone, int zoneStrength = 1)
    {
        if (isDead)
            return;

        zones.Remove(zone);

        zoneStrengthThatMakesMeVisible -= zoneStrength;
        if (zoneStrengthThatMakesMeVisible == 0)
            enemyVisibility.Hide();
    }

    public void die()
    {
        foreach (var zone in zones)
        {
            zone.RemoveEnemy(this);
        }
        isDead = true;
        GetComponent<Collider2D>().enabled = false;
        Destroy(gameObject, timeToDie);
        timeOfDeath = Time.time;
    }

    private void Update()
    {
        if (isDead)
        {
            movementAI.SlowDown();
            transform.localScale = Mathf.Lerp(1, 0, (Time.time - timeOfDeath) / timeToDie) * new Vector3(1, 1, 1);
        }
    }
}
