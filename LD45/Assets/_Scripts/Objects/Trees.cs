﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Trees : WorldObject
{
    [SerializeField] private Sprite fullworldTrees = null;
    [SerializeField] private Sprite neighbourTrees = null;
    [SerializeField] private Sprite deadTrees = null;
    [SerializeField] private Sprite floodedTrees = null;
    [Space(10)]
    [SerializeField] private DialogueSO noWorldDialogue = null;
    [SerializeField] private DialogueSO fullworldGrassDialogue = null;
    [SerializeField] private DialogueSO fullworldNoGrassDialogue = null;
    [SerializeField] private DialogueSO deadTreesDialogue = null;
    [SerializeField] private DialogueSO waterTreesDialogue = null;
    [Space(10)]
    [SerializeField] private Sprite neededGrassSprite = null;
    [SerializeField] private Sprite neededIntelligenceSprite = null;

    private void Start() {
        if (!tracker.overworldSpawned) {
            dialoguePlayer.PlayDialogue(noWorldDialogue);
            Destroy(gameObject); 
            return;
        }
        if (tracker.floodedworld) {
            sRenderer.sprite = floodedTrees;
            dialoguePlayer.PlayDialogue(waterTreesDialogue);
            return;
        }

        if (tracker.overworld) {
            sRenderer.sprite = fullworldTrees;
            var g = FindObjectOfType<Grass>();
            if (g == null) dialoguePlayer.PlayDialogue(fullworldNoGrassDialogue);
            else {
                if (g.GetComponent<SpriteRenderer>().sprite == neededGrassSprite) dialoguePlayer.PlayDialogue(fullworldGrassDialogue);
                else dialoguePlayer.PlayDialogue(fullworldNoGrassDialogue);
            }
        } 
        else {
            sRenderer.sprite = deadTrees;
            dialoguePlayer.PlayDialogue(deadTreesDialogue);
        }
    }

    public override void UpdateObject() {
        if (!tracker.overworld) return;
        if (sRenderer.sprite == deadTrees) return;

        var i = FindObjectOfType<Intelligence>();
        if (i == null) return;
        if (i.GetComponent<SpriteRenderer>().sprite != neededIntelligenceSprite) return;

        if (tracker.neighboursSpawned) sRenderer.sprite = neighbourTrees;
        else sRenderer.sprite = fullworldTrees;
    }
}
