using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class PrimaryWeaponPanel : MonoBehaviour
{
    [SerializeField] private TMP_Dropdown _filterDropdown;

    private List<BuyCard> _buyCards = new();

    private void Awake()
    {
        _filterDropdown.onValueChanged.AddListener(OnFilterChanged);
    }

    public void SetCards(List<BuyCard> cards)
    {
        _buyCards = cards;
    }

    private void OnFilterChanged(int index)
    {
        if(index == 0) {
            foreach(BuyCard card in _buyCards) {
                card.gameObject.SetActive(true);
            }

            return;
        }

        WeaponType selectedType = (WeaponType)(index - 1);

        FilterCards(selectedType);
    }

    private void FilterCards(WeaponType selectedType)
    {
        foreach(BuyCard card in _buyCards) {
            card.gameObject.SetActive(
                card.WeaponType == selectedType
            );
        }
    }
}