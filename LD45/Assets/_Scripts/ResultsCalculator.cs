using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ResultsCalculator : MonoBehaviour
{
    [Header("Objects")]
    [SerializeField] private Text neighbours = null;
    [SerializeField] private Text overworld = null;
    [SerializeField] private Text trees = null;
    [SerializeField] private Text h20 = null;
    [SerializeField] private Text intelligence = null;
    [SerializeField] private Text nucleus = null;
    [SerializeField] private Text grass = null;

    [Space(10)]
    [SerializeField] private string nonExistentText = null;

    [Header("=== OVERWORLD ===")]
    [SerializeField] private string normalText = null;
    [SerializeField] private string floodedText = null;
    [SerializeField] private string deadText = null;

    [Header("=== TREES ===")]
    [SerializeField] private string fullTreesText = null;
    [SerializeField] private string waterTreesText = null;
    [SerializeField] private string deadTreesText = null;
    [SerializeField] private Sprite fullTreesSprite = null;
    [SerializeField] private Sprite maxTreesSprite = null;

    [Header("=== H20 ===")]
    [SerializeField] private string seaText = null;

    [Header("=== INTELLIGENCE ===")]
    [SerializeField] private string deadIntelligenceText = null;
    [SerializeField] private string seaIntelligenceText = null;
    [SerializeField] private Sprite deadIntelligenceSprite = null;

    [Header("=== GRASS ===")]
    [SerializeField] private string normalGrassText = null;
    [SerializeField] private string deadGrassText = null;
    [SerializeField] private string seaGrassText = null;
    [SerializeField] private Sprite deadGrassSprite = null;

    private ObjectTracker tracker;

    private void OnEnable() {
        tracker = FindObjectOfType<ObjectTracker>();

        if (tracker.neighboursSpawned) {
            neighbours.text = "MAX";
            overworld.text = "MAX";
            trees.text = "MAX";
            h20.text = "MAX";
            intelligence.text = "MAX";
            nucleus.text = "MAX";
            grass.text = "MAX";

            return;
        }

        neighbours.text = nonExistentText;
        nucleus.text = tracker.nucleusSpawned ? "MAX" : nonExistentText;

        overworld.text = tracker.floodedworld ? floodedText : normalText;
        overworld.text = tracker.deadworld ? deadText : normalText;

        TreesCalculator();
        H20Calculator();
        IntelligenceCalculator();
        GrassCalculator();
    }

    // METHODS

    private void H20Calculator() {
        if (!tracker.h20Spawned) {
            h20.text = nonExistentText;
            return;
        }

        h20.text = tracker.floodedworld ? seaText : "MAX";
    }

    private void TreesCalculator() {
        if (!tracker.treesSpawned) { trees.text = nonExistentText; return; }
        if (tracker.floodedworld) { trees.text = waterTreesText; return; }
        
        var tsr = FindObjectOfType<Trees>().GetComponent<SpriteRenderer>();
        bool t = tsr.sprite == maxTreesSprite;
        if (t) { trees.text = "MAX"; return; }
        
        
        bool t2 = tsr.sprite == fullTreesSprite;
        if (t2) trees.text = fullTreesText;
        else trees.text = deadTreesText;
    }

    private void IntelligenceCalculator() {
        if (!tracker.intelligenceSpawned) { intelligence.text = nonExistentText; return ;}
        if (tracker.floodedworld) { intelligence.text = seaIntelligenceText; return; }
        
        var isr = FindObjectOfType<Intelligence>().GetComponent<SpriteRenderer>();
        intelligence.text = isr.sprite == deadIntelligenceSprite ? deadIntelligenceText : "MAX";
    }

    private void GrassCalculator() {
        if (!tracker.grassSpawned) { grass.text = nonExistentText; return; }
        if (tracker.floodedworld) { grass.text = seaGrassText; return; }

        var isr = FindObjectOfType<Grass>().GetComponent<SpriteRenderer>();
        if (isr.sprite == deadGrassSprite) { grass.text = deadGrassText; return; }

        grass.text = normalGrassText;
    }
}
