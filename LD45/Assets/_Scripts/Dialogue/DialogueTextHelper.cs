using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogueTextHelper : MonoBehaviour
{
    private DialoguePlayer dialoguePlayer;

    private void Start() {
        dialoguePlayer = FindObjectOfType<DialoguePlayer>();    
    }

    public void CallNextDialogue() {
        dialoguePlayer.NextDialogue();
    }
}
