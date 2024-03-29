
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class OnDisableUnityEvent : MonoBehaviour
{
   public UnityEvent _onDisableUnityEvent;

   void OnDisable()
   {
       _onDisableUnityEvent?.Invoke();
   }

}
