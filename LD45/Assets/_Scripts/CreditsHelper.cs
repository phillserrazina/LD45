using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CreditsHelper : MonoBehaviour
{
    public void Out(string animName) {
        GetComponent<Animator>().Play(animName);
    }

    public void Exit() {
        SceneManager.LoadScene("InGameMainMenu");
    }
}
