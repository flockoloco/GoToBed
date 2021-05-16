using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using TMPro;
using UnityEngine;

public class LevelLoaderScript : MonoBehaviour
{
    public void LoadScene (string sceneName)
    {
        StartCoroutine(LoadAsynchronously(sceneName)); 
    }

    IEnumerator LoadAsynchronously(string sceneName)
    {
        AsyncOperation loadOperation = SceneManager.LoadSceneAsync(sceneName);

        //ativar loading screen ou algo do genero

        while (!loadOperation.isDone)
        {
            //do animation or load bar or both

            yield return null;
        }
    }
}
