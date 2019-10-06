using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Audio;

public class AudioSettingsUI : MonoBehaviour
{
    // VARIABLES

    private AudioMixer audioMixer;

    [SerializeField] private Slider generalSlider = null;
    [SerializeField] private Slider musicSlider = null;
    [SerializeField] private Slider vfxSlider = null;

    private static float currentGeneralVolume;
    private static float currentMusicVolume;
    private static float currentVFXVolume;

    private static string filePath;

    // EXECUTION METHODS

    private void Awake() {
        filePath = Application.persistentDataPath + "/Config.json";
        audioMixer = FindObjectOfType<AudioManager>().audioMixer;

        InitData();
    }

    // METHODS

    public void RestoreDefaults() {
        currentGeneralVolume = 20f;
        currentMusicVolume = 0f;
        currentVFXVolume = 0f;

        generalSlider.value = 20f;
        musicSlider.value = 0f;
        vfxSlider.value = 0f;

        audioMixer.SetFloat("generalVolume", 20f);
        audioMixer.SetFloat("musicVolume", 0f);
        audioMixer.SetFloat("sfxVolume", 0f);

        filePath = Application.persistentDataPath + "/Config.json";

        Save(filePath);
    }

    public void SetGeneral(float val) {
        audioMixer.SetFloat("generalVolume", val);
        currentGeneralVolume = val;
        filePath = Application.persistentDataPath + "/Config.json";
        Save(filePath);
    }

    public void SetMusic(float val) {
        audioMixer.SetFloat("musicVolume", val);
        currentMusicVolume = val;
        filePath = Application.persistentDataPath + "/Config.json";
        Save(filePath);
    }

    public void SetVfx(float val) {
        audioMixer.SetFloat("sfxVolume", val);
        currentVFXVolume = val;
        filePath = Application.persistentDataPath + "/Config.json";
        Save(filePath);
    }

    public static AudioSettingsData CreateNewSettingsFile() {
		AudioSettingsData audioData = new AudioSettingsData();
        audioData.CreateDefault();

        filePath = Application.persistentDataPath + "/Config.json";

		Save(filePath, audioData);
        return audioData;
	}

    private static void Save(string path, AudioSettingsData audioSettings=null) {

        if (System.IO.File.Exists(path) == false) {
			Debug.LogError("Unable to read file at " + path + "; File does not exist");
			return;
		}

        if (audioSettings == null) {
            audioSettings = ReadData(path);
        
            if (audioSettings == null)
                audioSettings = CreateNewSettingsFile();
        }

        audioSettings.generalVolume = currentGeneralVolume;
        audioSettings.musicVolume = currentMusicVolume;
        audioSettings.vfxVolume = currentVFXVolume;

		// Form contents, encrypt them and write them to the file
		string contents = JsonUtility.ToJson(audioSettings, true);
		System.IO.File.WriteAllText (path, contents);
    }

    public static AudioSettingsData ReadData(string path) {
		if (System.IO.File.Exists(path) == false) {
			Debug.LogError("Unable to read file at " + path + "; File does not exist");
			return null;
		}

		// Get file and decrypt them contents
		string contents = System.IO.File.ReadAllText(path);

		// Get game data from retrieved file
		AudioSettingsData data = JsonUtility.FromJson<AudioSettingsData>(contents);

		if (data == null) {
			Debug.LogError("File at " + path + " is corrupted! No file was found");
			return null;
		}

		return data;
	}

    private void InitData() {
		AudioSettingsData audioSettingsData = ReadData(filePath);

        if (audioSettingsData == null)
            audioSettingsData = CreateNewSettingsFile();
        
        AudioSettingsData data = audioSettingsData;

        currentGeneralVolume = data.generalVolume;
        currentMusicVolume = data.musicVolume;
        currentVFXVolume = data.vfxVolume;

        generalSlider.value = currentGeneralVolume;
        musicSlider.value = currentMusicVolume;
        vfxSlider.value = currentVFXVolume;
	}
}

