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

    private float wanderRadius = 10;
    private float wanderTimer;

    private Animator animator;

    private AudioSource microphone;
    public AudioClip[] bahhs;

    [SyncVar]
    private Transform target;
    private float timer;
    //private Transform shepardLocation;
    // Start is called before the first frame update
    void OnEnable()
    {
        animator = GetComponent<Animator>();
        agent = GetComponent<NavMeshAgent>();
        timer = wanderTimer;
        microphone = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    //[ClientRpc]
    void Update()
    {
        if(shepard != null)
        {
            transform.LookAt(shepard.transform.position);
        }

        if (shepard == null)
        {
            //Wander();

            //timer += Time.deltaTime;

            //wanderTimer = Random.Range(2, 6);

            //if (timer >= wanderTimer)
            //{
            //    Vector3 newPos = RandomNavSphere(transform.position, wanderRadius, -1);
            //    agent.SetDestination(newPos);
            //    timer = 0;
            //    Move();
            //}
        }
    }
    //[ClientRpc]
    void FixedUpdate()
    {
        if (shepard != null)
        {
            GetComponent<NavMeshAgent>().speed = Random.Range(4f,8f);
            agent.destination = shepard.transform.position;
            if(Vector3.Distance(shepard.transform.position, gameObject.transform.position) > 3.5)
            {
                Move();
            }
            
        }

        int i = Random.Range(0, 1500);
        if (i == 6)
        {
            Baah();
        }
    }

    [Command]
    void Wander()
    {
        timer += Time.deltaTime;

        wanderTimer = Random.Range(2, 6);

        if (timer >= wanderTimer)
        {
            Vector3 newPos = RandomNavSphere(transform.position, wanderRadius, -1);
            agent.SetDestination(newPos);
            timer = 0;
            Move();
        }
    }


    public static Vector3 RandomNavSphere(Vector3 origin, float dist, int layermask)
    {
        Vector3 randDirection = Random.insideUnitSphere * dist;

        randDirection += origin;

        NavMeshHit navHit;

        NavMesh.SamplePosition(randDirection, out navHit, dist, layermask);

        return navHit.position;
    }

    //[Command]
    public void FollowPlayer(GameObject old, GameObject follow)
    {
        if(discoverable == true)
        {
            Follow();
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

    [Command(requiresAuthority = false)]
    public void Follow()
    {
        RpcPlayFollow();
        RpcPlayBaah();
    }

    [Command(requiresAuthority = false)]
    public void Move()
    {
        RpcPlayMove();
    }

    [Command(requiresAuthority = false)]
    public void Baah()
    {
        RpcPlayBaah();
    }

    [ClientRpc]
    public void RpcPlayFollow()
    {
        animator.SetTrigger("follow");
        microphone.clip = bahhs[Random.Range(0, 2)];
        microphone.Play();
    }

    [ClientRpc]
    public void RpcPlayMove()
    {
        animator.SetTrigger("run");
    }

    [ClientRpc]
    public void RpcPlayBaah()
    {
        microphone.clip = bahhs[Random.Range(0, 2)];
        microphone.Play();
        animator.SetTrigger("baah");
    }
}
