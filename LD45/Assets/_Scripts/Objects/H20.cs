using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class H20 : WorldObject
{
    [SerializeField] private Sprite worldWithH20 = null;

    private void Start()
    {
        if (!tracker.overworldSpawned) return;
        else ChangeWorldSprite(worldWithH20);
    }
}
