using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Mirror;
using UnityEngine.AI;

public class SheepController : NetworkBehaviour
{
    //[SyncVar]
    bool discoverable = true;
    public string sColor;

    [SyncVar (hook = "FollowPlayer")]
    private GameObject shepard = null;
    private NavMeshAgent agent;
    //private Transform shepardLocation;
    // Start is called before the first frame update
    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        
    }

    // Update is called once per frame
    [ClientRpc]
    void Update()
    {
        if(shepard != null)
        {
            transform.LookAt(shepard.transform.position);
        }
    }
    [ClientRpc]
    void FixedUpdate()
    {
        if (shepard != null)
        {
            GetComponent<NavMeshAgent>().speed = Random.Range(4f,8f);
            agent.destination = shepard.transform.position;
        }
    }

    //[Command]
    public void FollowPlayer(GameObject old, GameObject follow)
    {
        if(discoverable == true)
        {
            shepard = follow;
            //PHYSICALLY FOLLOW PLAYER AT A SLIGHT DISTANCE
            discoverable = false;
        }
    }

    public string GetColor()
    {
        return sColor;
    }

    public bool GetDiscoverable()
    {
        return discoverable;
    }
}
