using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoleMovement : MonoBehaviour
{
    [SerializeField] private Transform minPos;
    [SerializeField] private Transform maxPos;
    [SerializeField] private float timeToStay;
    private bool goBack;
    private float timer;
    public float ID;

    // Start is called before the first frame update
    void Start()
    {
        /*ModuleManager.get<MoleMinigameEventmanager>().hit += (delay, ID) =>
        { 
            if(ID == this.ID) StartCoroutine(hit(delay));
        };
        transform.position = new Vector3(transform.position.x, minPos.position.y, transform.position.z); */
    }

    // Update is called once per frame
    void Update()
    {
        if (!goBack && transform.position.y < maxPos.position.y)
        {
            transform.position = Vector3.Lerp(transform.position, new Vector3(transform.position.x, maxPos.position.y + 0.1f, transform.position.z), Time.deltaTime * 2f);
        }
        if(transform.position.y >= maxPos.position.y) timer += Time.deltaTime;
        if(transform.position.y >= maxPos.position.y && timeToStay < timer) goBack = true;
        if (goBack && transform.position.y >= minPos.position.y)
        {
            transform.position = Vector3.Lerp(transform.position, new Vector3(transform.position.x, minPos.position.y - 0.1f, transform.position.z), Time.deltaTime * 2f);
        }
    }

    IEnumerator hit(float delay)
    {
        yield return new WaitForSeconds(delay);
        goBack = true;
    }
}
