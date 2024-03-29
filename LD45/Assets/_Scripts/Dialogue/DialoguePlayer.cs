﻿using System.Collections;
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

    public Text currentTextBox { get; private set; }
    private DialogueSO currentDialogue;
    private Spawner[] buttonList;

    // EXECUTION FUNCTIONS

    private void Start() {
        audioManager = FindObjectOfType<AudioManager>();
        buttonList = FindObjectsOfType<Spawner>();
        PlayDialogue(introDialogue);
    }

    private void Update() {
        if (Input.GetMouseButtonUp(0)) {
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

            currentTextBox = null;
            TriggerButtons(true);

            var bList = FindObjectsOfType<Spawner>();

            foreach (var b in bList) {
                if (b.GetComponent<Button>().interactable == true) return;
            }

            FindObjectOfType<ResultsManager>().ShowResults();

            return;
        }

        Text textBox = textBoxes[currentDialogue.textBoxIndex[currentDialogueIndex]];

        textBox.text = currentDialogue.dialogueTextElements[currentDialogueIndex];
        string currentSound = currentDialogue.dialogueVoiceElements[currentDialogueIndex];
        if (currentSound.Length > 0) audioManager.Play(currentSound);
        textBox.GetComponent<Animator>().Play("Text_Fade_In");

        currentTextBox = textBox;
    }

    public void FadeOut() {
        if (currentTextBox == null) return;
        currentTextBox.GetComponent<Animator>().Play("Text_Fade_Out");
        audioManager.Play("Drop", 3);
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
