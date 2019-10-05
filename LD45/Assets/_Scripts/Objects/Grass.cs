using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Grass : WorldObject
{
    [SerializeField] private Sprite normalGrass = null;
    [SerializeField] private Sprite neighbourGrass = null;
    [SerializeField] private Sprite deadGrass = null;
    [Space(10)]
    [SerializeField] private DialogueSO noWorldDialogue = null;
    [SerializeField] private DialogueSO floodedDialogue = null;
    [SerializeField] private DialogueSO normalGrassWithTreesDialogue = null;
    [SerializeField] private DialogueSO normalGrassNoTreesDialogue = null;
    [SerializeField] private DialogueSO deadGrassDialogue = null;
    [Space(10)]
    [SerializeField] private Sprite neededTreeSprite = null;

    private void Start() {
        if (!tracker.overworldSpawned) {
            dialoguePlayer.PlayDialogue(noWorldDialogue);
            Destroy(gameObject); 
            return; 
        }
        if (tracker.floodedworld) { 
            dialoguePlayer.PlayDialogue(floodedDialogue);
            return; 
        }

        if (tracker.deadworld) {
            dialoguePlayer.PlayDialogue(deadGrassDialogue);
            sRenderer.sprite = deadGrass;
            return;
        }
        
        if (!tracker.h20Spawned) {
            dialoguePlayer.PlayDialogue(deadGrassDialogue);
            sRenderer.sprite = deadGrass;
            return;
        }

        var t = FindObjectOfType<Trees>();
        if (t == null) dialoguePlayer.PlayDialogue(normalGrassNoTreesDialogue);
        else {
            if (t.GetComponent<SpriteRenderer>().sprite == neededTreeSprite) dialoguePlayer.PlayDialogue(normalGrassWithTreesDialogue);
            else dialoguePlayer.PlayDialogue(normalGrassNoTreesDialogue);
        }
        sRenderer.sprite = normalGrass;
    }

    public override void UpdateObject() {
        if (tracker.neighboursSpawned) sRenderer.sprite = neighbourGrass;
        else sRenderer.sprite = normalGrass;
    }
}
