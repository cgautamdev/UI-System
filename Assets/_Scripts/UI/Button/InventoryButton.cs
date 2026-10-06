using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;
using static UnityEditor.Progress;

public class InventoryButton : CustomUIButton
{
    [SerializeField] private Image _backgroundImage;
    [SerializeField] private Color _activeBackgroundColor;
    [SerializeField] private Color _hoverBackgroundColor;

    private void SetHover()
    {
        _backgroundImage.color = _hoverBackgroundColor;
    }

    private void SetPassive()
    {
        _backgroundImage.color = _activeBackgroundColor;
    }

    protected override void HandlePointerEnter(PointerEventData data)
    {
        SetHover();
    }

    protected override void HandlePointerExit(PointerEventData data)
    {
        SetPassive();
    }

    protected override void HandlePointerClick(PointerEventData data)
    {
        UIManager.Instance.OpenInventory();
    }
}
