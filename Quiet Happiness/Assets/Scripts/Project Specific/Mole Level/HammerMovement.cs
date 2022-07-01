using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class HammerMovement : MonoBehaviour
{
    [SerializeField] private string mouseActionName;
    [SerializeField] private GameObject planeToMoveIn;
    [SerializeField] private GameObject hammerModel;
    private Vector3 originalRotation;
    private bool isRotated;

    // Start is called before the first frame update
    void Start()
    {
        originalRotation = new Vector3(hammerModel.transform.eulerAngles.x, hammerModel.transform.eulerAngles.y, hammerModel.transform.eulerAngles.z);
        ModuleManager.GetModule<MoleMinigameEventmanager>().hit += (delay, ID) => {
            if (!isRotated)
            {
                isRotated = true;
                StartCoroutine(rotate(delay));
            } 
        };
    }

    // Update is called once per frame
    void Update()
    {
        Ray ray = Camera.main.ScreenPointToRay(Mouse.current.position.ReadValue());
        if(Physics.Raycast(ray, out RaycastHit hit, 50, LayerMask.GetMask("PlaneToMove")))
        {
            transform.position =  Vector3.Lerp(hit.point, transform.position, 0.2f);
        }
    }

    IEnumerator rotate(float delay)
    {
        float passedTime = 0;
        Vector3 currentRot = hammerModel.transform.eulerAngles;
        while (passedTime < delay)
        {
            passedTime += Time.deltaTime;
            hammerModel.transform.eulerAngles = Vector3.Lerp(originalRotation + new Vector3(90,0,0), currentRot, passedTime / delay);
            yield return null;
        }
        StartCoroutine(rotateBack(delay));
    }

    IEnumerator rotateBack(float delay)
    {
        float passedTime = 0;
        Vector3 currentRot = hammerModel.transform.eulerAngles;
        while (passedTime < delay)
        {
            passedTime += Time.deltaTime;
            hammerModel.transform.eulerAngles = Vector3.Lerp(currentRot, originalRotation, passedTime / delay);
            yield return null;
        }
        isRotated = false;
    }
}
