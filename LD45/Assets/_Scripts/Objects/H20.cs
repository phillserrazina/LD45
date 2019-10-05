using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class H20 : WorldObject
{
    [SerializeField] private Sprite worldWithH20 = null;
    [SerializeField] private Sprite floodedworld = null;

    private void Start()
    {
        if (!tracker.overworldSpawned) { Destroy(gameObject); return; }
        if (!tracker.deadworld) ChangeWorldSprite(worldWithH20);
        else ChangeWorldSprite(floodedworld);

        var t = FindObjectOfType<Trees>();
        var g = FindObjectOfType<Grass>();
        var i = FindObjectOfType<Intelligence>();

        if (t != null) Destroy(t.gameObject);
        if (g != null) Destroy(g.gameObject);
        if (i != null) Destroy(i.gameObject);
    }

    public override void UpdateObject() {
        
    }
}
