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

    //[SyncVar]
    private GameObject shepard = null;
    private NavMeshAgent agent;
    //private Transform shepardLocation;
    // Start is called before the first frame update
    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        Debug.Log(sColor);
    }

    // Update is called once per frame
    void Update()
    {
        if(shepard != null)
        {
            transform.LookAt(shepard.transform.position);
        }
    }

    void FixedUpdate()
    {
        if (shepard != null)
        {
            agent.destination = shepard.transform.position;
        }
    }

    public void FollowPlayer(GameObject follow)
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
