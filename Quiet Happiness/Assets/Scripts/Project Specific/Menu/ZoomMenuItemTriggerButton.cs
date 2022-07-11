using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class ZoomMenuItemTriggerButton : MonoBehaviour, IPointerClickHandler
{
    [SerializeField] private bool inMenu;
    [SerializeField] private ZoomMenuItem _zoom;
    private bool _isEnabled;

    public void Awake()
    {
        GetComponentInParent<Menu>().OnActiveChanged += (isActive) => { _isEnabled = isActive; };
    }

    public void OnPointerClick(PointerEventData data)
    {
        if (!(inMenu ^ _zoom.Zoomed) && !(_isEnabled ^ !_zoom.Zoomed) && !ModuleManager.GetModule<MenuManager>().CurrentActiveMenuList.MenuType.Equals(MenuType.Inventory))
        {
            if(inMenu) _zoom.ZoomOut();
            else _zoom.ZoomIn();
            GetComponentInParent<Menu>().IsActive = !_zoom.Zoomed;
        }
    }
}
