using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Neighbours : WorldObject
{
    [SerializeField] private Sprite worldFinal = null;
    [SerializeField] private Sprite neededSprite = null;

    public override void UpdateObject() {
        if (!tracker.overworldSpawned) { Destroy(gameObject); return; }

        var i = FindObjectOfType<Intelligence>();
        if (i == null) { Destroy(gameObject); return; }

        var iRenderer = i.GetComponent<SpriteRenderer>().sprite;

        if (iRenderer == neededSprite) sRenderer.sprite = worldFinal;
        else { Destroy(gameObject); return; }
    }
}
