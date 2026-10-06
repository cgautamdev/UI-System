using UnityEngine;
using UnityEngine.EventSystems;

public abstract class CustomUIButton : MonoBehaviour, IPointerClickHandler, IPointerEnterHandler, IPointerExitHandler
{
    #region Button Events
    // button click event
    public void OnPointerClick(PointerEventData eventData)
    {
        HandlePointerClick(eventData);
    }

    // mouse hover over
    public void OnPointerEnter(PointerEventData eventData)
    {
        HandlePointerEnter(eventData);
    }

    // mouse hover exit 
    public void OnPointerExit(PointerEventData eventData)
    {
        HandlePointerExit(eventData);
    }
    #endregion

    #region Protected methods
    protected virtual void HandlePointerClick(PointerEventData data) { }
    protected virtual void HandlePointerEnter(PointerEventData data) { }
    protected virtual void HandlePointerExit(PointerEventData data) { }
    #endregion
}
