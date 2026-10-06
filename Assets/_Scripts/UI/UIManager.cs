using UnityEngine;

public class UIManager : MonoBehaviour
{
    public static UIManager Instance { get; private set; }

    [SerializeField] private GameObject _mainPanel;
    [SerializeField] private GameObject _inventoryPanel;

    private void Awake()
    {
        Instance = this;
    }

    private void Start()
    {
        _mainPanel.SetActive(true);
        _inventoryPanel.SetActive(false);
    }

    public void OpenInventoryFromCard(Category category)
    {
        _mainPanel.SetActive(false);
        _inventoryPanel.SetActive(true);

        InventoryPanel.Instance.SelectTabAndHideOthers(category);
    }

    public void OpenInventory()
    {
        _mainPanel.SetActive(false);
        _inventoryPanel.SetActive(true);

        InventoryPanel.Instance.SelectTab(Category.Primary);
    }
}