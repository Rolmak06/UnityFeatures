using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

/// <summary>
/// This class allow to trigger an event when all defined conditions (boolean) are true.
/// </summary>
public class MultipleConditionsEvent : MonoBehaviour
{
    [Serializable]
    public class SerializedBool
    {
        public string name;
        public bool state;
    }

    [SerializeField] List<SerializedBool> conditions;
    [SerializeField] UnityEvent OnConditionsFullfiled;
    [SerializeField] bool runOneTime = true;
    bool hasRun;

    public void SetConditionTrue(int index)
    {
        if(conditions.Count < 1)
        {
            return;
        }

        SetCondition(index, true);
    }

    public void SetConditionTrue(string name)
    {
        if(conditions.Count < 1)
        {
            return;
        }

        for (int i = 0; i < conditions.Count; i++)
        {
            if(conditions[i].name == name)
            {
                Debug.LogFormat("Set conditon {0} : {1}", name, true);
                SetCondition(i, true);
            }
        }
    }

    public void SetConditionFalse(string name)
    {
        if(conditions.Count < 1)
        {
            return;
        }

        for (int i = 0; i < conditions.Count; i++)
        {
            if(conditions[i].name == name)
            {
                Debug.LogFormat("Set conditon {0} : {1}", name, false);
                SetCondition(i, false);
            }
        }
    }

    public void SetConditionFalse(int index)
    {
        if(conditions.Count < 1)
        {
            return;
        }
        
        SetCondition(index, false);
    }

    public void SetCondition(int index, bool state)
    {
        conditions[index].state = state;
        CheckConditions();
    }


    public void CheckConditions()
    {
        if(runOneTime && hasRun){return;}

        for (int i = 0; i < conditions.Count; i++)
        {
            if(conditions[i].state == true)
            {
                continue;
            }

            else
            {
                return;
            }
        }

        OnConditionsFullfiled?.Invoke();
        hasRun = true;
    }
}
