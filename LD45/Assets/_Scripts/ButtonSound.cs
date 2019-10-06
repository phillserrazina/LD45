using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class ButtonSound : MonoBehaviour, IPointerEnterHandler, IPointerUpHandler
{
    [SerializeField] private string soundName = null;
    [SerializeField] private int randomSoundIndex = -1;
    [SerializeField] private string clickSoundName = null;
    [SerializeField] private int randomClickSoundIndex = -1;
    private AudioManager audioManager;

    private void Start() {
        audioManager = FindObjectOfType<AudioManager>();
    }

    public void OnPointerEnter(PointerEventData eventData) {
        if (GetComponent<Button>().interactable == false) return;
        var dp = FindObjectOfType<DialoguePlayer>();

        if (dp != null) {
            if (dp.currentTextBox != null)
                return;
        }

        if (soundName != null) audioManager.Play(soundName, randomSoundIndex);
    }

    public void OnPointerUp(PointerEventData eventData) {
        if (GetComponent<Button>().interactable == false) return;
        var dp = FindObjectOfType<DialoguePlayer>();

        if (dp != null) {
            if (dp.currentTextBox != null)
                return;
        }
        
        if (clickSoundName != null) audioManager.Play(clickSoundName, randomClickSoundIndex);
    }
}
