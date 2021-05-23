using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuSwitch : MonoBehaviour
{
    public GameObject player;
    public LevelLoaderScript levelLoader;
    public GameObject currentMenu;
    public GameObject menuObject; //usado por enquanto apenas para o pause menu
    private bool gameIsPaused;
    public void StartNewGame()
    {
        levelLoader.LoadScene("pogScene");
    }
    public void BackToMainMenu()
    {
        levelLoader.LoadScene("MainMenu");
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
    private void Update()
    {
        PauseGame();
    }
    public void PauseGame()
    {
        if(player.GetComponent<FiniteStateMachine>().CurrentState.StateDisplayName != "Dead")
        {
            if (Input.GetKeyDown(KeyCode.Escape))
            {
                if (gameIsPaused)
                {
                    Time.timeScale = 1;
                    gameIsPaused = !gameIsPaused;
                    menuObject.SetActive(false);
                    Cursor.lockState = CursorLockMode.Locked;
                }
                else
                {
                    Time.timeScale = 0;
                    gameIsPaused = true;
                    menuObject.SetActive(true);
                    Cursor.lockState = CursorLockMode.None;
                }
            }
        }
        
    }
}
