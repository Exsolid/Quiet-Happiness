using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoleSpawner : MonoBehaviour
{
    [SerializeField] private Transform heightToSpawnIn;
    [SerializeField] private Transform pointA;
    [SerializeField] private Transform pointB;
    [SerializeField] private GameObject objToSpawn;
    [SerializeField] private float maxDelay;
    [SerializeField] private float minDelay;
    [SerializeField] private int spawnCount;
    [SerializeField] private float timed;
    [SerializeField] private bool timedEnabled;
    private Vector3 smallest;
    private Vector3 biggest;
    private int IDCounter;
    private float timer;
    private float timerAll;

    
    // Start is called before the first frame update
    void Start()
    {
        smallest = new Vector3(pointA.position.x < pointB.position.x ? pointA.position.x : pointB.position.x, 0, pointA.position.z < pointB.position.z ? pointA.position.z : pointB.position.z);
        biggest = new Vector3(pointA.position.x > pointB.position.x ? pointA.position.x : pointB.position.x, 0, pointA.position.z > pointB.position.z ? pointA.position.z : pointB.position.z);
    }

    // Update is called once per frame
    void Update()
    {
        if (timedEnabled && timed < timerAll || spawnCount == IDCounter && !timedEnabled) return;
        timer -= Time.deltaTime;
        timerAll += Time.deltaTime;
        if(timer < 0)
        {
            GameObject newObj = Instantiate(objToSpawn, new Vector3(Random.Range(smallest.x, biggest.x), heightToSpawnIn.position.y, Random.Range(smallest.z, biggest.z)), Quaternion.Euler(0, 0, 0));
            newObj.GetComponentInChildren<HitEvent>().ID = IDCounter;
            newObj.GetComponent<MoleMovement>().ID = IDCounter;
            IDCounter++;
            timer = Random.Range(minDelay, maxDelay);
        }
    }
}
