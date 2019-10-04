using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectTracker : MonoBehaviour {
    public bool neighboursSpawned { get { return (FindObjectOfType<Neighbours>() != null); } }
    public bool overworldSpawned { get { return (FindObjectOfType<Overworld>() != null); } }
    public bool treesSpawned { get { return (FindObjectOfType<Trees>() != null); } }
    public bool hutsSpawned { get { return (FindObjectOfType<Huts>() != null); } }
    public bool iceSpawned { get { return (FindObjectOfType<Ice>() != null); } }
    public bool nucleusSpawned { get { return (FindObjectOfType<Nucleus>() != null); } }
    public bool geographySpawned { get { return (FindObjectOfType<Geography>() != null); } }
}
