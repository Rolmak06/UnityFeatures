using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class InvokeManager : MonoBehaviour
{
    //Lorsqu'un collider est touché, il envoie un événement au manager qui récupère le collider puis l'invoke associé 

    [TextArea]
    public string Note; //Pour ajouter des notes on sait jamais, ça peut être utile vu que ça risque d'être un gros script utilisé pour diverses choses. 
    
    [System.Serializable]
    public class TagInvoke
    {
        [Tooltip("Il s'agit du collider qui s'occupera des détections. Ils doivent avoir le script Collider Listener sur eux.")]
        public List<ColliderListener> colList;
        //Liste des colliders
        public List<string> TagList;
        //Liste des tags qui déclencheront les événements ci dessous

        public UnityEvent tagEvent;

        public bool runOnce;
        public bool hasRun = false;

        public bool delay;
        public bool canRun = true;
        public float delayTime;
        //L'invoke lié aux éléments ci-dessus

        //public float delay = 0f; -> A voir pour ajouter un délai à l'invoke. 

         public void InvokeTag()
         {
            tagEvent.Invoke();
         }
    }

    public List <TagInvoke> ColliderTagInvoke;

    void OnEnable(){
        foreach(TagInvoke item in ColliderTagInvoke){
            foreach(ColliderListener col in item.colList){
           
            col.Manager = this; //Si on a mis un collider dans les TagInvoke, ce script deviendra automatiquement leur manager. 
            col.TagInvokes.Add(item); //On ajoute les TagInvoke au collider pour qu'il sache quoi regarder.
            col.tagList.AddRange(item.TagList); //On ajoute la liste des tags des différents invokes qui concernent le collider. 
            col.tagCount = col.tagList.Count;
            //item.col.tagList = item.TagList;
    
            Debug.Log(col.name + "est setup avec les valeurs attribuées");
            }
        }
    }


    public void Hit(ColliderListener col)
    { //On récupère le hit envoyé par le collider et on récupère l'event à jouer puis on l'invoke ! 
        if(col.theOne.hasRun && col.theOne.runOnce){return;}
        if(!col.theOne.canRun){return;}
        col.theOne.InvokeTag();
        col.theOne.hasRun = true;

        if(col.theOne.delay)
        {
        StartCoroutine(WaitBeforeLaunch(col.theOne));
        }
    }

    private IEnumerator WaitBeforeLaunch(TagInvoke theOne)
    {
        //float timeElapsed = 0f;
        
        theOne.canRun = false;
        
        yield return new WaitForSeconds(theOne.delayTime);
        
        theOne.canRun = true;
    }

}
