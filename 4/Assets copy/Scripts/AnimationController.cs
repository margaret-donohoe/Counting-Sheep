using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Mirror;

public class AnimationController : NetworkBehaviour
{
    private Animator animator = null;
    private AudioSource microphone = null;

    private Vector3 velocity;
    public float gravity = -9.81f;
    public float jumpHeight = 1.5f;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
       if (!isLocalPlayer) return;

        if (GetComponentInChildren<Animator>() != null && animator == null)
        {

            animator = GetComponentInChildren<Animator>();
        }

        if (GetComponentInChildren<AudioSource>() != null && microphone == null)
        {
            microphone = GetComponentInChildren<AudioSource>();
        }
    }

    [Command(requiresAuthority = false)]
    public void Jump()
    {
        if (!isLocalPlayer) return;
        RpcPlayJump();
    }

    [Command(requiresAuthority = false)]
    public void Call()
    {
        if (!isLocalPlayer) return;
        gameObject.GetComponent<PlayerNetworking>().MakeSheepFollow();
        RpcPlayCall();
        microphone.Play();
    }

    [Command(requiresAuthority = false)]
    public void Move()
    {
        if (!isLocalPlayer) return;
        RpcPlayMove();
    }

    [Command(requiresAuthority = false)]
    public void Sleep()
    {
        if (!isLocalPlayer) return;
        RpcPlaySleep();
    }

    [ClientRpc]
    public void RpcPlayJump()
    {
        animator.SetTrigger("jump");
    }

    [ClientRpc]
    public void RpcPlayCall()
    {
        animator.SetTrigger("psychic");
    }

    [ClientRpc]
    public void RpcPlayMove()
    {
        animator.SetTrigger("run");
    }

    [ClientRpc]
    public void RpcPlaySleep()
    {
        animator.SetTrigger("sleep");
    }

}
