using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChaseCamera : MonoBehaviour
{

    //public int myInt { get; private set; } means variable can only be set in this class

    public static Transform target;

    [SerializeField] float distance = -6f;
    [SerializeField] float height = 2f;
    [SerializeField] float moveSpeed = 1f;
    [SerializeField] float rotSpeed = 3f;

    [SerializeField] Vector3 offset = new Vector3(0,1,0);
    
    void LateUpdate()
    {
        if (target == null) return;

        Vector3 lookPos = target.position + offset;
        Vector3 relativePos = lookPos - transform.position;
        Quaternion rot = Quaternion.LookRotation(relativePos);

        transform.rotation = Quaternion.Slerp(transform.rotation, rot, Time.deltaTime * rotSpeed);
        Vector3 targetPos = target.position + target.up * height - target.forward * distance;
        transform.position = Vector3.Lerp(transform.position, targetPos, Time.deltaTime * moveSpeed);
    }
}
