using System.Collections.Generic;
using UnityEngine;

public class ColliderListener : MonoBehaviour
{
    [HideInInspector] public List<InvokeManager.TagInvoke> TagInvokes;
    [HideInInspector] public InvokeManager.TagInvoke tagInvoke;
    [HideInInspector] public InvokeManager Manager;
    [HideInInspector] public int tagCount;
    [HideInInspector] public List<string> tagList;

    [Tooltip("Is the listener sending message on Collision ?")] public bool onCollision;
    [Tooltip("Is the listener sending message on Trigger ?")] public bool onTrigger = true;
    
    void OnTriggerEnter(Collider entity){
         if(onTrigger)
        {
            CheckForEvent(entity.gameObject);
        }
    }


    void OnCollisionEnter(Collision entity)
    {
        if(onCollision)
        {
            CheckForEvent(entity.gameObject);
        }
    }

    /// <summary>
    /// Checks if the entity gameobject is triggering an event. If so, we send a message to the manager.
    /// </summary>
    /// <param name="entity"></param>
    private void CheckForEvent(GameObject entity)
    {
        for (int i = 0; i < tagCount; i++)
        {
            if (entity.gameObject.CompareTag(tagList[i]))
            {
                Debug.Log("On compare avec " + tagList[i]);

                foreach (InvokeManager.TagInvoke invoke in TagInvokes)
                {
                    for (int x = 0; x < invoke.TagList.Count; x++)
                    {
                        if (entity.gameObject.CompareTag(invoke.TagList[x]))
                        {
                            tagInvoke = invoke;
                            if (!tagInvoke.canRun) { return; }
                            Manager.Hit(this);
                            string tag = invoke.TagList[x];
                            Debug.Log(this.name + " Collide avec un objet taggué : " + tag);
                        }
                    }
                }
            }
        }
    }
}

