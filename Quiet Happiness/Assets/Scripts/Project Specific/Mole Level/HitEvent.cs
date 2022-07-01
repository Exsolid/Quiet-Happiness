using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.InputSystem;

public class HitEvent : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    [SerializeField] private PlayerInput input;
    [SerializeField] private string hitActionName;
    private bool myHit;
    private bool isHit;
    public int ID;

    public void OnPointerEnter(PointerEventData data)
    {
        myHit = true;
    }

    public void OnPointerExit(PointerEventData data)
    {
        myHit =false;
    }

    private void Update()
    {
        if (myHit && input.actions[hitActionName].triggered && !isHit)
        {
            ModuleManager.GetModule<MoleMinigameEventmanager>().Hit(0.1f, ID);
            StartCoroutine(moveDown(0.1f));
        }
    }

    IEnumerator moveDown(float delay)
    {
        float passedTime = 0;
        while (passedTime < delay)
        {
            passedTime += Time.deltaTime;
            yield return null;
        }
    }
}
