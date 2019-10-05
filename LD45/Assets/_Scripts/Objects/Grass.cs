using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Grass : WorldObject
{
    [SerializeField] private Sprite normalGrass = null;
    [SerializeField] private Sprite neighbourGrass = null;
    [SerializeField] private Sprite deadGrass = null;

    public override void UpdateObject() {
        if (!tracker.overworldSpawned) { Destroy(gameObject); return; }
        if (tracker.floodedworld) { Destroy(gameObject); return; }

        if (tracker.deadworld) {
            sRenderer.sprite = deadGrass;
            return;
        }
        
        if (!tracker.h20Spawned) {
            sRenderer.sprite = deadGrass;
            return;
        }

        if (tracker.neighboursSpawned) sRenderer.sprite = neighbourGrass;
        else sRenderer.sprite = normalGrass;
    }
}
