using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuManager : MonoBehaviour
{
    private void Start() {
        string filePath = Application.persistentDataPath + "/" + "Config.json";

		if (System.IO.File.Exists(filePath) == false) {
			System.IO.File.Create(filePath).Close();
			AudioSettingsUI.CreateNewSettingsFile();
		}

		AudioSettingsData audioData = AudioSettingsUI.ReadData(filePath);

		AudioManager audioManager = FindObjectOfType<AudioManager>();
		audioManager.audioMixer.SetFloat("generalVolume", audioData.generalVolume);
		audioManager.audioMixer.SetFloat("musicVolume", audioData.musicVolume);
		audioManager.audioMixer.SetFloat("sfxVolume", audioData.vfxVolume);

		QualitySettings.vSyncCount = 0;
		Application.targetFrameRate = 30;

        if (SceneManager.GetActiveScene().buildIndex == 0) {
            FindObjectOfType<AudioManager>().Play("Intro Music");
        }
    }

    public void GoToScene(string scene) {
        FindObjectOfType<MenuButtonsHelper>().ChooseScene(scene);
    }

    public void QuitGame() {
        Application.Quit();
    }

    public void OpenGit() {
        Application.OpenURL("https://github.com/phillserrazina");
    }

    public void OpenTwitter() {
        Application.OpenURL("https://twitter.com/PhillTalksAbout");
    }
 }
