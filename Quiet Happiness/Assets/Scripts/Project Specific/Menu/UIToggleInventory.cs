using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class UIToggleInventory : MonoBehaviour, IPointerClickHandler
{
    private bool _isEnabled;

    public void Awake()
    {
        GetComponentInParent<MenuEnable>().activeChanged += (isActive) => { _isEnabled = isActive; };
    }

    public void OnPointerClick(PointerEventData data)
    {
        if(_isEnabled) ModuleManager.GetModule<UIEventManager>().ToggleMenu(MenuType.Inventory);
    }
}
