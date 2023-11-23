using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class ColliderListener : MonoBehaviour
{

// [HideInInspector]
    public List<InvokeManager.TagInvoke> TagInvokes;
// [HideInInspector]
    public InvokeManager.TagInvoke theOne;

// [HideInInspector]
    public InvokeManager Manager;
    
    public int tagCount;

// [HideInInspector]
   public List<string> tagList;

   public bool onCollision;

   public bool onTrigger = true;
   
    //public List<string> tagList;
    // Start is called before the first frame update
 
    
    void OnTriggerEnter(Collider entity){
         if(onTrigger){

    for(int i = 0; i< tagCount; i++){

    if (entity.gameObject.CompareTag(tagList[i])){ //Si un objet possède un tag de la liste on continue
        Debug.Log("On compare avec " + tagList[i]);

        foreach(InvokeManager.TagInvoke invoke in TagInvokes){ //On regarde les différents TagInvoke qui ont été attribué au collider 
            for(int x = 0; x<invoke.TagList.Count; x++){
                
                if (entity.gameObject.CompareTag(invoke.TagList[x])){ //Si l'objet qui collide possède le tag défini par l'un des TagInvoke, on le définit comme le bon et on appelle son event. 

                    theOne = invoke; //On choisit le bon invoke à jouer en fonction des tags. 
                    if(!theOne.canRun){return;}
                    Manager.Hit(this); //On appelle la fonction du Manager avec ce collider en paramètre. 
                    string tag = invoke.TagList[x];
                    Debug.Log(this.name + " Collide avec un objet taggué : " + tag);
                }
            }
        }
    }
    }
    }
    }

    void OnCollisionEnter(Collision entity){
        if(onCollision){
        for(int i = 0; i< tagCount; i++){

            if (entity.gameObject.CompareTag(tagList[i])){ //Si un objet possède un tag de la liste on continue
                Debug.Log("On compare avec " + tagList[i]);

                foreach(InvokeManager.TagInvoke invoke in TagInvokes){ //On regarde les différents TagInvoke qui ont été attribué au collider 
                    for(int x = 0; x<invoke.TagList.Count; x++){
                        
                        if (entity.gameObject.CompareTag(invoke.TagList[x])){ //Si l'objet qui collide possède le tag défini par l'un des TagInvoke, on le définit comme le bon et on appelle son event. 

                            theOne = invoke;
                            if(!theOne.canRun){return;}
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
}

