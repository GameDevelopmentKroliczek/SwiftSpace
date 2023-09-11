using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class LoadingScene : MonoBehaviour
{
    public GameObject LoadingScreen;
    public Slider slider;
    public string PlayScene;
    public void LoadScene()
    {
        StartCoroutine(LoadSceneAsync(PlayScene));
    }

    IEnumerator LoadSceneAsync(string SceneName)
    {
        AsyncOperation operation = SceneManager.LoadSceneAsync(SceneName);

        LoadingScreen.SetActive(true);

        while (!operation.isDone)
        {
            float progValue = Mathf.Clamp01(operation.progress / 0.9f);
            slider.value = progValue;

            yield return null;
        }
    }
        
}
