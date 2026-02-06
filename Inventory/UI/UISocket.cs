using UnityEngine;
using UnityEngine.EventSystems;

public class UISocket : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    public void OnPointerEnter(PointerEventData eventData)
    {
    }

    public void OnPointerExit(PointerEventData eventData)
    {
    }

    public bool CanBeUsed()
    {
        return true;
    }
}
