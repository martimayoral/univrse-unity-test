using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyVisibility : MonoBehaviour
{
    int visibleLayer;
    int hideLayer;

    // number of zones that make enemy visible
    // when it is 0, enemy is not visible
    int zoneStrengthThatMakesMeVisible;

    // Start is called before the first frame update
    void Start()
    {
        visibleLayer = LayerMask.NameToLayer("Default");
        hideLayer = LayerMask.NameToLayer("Hidden");

        zoneStrengthThatMakesMeVisible = 0;
    }

    public void Show(int zones)
    {
        zoneStrengthThatMakesMeVisible += zones;
        gameObject.layer = visibleLayer;
    }

    public void Hide(int zones)
    {
        zoneStrengthThatMakesMeVisible -= zones;
        if (zoneStrengthThatMakesMeVisible == 0)
            gameObject.layer = hideLayer;
    }
}
