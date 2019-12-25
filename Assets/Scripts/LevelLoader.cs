using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelLoader : MonoBehaviour {
	private static LevelLoader instance;

	void Awake(){
		if (instance == null)
			instance = this;
		else {
			Destroy (gameObject);
			return;
		}
		DontDestroyOnLoad (gameObject);
	}

	public IEnumerator LoadSyncronously(string sceneName) {
		AsyncOperation operation = SceneManager.LoadSceneAsync (sceneName);
        operation.allowSceneActivation = false;
		while (operation.progress < 0.9f) {
			yield return null;
		}

        Debug.Log("Loaded");
        operation.allowSceneActivation = true;
    }
}