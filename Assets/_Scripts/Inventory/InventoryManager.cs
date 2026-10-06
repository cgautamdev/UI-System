using System;
using System.Collections.Generic;
using UnityEngine;

public enum WeaponType
{
    Assault,
    SMG,
    Sniper,
    Pistol,
    Armor,
    Nade,
}

[Serializable]
public class ItemData
{
    public string itemName;
    public WeaponType weaponType;
    public Sprite itemSprite;
}

[Serializable]
public class CategoryData
{
    public Category category;
    public List<ItemData> items;
}

[Serializable]
public class EquippedData
{
    public Category category;
    public string itemName;
    public Sprite itemSprite;
}

public class InventoryManager : MonoBehaviour
{
    public static InventoryManager Instance { get; private set; }

    [SerializeField] private List<CategoryData> _inventory;
    [SerializeField] private List<EquippedData> _equipped = new();

    private void Awake()
    {
        Instance = this;
    }
    public void EquipItem(Category category, ItemData item)
    {
        EquippedData equipped = _equipped.Find(x => x.category == category);

        if(equipped != null) {
            equipped.itemName = item.itemName;
            equipped.itemSprite = item.itemSprite;
        }
        else {
            _equipped.Add(new EquippedData {
                category = category,
                itemName = item.itemName,
                itemSprite = item.itemSprite
            });
        }
    }

    public void UnequipItem(Category category, ItemData item)
    {
        EquippedData equipped = _equipped.Find(x =>
            x.category == category &&
            x.itemName == item.itemName);

        if(equipped != null)
            _equipped.Remove(equipped);
    }

    public bool IsEquipped(Category category, ItemData item)
    {
        return _equipped.Exists(x =>
            x.category == category &&
            x.itemName == item.itemName);
    }

    public EquippedData GetEquippedItem(Category category)
    {
        return _equipped.Find(x => x.category == category);
    }

    public List<CategoryData> Inventory => _inventory;
    public List<EquippedData> EquippedItems => _equipped;
}