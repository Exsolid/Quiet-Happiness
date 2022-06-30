using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class UIToggleInventory : MonoBehaviour, IPointerClickHandler
{
    public void OnPointerClick(PointerEventData data)
    {
        if(ModuleManager.GetModule<MenuManager>().InMenu) ModuleManager.GetModule<UIEventManager>().ToggleMenu(MenuType.Inventory);
    }
}
