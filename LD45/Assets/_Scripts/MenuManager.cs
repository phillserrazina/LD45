using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuManager : MonoBehaviour
{
    public void GoToScene(string scene) {
        FindObjectOfType<MenuButtonsHelper>().ChooseScene(scene);
    }

    public void QuitGame() {
        Application.Quit();
    }
}
