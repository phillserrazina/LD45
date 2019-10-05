using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class DialoguePlayer : MonoBehaviour
{
    // VARIABLES

    [SerializeField] private DialogueSO introDialogue = null;
    [SerializeField] private Text[] textBoxes = null;
    private int currentDialogueIndex = 0;
    private AudioManager audioManager;

    private Text currentTextBox;
    private DialogueSO currentDialogue;
    private Spawner[] buttonList;

    // EXECUTION FUNCTIONS

    private void Start() {
        audioManager = FindObjectOfType<AudioManager>();
        buttonList = FindObjectsOfType<Spawner>();
        PlayDialogue(introDialogue);
    }

    private void Update() {
        if (Input.GetMouseButton(0)) {
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

        TriggerButtons(false);
    }

    // TODO: Have this be called at the end of fade out
    public void NextDialogue() {
        currentDialogueIndex++;
        if (currentDialogueIndex >= currentDialogue.dialogueTextElements.Length) {
            if (currentDialogue == introDialogue)
                GameObject.Find("Buttons").GetComponent<Animator>().SetBool("Ready", true);

            TriggerButtons(true);
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

    private void TriggerButtons(bool active) {
        foreach (var b in buttonList) {
            var button = b.GetComponent<Button>();
            var eTrigger = b.GetComponent<EventTrigger>();

            if (button.interactable == true) button.enabled = active;
            if (eTrigger != null) eTrigger.enabled = active;
        }
    }
}
