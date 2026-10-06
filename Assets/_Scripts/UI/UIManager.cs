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

    public void OpenInventory(Category category)
    {
        _mainPanel.SetActive(false);
        _inventoryPanel.SetActive(true);

        InventoryPanel.Instance.SelectTab(category);
    }
}