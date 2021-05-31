using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class canvasScript : MonoBehaviour
{
    [SerializeField]
    private DoorScript _door;
    [SerializeField]
    private List<Canvas> _canvasList;
    [SerializeField]
    NewMenuCameraScript _cameraScript;
    [SerializeField]
    private List<GameObject> _hoverInteractionList;
    [SerializeField]
    private GameObject _doorLamp;
    private void Start()
    {
        Time.timeScale = 1;
        ChangeCanvasScript(0);
    }
    public void ChangeCanvasScript(int menuNumber)
    {
        Debug.Log("omomom");
        for (int i = 0; i < _canvasList.Count; i++)
        {
            Debug.Log(i + " that the i " + menuNumber);
            if (i == menuNumber)
            {
                Debug.Log("hellO!!");
                _canvasList[i].enabled = true;
                _cameraScript.GoToWayPoint(i);
                //open animation
            }
            else
            {
                _canvasList[i].enabled = false;
                //close animation
            }
        }
    }
    public void MouseEnteringButton(int numberOfObject)
    {
        switch (numberOfObject)
        {
            case 0: //door object hover
                //do door hover entry animation
                _hoverInteractionList[numberOfObject].SetActive(true);
                break;
            case 1:
                _hoverInteractionList[numberOfObject].SetActive(true);
                break;
            case 2:
                _hoverInteractionList[numberOfObject].SetActive(true);
                break;
            case 3:
                _hoverInteractionList[numberOfObject].SetActive(true);
                break;
            default:
                _hoverInteractionList[numberOfObject].SetActive(true);
                break;
        }

    }
    public void MouseExitingButton(int numberOfObject)
    {
        switch (numberOfObject)
        {
            case 0: //door object hover
                //do door hover exit animation
                _hoverInteractionList[numberOfObject].SetActive(false);
                break;
            case 1:
                _hoverInteractionList[numberOfObject].SetActive(false);
                break;
            case 2:
                _hoverInteractionList[numberOfObject].SetActive(false);
                break;
            case 3:
                _hoverInteractionList[numberOfObject].SetActive(false);
                break;
            default:
                _hoverInteractionList[numberOfObject].SetActive(false);
                break;
        }

    }
    public void OpenTheDoor()
    {
        _doorLamp.SetActive(true);
        _door.DoorInteraction();
    }


    public void QuitGame()
    {
        Application.Quit();
    }
}
