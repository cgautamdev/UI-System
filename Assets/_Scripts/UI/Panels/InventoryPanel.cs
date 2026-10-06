using System.Collections.Generic;
using UnityEngine;

public class InventoryPanel : MonoBehaviour
{
    public static InventoryPanel Instance { get; private set; }

    [Header("Button Settings")]
    [SerializeField] private Color _activeColor;
    [SerializeField] private Color _passiveColor;
    [SerializeField] private Color _hoverColor;

    [Header("Buttons")]
    [SerializeField] private InventoryTabButton[] _tabs;

    [Header("Card Instantiate")]
    [SerializeField] private GameObject _buyCardPrefab;
    [SerializeField] private Transform _primaryWeaopnCardContainer;
    [SerializeField] private Transform _secondaryWeaopnCardContainer;
    [SerializeField] private Transform _throwbaleCardContainer;
    [SerializeField] private Transform _armorCardContainer;

    [SerializeField] private PrimaryWeaponPanel _primaryWeaponPanel;

    // privarte
    private List<CategoryData> _inventory;
    private List<EquippedData> _equippedItems;

    private void Awake()
    {
        Instance = this;
        _inventory = InventoryManager.Instance.Inventory;
        _equippedItems = InventoryManager.Instance.EquippedItems;
    }

    private void FillPanel(Category category)
    {
        CategoryData categoryData = _inventory.Find(x => x.category == category);
        List<BuyCard> cards = new();

        foreach(ItemData item in categoryData.items) {
            BuyCard card = Instantiate(_buyCardPrefab, GetCardContainer(category)).GetComponent<BuyCard>();
            card.SetItem(category, item);
            cards.Add(card);
        }

        if(category == Category.Primary) {
            _primaryWeaponPanel.SetCards(cards);
        }
    }

    private void ClearCards(Category category)
    {
        foreach(Transform child in GetCardContainer(category)) {
            Destroy(child.gameObject);
        }
    }

    public void SelectTab(Category category)
    {
        ClearCards(category);
        foreach(InventoryTabButton tab in _tabs) {
            tab.gameObject.SetActive(true);
            if(tab.Category == category) {
                tab.SetActive();
            }
            else {
                tab.SetPassive();
            }
        }
        FillPanel(category);
    }

    public void SelectTabAndHideOthers(Category category)
    {
        ClearCards(category);

        foreach(InventoryTabButton tab in _tabs) {
            if(tab.Category == category) {
                tab.gameObject.SetActive(true);
                tab.SetActive();
            }
            else {
                tab.SetPassive();
                tab.gameObject.SetActive(false);
            }
        }

        FillPanel(category);
    }

    // helpers
    private Transform GetCardContainer(Category category)
    {
        switch(category) {
            case Category.Primary:
                return _primaryWeaopnCardContainer;

            case Category.Secondary:
                return _secondaryWeaopnCardContainer;

            case Category.Throwable:
                return _throwbaleCardContainer;

            case Category.Armor:
                return _armorCardContainer;

            default:
                return null;
        }
    }

    public Color ButtonActiveColor => _activeColor;
    public Color ButtonPassiveColor => _passiveColor;
    public Color ButtonHoverColor => _hoverColor;
}