using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class MainCard : CustomUIButton
{
    [SerializeField] private TextMeshProUGUI _categoryText;
    [SerializeField] private TextMeshProUGUI _itemNameText;
    [SerializeField] private Image _backgroundImage;
    [SerializeField] private Image _itemImage;
    [SerializeField] private Sprite _emptySprite;

    private Category _category;

    private Color _backgroundColor;
    private Color _hoverBackgroundColor;

    private void Start()
    {
        MainPanel panel = MainPanel.Instance;

        _backgroundColor = panel.CardActiveColor;
        _hoverBackgroundColor = panel.CardHoverColor;

        //default empty
        _itemNameText.text = "None";
        _itemImage.sprite = _emptySprite;
    }

    public void SetEquippedItem(EquippedData equippedItem)
    {
        if(equippedItem == null) {
            _itemNameText.text = "None";
            _itemImage.sprite = _emptySprite;
            return;
        }

        _itemNameText.text = equippedItem.itemName;
        _itemImage.sprite = equippedItem.itemSprite;
    }

    public void SetCategory(Category category)
    {
        _category = category;
        _categoryText.text = category.ToString();
    }

    public void SetHover()
    {
        _backgroundImage.color = _backgroundColor;
    }

    public void SetPassive()
    {
        _backgroundImage.color = _backgroundColor;
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
        MainPanel.Instance.OpenCategory(_category);
    }

    public Category Category => _category;
}