using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuWheel : MonoBehaviour
{
    [SerializeField] private List<GameObject> items;
    private List<float> degrees;
    [SerializeField] private float radius;
    [SerializeField] private float timeToMove;
    private float currentTimer;
    private int index;

    // Start is called before the first frame update
    void Start()
    {
        if (items == null) items = new List<GameObject>();
        degrees = new List<float>();
        float current = 0;
        foreach (GameObject item in items)
        {
            degrees.Add(current);
            item.transform.position = new Vector3(radius * Mathf.Cos(Mathf.Deg2Rad * degrees[index]), radius * Mathf.Sin(Mathf.Deg2Rad * degrees[index]), 0);
            current += 360f / items.Count;
            index++;
        }
    }
    private void Update()
    {
        if(currentTimer > 0)
        {
            currentTimer -= Time.deltaTime;
        }
    }

    private void OnMouseUp()
    {
        moveNext();
    }

    public void moveNext()
    {
        if (currentTimer > 0) return;
        currentTimer = timeToMove;
        if (index == items.Count-1) index = 0;
        else index++;
        int current = 0;
        foreach (GameObject item in items)
        {
            degrees[current] += 360f / items.Count;
            if (degrees[current] > 360) degrees[current] -= 360;
            StartCoroutine(moveToPosition(item, new Vector3(radius * Mathf.Cos(Mathf.Deg2Rad * degrees[current]), radius * Mathf.Sin(Mathf.Deg2Rad * degrees[current]), 0)));
            current++;
        }
    }

    public void movePrev()
    {
        if (currentTimer > 0) return;
        currentTimer = timeToMove;
        if (index < 0) index = items.Count;
        else index--;
        int current = 0;
        foreach (GameObject item in items)
        {
            degrees[current] -= 360f / items.Count;
            if (degrees[current] < 0) degrees[current] += 360;
            StartCoroutine(moveToPosition(item, new Vector3(radius * Mathf.Cos(Mathf.Deg2Rad * degrees[current]), radius * Mathf.Sin(Mathf.Deg2Rad * degrees[current]), 0)));
            current++;
        }
    }

    public IEnumerator moveToPosition(GameObject item, Vector3 newPos)
    {
        float runtime = 0;
        Vector3 startPos = item.transform.position;
        while (runtime < timeToMove)
        {
            runtime += Time.deltaTime;
            item.transform.position = Vector3.Lerp(startPos, newPos, (runtime/timeToMove));
            yield return new WaitForEndOfFrame();
        }
    }
}
