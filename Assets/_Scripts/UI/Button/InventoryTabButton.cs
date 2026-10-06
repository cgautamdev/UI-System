using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

[RequireComponent(typeof(Image))]
public class InventoryTabButton : CustomUIButton
{
    [SerializeField] private GameObject _panel;
    [SerializeField] private Category _category;

    private bool _isActive;
    private Image _backgroundImage;

    private Color _activeBackgroundColor;
    private Color _passiveBackgroundColor;
    private Color _hoverBackgroundColor;

    private void Awake()
    {
        _backgroundImage = GetComponent<Image>();
    }

    private void Start()
    {
        InventoryPanel panel = InventoryPanel.Instance;

        _activeBackgroundColor = panel.ButtonActiveColor;
        _passiveBackgroundColor = panel.ButtonPassiveColor;
        _hoverBackgroundColor = panel.ButtonHoverColor;

        if(_isActive) SetActive();
        else SetPassive();
    }

    public void SetHover()
    {
        _backgroundImage.color = _hoverBackgroundColor;
    }

    public void SetActive()
    {
        _isActive = true;
        _backgroundImage.color = _activeBackgroundColor;
        _panel.SetActive(true);
    }

    public void SetPassive()
    {
        _isActive = false;
        _backgroundImage.color = _passiveBackgroundColor;
        _panel.SetActive(false);
    }

    protected override void HandlePointerEnter(PointerEventData data)
    {
        if(_isActive)
            return;

        SetHover();
    }

    protected override void HandlePointerExit(PointerEventData data)
    {
        if(_isActive)
            return;

        SetPassive();
    }

    protected override void HandlePointerClick(PointerEventData data)
    {
        InventoryPanel.Instance.SelectTab(_category);
    }

    public Category Category => _category;
}