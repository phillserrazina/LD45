using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ResultColorChanger : MonoBehaviour
{
    public Color color;
    private Text t;

    private void Start() {
        t = GetComponent<Text>();
    }

    private void Update() {
        if (t.text == "MAX") t.color = color;
    }
}
