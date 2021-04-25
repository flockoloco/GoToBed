using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
[CreateAssetMenu(menuName = "Finite State Machine/Actions/Player/Concealment Calculation Action")]
public class ConcealmentCalculationsAction : Action 
{
    public override void Act(FiniteStateMachine fsm, PlayerStats playerStats)
    {
        float _valuePostCalc = Calculation(playerStats);
        if (fsm.CurrentState.name == "Stand")
        {
            playerStats.ConcealmentValue = _valuePostCalc;
        }
        else if(fsm.CurrentState.name == "Crouch")
        {
            playerStats.ConcealmentValue = _valuePostCalc /2;
        }
        else if(fsm.CurrentState.name == "Run")
        {
            playerStats.ConcealmentValue = _valuePostCalc * 2;
        }
    }
    public override void Act(FiniteStateMachine fsm, EnemyStats enemyStats)
    {
        throw new System.NotImplementedException();
    }
    public override void Act(FiniteStateMachine fsm, PlayerStats playerStats, EnemyStats[] allEnemyStats)
    {
        throw new System.NotImplementedException();
    }
    private float Calculation(PlayerStats playerStats)
    {
        int _numberOfLights = playerStats.LightsInRange.Count;
        List<float> _valueList = new List<float>();
        float _maximumValue = 1000;
        float _highestValue = 0;
        float _finalValue = 0;
        int _currentIndex = 0;

        foreach (GameObject light in playerStats.LightsInRange)
        {
            
            _valueList.Add(light.GetComponent<LightObjectInfo>().LightPotency  / Mathf.Pow(Vector3.Distance(light.transform.position, playerStats.transform.position),2));
            if (_valueList[_currentIndex] > _highestValue)
            {
                _highestValue = _valueList[_currentIndex];
            }
            _currentIndex++;
        }
        if (_numberOfLights > 1)
        {
            if (_highestValue < _maximumValue)
            {
                List<float> _sortedList = _valueList.OrderBy(o => o).ToList();
                int _progressiveDecay = 1;
                foreach (float _value in _sortedList)
                {
                    _finalValue += _value * _progressiveDecay;
                    _progressiveDecay /= 2;
                }

            }
            else
            {
                _finalValue = _maximumValue; 
            }
        }
        else
        {
            if (_highestValue > _maximumValue)
            {
                return _maximumValue;
            }
            return _highestValue;
        }
        if ( _finalValue > _maximumValue)
        {
            return _maximumValue;
        }
        else
        {
            return _finalValue;
        }
    }

}
