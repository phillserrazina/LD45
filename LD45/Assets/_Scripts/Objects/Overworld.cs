using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Overworld : WorldObject
{
    [SerializeField] private Sprite noNucleusSprite = null;
    [SerializeField] private Sprite yesNucleusSprite = null;

    private void Start() {
        var renderer = GetComponent<SpriteRenderer>();

        if (tracker.nucleusSpawned) renderer.sprite = yesNucleusSprite;
        else renderer.sprite = noNucleusSprite;
    }
}
