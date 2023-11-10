using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyVisibility : MonoBehaviour
{
    int visibleLayer;
    int hideLayer;

    // Start is called before the first frame update
    void Start()
    {
        visibleLayer = LayerMask.NameToLayer("Default");
        hideLayer = LayerMask.NameToLayer("Hidden");
    }

    public void Show()
    {
        gameObject.layer = visibleLayer;
    }

    public void Hide()
    {
        gameObject.layer = hideLayer;
    }
}
