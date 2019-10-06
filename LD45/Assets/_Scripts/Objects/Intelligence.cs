using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Intelligence : WorldObject
{
    [SerializeField] private Sprite overworldIntelligence = null;
    [SerializeField] private Sprite deadworldIntelligence = null;
    [SerializeField] private Sprite floodedworldIntelligence = null;

    [SerializeField] private Sprite treesNeededSprite = null;
    [SerializeField] private Sprite grassNeededSprite = null;

    [Space(10)]
    [SerializeField] private DialogueSO noWorldDialogue = null;
    [SerializeField] private DialogueSO floodedNotEnoughOxygenDialogue = null;
    [SerializeField] private DialogueSO floodedDialogue = null;
    [SerializeField] private DialogueSO notEnoughOxygenDialogue = null;
    [SerializeField] private DialogueSO deadworldDialogue = null;
    [SerializeField] private DialogueSO overworldDialogue = null;

    private void Start() {
        if (!tracker.overworldSpawned) {
            dialoguePlayer.PlayDialogue(noWorldDialogue);
            Destroy(gameObject); 
            return; 
        }

        var t = FindObjectOfType<Trees>();
        var g = FindObjectOfType<Grass>();

        if (tracker.floodedworld) { 
            
            if (t == null) {
                dialoguePlayer.PlayDialogue(floodedNotEnoughOxygenDialogue);
                Destroy(gameObject);
                return; 
            }

            if (g == null) {
                dialoguePlayer.PlayDialogue(floodedNotEnoughOxygenDialogue);
                Destroy(gameObject);
                return; 
            }

            dialoguePlayer.PlayDialogue(floodedDialogue); 
            sRenderer.sprite = floodedworldIntelligence; 
            return; 
        }

        if (tracker.deadworld) {
            dialoguePlayer.PlayDialogue(deadworldDialogue);
            sRenderer.sprite = deadworldIntelligence; 
            return; 
        }

        if (t == null) {
            dialoguePlayer.PlayDialogue(notEnoughOxygenDialogue);
            sRenderer.sprite = deadworldIntelligence; 
            return; 
        }

        if (g == null) {
            dialoguePlayer.PlayDialogue(notEnoughOxygenDialogue);
            sRenderer.sprite = deadworldIntelligence; 
            return; 
        }

        var ts = t.GetComponent<SpriteRenderer>().sprite;
        var gs = g.GetComponent<SpriteRenderer>().sprite;

        if (ts == treesNeededSprite && gs == grassNeededSprite) {
            dialoguePlayer.PlayDialogue(overworldDialogue);
            sRenderer.sprite = overworldIntelligence;
        }
        else {
            dialoguePlayer.PlayDialogue(deadworldDialogue);
            sRenderer.sprite = deadworldIntelligence;
        }
    }

    public override void UpdateObject() {
        
    }
}
