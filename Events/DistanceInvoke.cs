using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class DistanceInvoke : MonoBehaviour
{
    [SerializeField] float distance;
    [SerializeField] Transform target;

    UnityEvent InDistance;
    UnityEvent OutDistance;
    bool invokeIn = false;
    bool invokeOut = false;

    [Tooltip("Update per second")] public float updateRate;
    float lastUpdateTime;


    void Update()
    {
        if(Time.time - lastUpdateTime < 1/updateRate){return;}

        if(Vector3.Distance(transform.position, target.position) < distance)
        {
            //In
            if(!invokeIn)
            {
                InDistance?.Invoke();
                invokeIn = true;
            }
        }

        else
        {
            //Out
            if(!invokeOut)
            {
                OutDistance?.Invoke();
                invokeOut = true;
            }
        }

        lastUpdateTime = Time.time;
    }
}
