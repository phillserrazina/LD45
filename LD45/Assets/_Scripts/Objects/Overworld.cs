using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Overworld : WorldObject
{
    [SerializeField] private Sprite noNucleusSprite = null;
    [SerializeField] private Sprite yesNucleusSprite = null;

    [SerializeField] private DialogueSO yesNucleusDialogue = null;
    [SerializeField] private DialogueSO noNucleusDialogue = null;

    private void Start() {
        var renderer = GetComponent<SpriteRenderer>();

        if (tracker.nucleusSpawned) {
            renderer.sprite = yesNucleusSprite;
            dialoguePlayer.PlayDialogue(yesNucleusDialogue);
        } 
        else {
            renderer.sprite = noNucleusSprite;
            dialoguePlayer.PlayDialogue(noNucleusDialogue);
        } 
    }

    public override void UpdateObject() {

    }
}
