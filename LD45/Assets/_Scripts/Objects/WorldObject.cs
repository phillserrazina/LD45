using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WorldObject : MonoBehaviour
{
    protected ObjectTracker tracker;

    private void Awake() {
        tracker = FindObjectOfType<ObjectTracker>();
    }

    protected void ChangeWorldSprite(Sprite s) {
        var overworld = FindObjectOfType<Overworld>();
        if (overworld == null) {
            Debug.LogError("WorldObject::ChangeWorldSprite(Sprite) --- No Overworld Found!");
            return;
        }

        var renderer = overworld.GetComponent<SpriteRenderer>();
        renderer.sprite = s;
    }
}
