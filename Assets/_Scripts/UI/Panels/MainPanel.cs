using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public enum Category
{
    Primary,
    Secondary,
    Throwable,
    Armor
}
public class MainPanel : CustomUIButton
{
    public static MainPanel Instance {  get; private set; }
    [SerializeField] private MainCard[] _mainCards;
    [SerializeField] private List<Category> _categories;

    [Header("Card Settings")]
    [SerializeField] private Color _activeColor;
    [SerializeField] private Color _hoverColor;

    private void Awake()
    {
        Instance = this;

        for(int i = 0; i < _mainCards.Length && i < _categories.Count; i++) {
            _mainCards[i].SetCategory(_categories[i]);
        }
    }

    private void Start()
    {
        for(int i = 0; i < _mainCards.Length && i < _categories.Count; i++) {
            _mainCards[i].SetCategory(_categories[i]);
            RefreshMainCard(_categories[i]);
        }
    }

    public void RefreshMainCard(Category category)
    {
        EquippedData equipped = InventoryManager.Instance.GetEquippedItem(category);

        foreach(MainCard card in _mainCards) {
            if(card.Category == category) {
                card.SetEquippedItem(equipped);
                return;
            }
        }
    }

    // public stuff
    public Color CardActiveColor => _activeColor;
    public Color CardHoverColor => _hoverColor;
    public void OpenCategory(Category category)
    {
        UIManager.Instance.OpenInventoryFromCard(category);
    }
}
