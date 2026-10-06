using TMPro;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class EquipButton : CustomUIButton
{
    [SerializeField] private TextMeshProUGUI _equipText;
    [SerializeField] private Image _backgroundImage;

    [SerializeField] private Color _activeBackgroundColor;
    [SerializeField] private Color _hoverBackgroundColor;

    private Category _category;
    private ItemData _item;

    public void SetItem(Category category, ItemData item)
    {
        _category = category;
        _item = item;

        Refresh();
    }

    private void Refresh()
    {
        bool equipped = InventoryManager.Instance.IsEquipped(_category, _item);

        if(equipped) {
            _equipText.text = "Equipped";
        }
        else {
            _equipText.text = "Equip";
        }

        SetPassive();
    }

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
        bool equipped = InventoryManager.Instance.IsEquipped(_category, _item);

        if(equipped) {
            InventoryManager.Instance.UnequipItem(_category, _item);
        }
        else {
            InventoryManager.Instance.EquipItem(_category, _item);
        }

        Refresh();
        MainPanel.Instance.RefreshMainCard(_category);
    }
}