using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class UIToggleInventory : MonoBehaviour
{ 
    private bool _isEnabled;

    public void Awake()
    {
        GetComponentInParent<Menu>().OnActiveChanged += (isActive) => { _isEnabled = isActive; };
    }

    public void Click()
    {
        if (!_isEnabled)
        {
            bool wasEnabled = ModuleManager.GetModule<MenuManager>().IsEnabled;
            if (!wasEnabled)
            {
                ModuleManager.GetModule<MenuManager>().ToggleMenuManager(true);
                ModuleManager.GetModule<HeldInventoryManager>().IsEnabled = true;
            }

            ModuleManager.GetModule<MenuManager>().ToggleMenu(MenuType.Inventory, true);
            if (wasEnabled)
            {
                ModuleManager.GetModule<MenuManager>().ToggleMenuManager(false);
                ModuleManager.GetModule<HeldInventoryManager>().IsEnabled = false;
            }
        }
    }
}
