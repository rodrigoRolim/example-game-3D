using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class npc : MonoBehaviour
{
    public GameObject pc;
    private NavMeshAgent agent;
    public GameObject[] waypoints = new GameObject[4];
    private int index = 0;
    public float maxDist = 1;
    public Vector3 pos_i;
   // public Transform[] spawnPoints;
   // public float spawnTime = 3f;
    void Start()
    {
       
        pos_i = new Vector3(transform.position.x, transform.position.y, transform.position.z);
        agent = GetComponent<NavMeshAgent>();
        next();
    }
    void next() {
        agent.destination = waypoints[index++].transform.position;
        if (index >= waypoints.Length)

            index = 0;
    }    
    // Update is called once per frame
    void Update()
    {
      
        if (gameObject.CompareTag("enemy") && Vector3.Distance(transform.position, pc.transform.position) <= 1) {
      
            agent.destination = pc.transform.position;
        } else if (Vector3.Distance(transform.position, agent.destination) <= maxDist) {

            next();
        }
 
    }
    void OnTriggerEnter(Collider col) {
        if (col.gameObject.tag == "player") {
            //InvokeRepeating("Spawn", spawnTime, spawnTime);
            gameObject.transform.position = pos_i;
       }
    }
    /* void Spawn(){
        int spawnPointIndex = Random.Range(0, spawnPoints.Length);

        Instantiate(gameObject, spawnPoints[spawnPointIndex].position, spawnPoints[spawnPointIndex].rotation);
    } */
}
