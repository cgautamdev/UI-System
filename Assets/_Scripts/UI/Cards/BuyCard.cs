using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class BuyCard : CustomUIButton
{
    [SerializeField] private Image _backgroudImage;
    [SerializeField] private TextMeshProUGUI _itemNameText;
    [SerializeField] private Image _itemImage;
    [SerializeField] private GameObject _equipScreen;
    [SerializeField] private TextMeshProUGUI _equipText;
    [SerializeField] private EquipButton _equipButton;
    [SerializeField] private WeaponType _weaponType;

    private void Start()
    {
        _equipScreen.SetActive(false);
    }

    public void SetHover()
    {
        _equipScreen.SetActive(true);
    }

    public void SetActive()
    {
    }

    public void SetPassive()
    {
        _equipScreen.SetActive(false);
    }

    public void SetItem(Category category, ItemData item)
    {
        _itemNameText.text = item.itemName;
        _itemImage.sprite = item.itemSprite;
        _weaponType = item.weaponType;
        _equipButton.SetItem(category, item);
    }

    public WeaponType WeaponType => _weaponType;

    #region Button Properties
    protected override void HandlePointerEnter(PointerEventData data)
    {
        SetHover();
    }

    protected override void HandlePointerExit(PointerEventData data)
    {
        SetPassive();
    }
    #endregion
}
