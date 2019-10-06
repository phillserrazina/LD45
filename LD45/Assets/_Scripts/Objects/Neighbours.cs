using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Neighbours : WorldObject
{
    [SerializeField] private Sprite worldFinal = null;
    [SerializeField] private Sprite neededSprite = null;

    [Space(10)]
    [SerializeField] private DialogueSO readyDialogue = null;
    [SerializeField] private DialogueSO notReadyDialogue = null;

    private void Start() {
        if (!tracker.overworldSpawned) {
            dialoguePlayer.PlayDialogue(notReadyDialogue);
            Destroy(gameObject); 
            return; 
        }

        var i = FindObjectOfType<Intelligence>();
        if (i == null) {
            dialoguePlayer.PlayDialogue(notReadyDialogue);
            Destroy(gameObject); 
            return; 
        }

        var iRenderer = i.GetComponent<SpriteRenderer>().sprite;

        if (iRenderer == neededSprite) {
            dialoguePlayer.PlayDialogue(readyDialogue);
            sRenderer.sprite = worldFinal;
        } 
        else {
            dialoguePlayer.PlayDialogue(notReadyDialogue);
            Destroy(gameObject); 
            return; 
        }
    }

    public override void UpdateObject() {
        
    }
}
