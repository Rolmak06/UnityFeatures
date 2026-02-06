using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class UIItem : MonoBehaviour, IPointerDownHandler, IBeginDragHandler, IDragHandler, IEndDragHandler
{
    private SO_Item ItemReference;
    [SerializeField] Image icon;
    [SerializeField] TextMeshProUGUI title;

    UISocket currentSocket;

    public void Setup(SO_Item item)
    {
        ItemReference = item;
        icon.sprite = item.Icon;
        title.text = item.Name;
    }
    public void OnPointerDown(PointerEventData eventData)
    {
        if(eventData.button == PointerEventData.InputButton.Right)
        {
            // Create the interactable window 

            // 
        }
    }

    public void OnBeginDrag(PointerEventData eventData)
    {
    }

    public void OnDrag(PointerEventData eventData)
    {

        EvaluateSockets();
    }

    public void OnEndDrag(PointerEventData eventData)
    {
        if(currentSocket != null && currentSocket.CanBeUsed())
        {

        }
    }


    public void EvaluateSockets()
    {

    }
}
