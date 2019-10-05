using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class WorldObject : MonoBehaviour
{
    protected ObjectTracker tracker;

    protected SpriteRenderer sRenderer;

    private void Awake() {
        tracker = FindObjectOfType<ObjectTracker>();
        sRenderer = GetComponent<SpriteRenderer>();
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

    public abstract void UpdateObject();
}
