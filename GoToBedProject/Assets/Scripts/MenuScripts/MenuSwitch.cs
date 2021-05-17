using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuSwitch : MonoBehaviour
{
    public LevelLoaderScript levelLoader;
    public GameObject currentMenu;
    public void StartNewGame()
    {
        levelLoader.LoadScene("pogScene");
    }

    public void TurnOffOnCanvas(GameObject targetCanvas)
    {
        currentMenu.SetActive(false);
        targetCanvas.SetActive(true);
    }

    public void QuitGame()
    {
        Application.Quit();
    }
}
