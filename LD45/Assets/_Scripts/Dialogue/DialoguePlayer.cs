using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DialoguePlayer : MonoBehaviour
{
    // VARIABLES

    [SerializeField] private DialogueSO introDialogue = null;
    [SerializeField] private Text[] textBoxes = null;
    private int currentDialogueIndex = 0;
    private AudioManager audioManager;

    private Text currentTextBox;
    private DialogueSO currentDialogue;

    // EXECUTION FUNCTIONS

    private void Start() {
        audioManager = FindObjectOfType<AudioManager>();

        PlayDialogue(introDialogue);
    }

    private void Update() {
        if (Input.GetKey(KeyCode.Space)) {
            FadeOut();
        }
    }

    // METHODS

    public void PlayDialogue(DialogueSO dialogue) {
        currentDialogueIndex = 0;
        Text textBox = textBoxes[dialogue.textBoxIndex[currentDialogueIndex]];

        textBox.text = dialogue.dialogueTextElements[currentDialogueIndex];
        textBox.GetComponent<Animator>().Play("Text_Fade_In");

        currentTextBox = textBox;
        currentDialogue = dialogue;
    }

    // TODO: Have this be called at the end of fade out
    public void NextDialogue() {
        currentDialogueIndex++;
        if (currentDialogueIndex >= currentDialogue.dialogueTextElements.Length) {
            if (currentDialogue == introDialogue)
                GameObject.Find("Buttons").GetComponent<Animator>().SetBool("Ready", true);

            return;
        }

        Text textBox = textBoxes[currentDialogue.textBoxIndex[currentDialogueIndex]];

        textBox.text = currentDialogue.dialogueTextElements[currentDialogueIndex];
        textBox.GetComponent<Animator>().Play("Text_Fade_In");

        currentTextBox = textBox;
    }

    public void FadeOut() {
        currentTextBox.GetComponent<Animator>().Play("Text_Fade_Out");
    }
}
