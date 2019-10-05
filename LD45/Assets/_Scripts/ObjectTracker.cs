using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectTracker : MonoBehaviour {
    public bool neighboursSpawned { get { return (FindObjectOfType<Neighbours>() != null); } }
    public bool overworldSpawned { get { return (FindObjectOfType<Overworld>() != null); } }
    public bool treesSpawned { get { return (FindObjectOfType<Trees>() != null); } }
    public bool h20Spawned { get { return (FindObjectOfType<H20>() != null); } }
    public bool intelligenceSpawned { get { return (FindObjectOfType<Intelligence>() != null); } }
    public bool nucleusSpawned { get { return (FindObjectOfType<Nucleus>() != null); } }
    public bool grassSpawned { get { return (FindObjectOfType<Grass>() != null); } }

    [SerializeField] private Sprite overworldSprite = null;
    [SerializeField] private Sprite deadworldSprite = null;
    [SerializeField] private Sprite floodeworldSprite = null;

    public bool overworld {
        get {
            if (!overworldSpawned) return false;
            return currentWorldSprite == overworldSprite;
        }
    }

    public bool deadworld { 
        get {
            if (!overworldSpawned) return false;
            return currentWorldSprite == deadworldSprite;
        }
    }

    public bool floodedworld { 
        get {
            if (!overworldSpawned) return false;
            return currentWorldSprite == floodeworldSprite;
        }
    }

    private Sprite currentWorldSprite { 
        get {
            if (!overworldSpawned) return null;
            return FindObjectOfType<Overworld>().GetComponent<SpriteRenderer>().sprite;
        }
    }
}
