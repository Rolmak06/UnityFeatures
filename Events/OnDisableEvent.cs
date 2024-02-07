
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class OnDisableEvent : MonoBehaviour
{
   public UnityEvent _onDisableEvent;

   void OnDisable()
   {
       _onDisableEvent?.Invoke();
   }

}
