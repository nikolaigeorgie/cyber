using UnityEngine;
using System.Collections;

public class Travel : MonoBehaviour {

    public GameObject spawnObject;

    public Transform target;
    public float speed;


    public float maxTime = 5;
    public float minTime = 2;

    private float time;

    private float spawnTime;

    private void Start()
    {
        SetRandomTime();
        time = minTime;

    }

    private void FixedUpdate()
    {
        time += Time.deltaTime;

        if(time >= spawnTime)
        {
            SpawnObject();
            SetRandomTime();
        }
    }

    void SpawnObject()
    {
        time = 10;
        Instantiate(spawnObject, transform.position, spawnObject.transform.rotation);
        float step = speed * Time.deltaTime;
        transform.position = Vector3.MoveTowards(transform.position, target.position, step);

    }

    void SetRandomTime()
    {
        spawnTime = Random.Range(minTime, maxTime);
    }
    
    void Update()
    {
      
    }
}
