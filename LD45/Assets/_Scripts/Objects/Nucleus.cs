using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Nucleus : WorldObject
{
    [SerializeField] private DialogueSO nucleusFirstDialogue = null;
    [SerializeField] private DialogueSO nucleusSecondDialogue = null;

    private void Start() {
        if (tracker.overworldSpawned) {
            dialoguePlayer.PlayDialogue(nucleusSecondDialogue);
            Destroy(gameObject);
            return;
        }

        dialoguePlayer.PlayDialogue(nucleusFirstDialogue);
    }

    public override void UpdateObject() {

    }
}
