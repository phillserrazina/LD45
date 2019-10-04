using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WorldObject : MonoBehaviour
{
    protected ObjectTracker tracker;

    private void Awake() {
        tracker = FindObjectOfType<ObjectTracker>();
    }
}
