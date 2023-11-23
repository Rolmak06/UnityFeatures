
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class OnDisabler : MonoBehaviour
{
   public UnityEvent DisableEvent;


   void OnDisable()
   {
        DisableEvent?.Invoke();
   }

}
