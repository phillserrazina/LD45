using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Intelligence : WorldObject
{
    [SerializeField] private Sprite overworldIntelligence = null;
    [SerializeField] private Sprite deadworldIntelligence = null;
    [SerializeField] private Sprite floodedworldIntelligence = null;

    [SerializeField] private Sprite treesNeededSprite = null;
    [SerializeField] private Sprite grassNeededSprite = null;

    public override void UpdateObject() {
        if (!tracker.overworldSpawned) { Destroy(gameObject); return; }

        if (tracker.floodedworld) { sRenderer.sprite = floodedworldIntelligence; return; }
        if (tracker.deadworld) { sRenderer.sprite = deadworldIntelligence; return; }

        var t = FindObjectOfType<Trees>();
        if (t == null) { sRenderer.sprite = deadworldIntelligence; return; }

        var g = FindObjectOfType<Grass>();
        if (g == null) { sRenderer.sprite = deadworldIntelligence; return; }

        var ts = t.GetComponent<SpriteRenderer>().sprite;
        var gs = g.GetComponent<SpriteRenderer>().sprite;

        if (ts == treesNeededSprite && gs == grassNeededSprite) sRenderer.sprite = overworldIntelligence;
    }
}
