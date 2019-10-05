using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Trees : WorldObject
{
    [SerializeField] private Sprite fullworldTrees = null;
    [SerializeField] private Sprite neighbourTrees = null;
    [SerializeField] private Sprite deadTrees = null;
    [SerializeField] private Sprite floodedTrees = null;

    public override void UpdateObject() {
        if (!tracker.overworldSpawned) { Destroy(gameObject); return; }

        if (tracker.floodedworld) { sRenderer.sprite = floodedTrees; return; } 

        if (tracker.overworld) {
            if (tracker.neighboursSpawned) sRenderer.sprite = neighbourTrees;
            else sRenderer.sprite = fullworldTrees;
        } 
        else sRenderer.sprite = deadTrees;
    }
}
