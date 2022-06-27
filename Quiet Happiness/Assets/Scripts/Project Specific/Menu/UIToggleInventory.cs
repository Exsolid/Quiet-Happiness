using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class UIToggleInventory : MonoBehaviour, IPointerClickHandler
{
    public void OnPointerClick(PointerEventData data)
    {
        if(ModuleManager.get<MenuManager>().InMenu) ModuleManager.get<UIEventManager>().ToggleMenu(MenuType.Inventory);
    }
}
