using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bookscript : MonoBehaviour
{
    [SerializeField]
    Animator bookAnimator;
    float timerToReach;
    bool toContinue = false;
    int _currentpage = -2;
    int _targetpage;
    bool bookPlayOne = false;
    // Start is called before the first frame update
    void Start()
    {
        
    }
    public void StartPageTarget(int page)
    {
        toContinue = true;
        _targetpage = page;
        timerToReach = 0;
    }

    // Update is called once per frame
    void Update()
    {
        bookAnimator.SetBool(bookAnimator.GetParameter(1).name, false);
        if (toContinue == true)
        {
            if (timerToReach <= 0)
            {
                Debug.Log("GETIIINNNG");
                MoveToNextPage( _targetpage, out timerToReach);
            }
        }
        timerToReach -= Time.deltaTime;
    }

    private void MoveToNextPage( int targetPage,out float timer)
    {
        if (_currentpage == targetPage)
        {
            toContinue = false;
            timer = 0;
            bookAnimator.SetBool(bookAnimator.GetParameter(1).name, false);
            bookPlayOne = false;
        }
        else
        {
            if (_currentpage > targetPage)
            {
                bookAnimator.SetFloat(bookAnimator.GetParameter(2).name, -1);
                _currentpage--;
            }
            else if (_currentpage < targetPage)
            {
                bookAnimator.SetFloat(bookAnimator.GetParameter(2).name, 1);
      //          bookAnimator.speed = -1;
                _currentpage++;
            }
            bookPlayOne = true;
            bookAnimator.SetInteger(bookAnimator.GetParameter(0).name, _currentpage);
            bookAnimator.SetBool(bookAnimator.GetParameter(1).name,true);
            timer = 0.5f;
        }
    }

}
