using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[CreateAssetMenu(menuName="Dialogue", fileName="New Dialogue")]
public class DialogueSO : ScriptableObject {
    [TextArea(1, 3)]
    public string[] dialogueTextElements;
    public string[] dialogueVoiceElements;
    public int[] textBoxIndex;
}
