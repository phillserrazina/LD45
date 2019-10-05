using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;

public class MenuButtonsHelper : MonoBehaviour
{
    private string currentScene;

    public void ChooseScene(string scene) {
        foreach (var b in FindObjectsOfType<Button>()) {
            b.GetComponent<EventTrigger>().enabled = false;
        }

        currentScene = scene;
        GetComponent<Animator>().Play("Out");
    }

    public void GoToScene() {
        SceneManager.LoadScene(currentScene);
    }
}
