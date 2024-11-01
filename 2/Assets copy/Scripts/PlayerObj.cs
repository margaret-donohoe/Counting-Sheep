using Mirror;
using Mirror.BouncyCastle.Asn1.Misc;
using UnityEngine;

public class PlayerObj : NetworkBehaviour
{

    //[SyncVar(hook = "ChangeChild")]
    //[SerializeField] private GameObject playerObject;

    public GameObject[] children = new GameObject[] { };

    //[SyncVar]
    private GameObject child;

    [SyncVar (hook = ("EnableChild"))]
    private int childNum;

    void Awake()
    {
        
    }

    void Start()
    {
        if (!isLocalPlayer) return;
        ChangeChildNum(Random.Range(0, children.Length - 1));
        //EnableChild(0, childNum);
    }

    [Command]
    void ChangeChildNum(int num)
    {
        childNum = num;
    }

    void Update()
    {
        //if(!isLocalPlayer) return;
        //child.transform.position = gameObject.transform.position;
    }

    void EnableChild(int oldIndex, int newIndex)
    {
        GameObject temp = children[newIndex];
        child = Instantiate(temp, gameObject.transform.position, Quaternion.identity);
        child.transform.SetParent(gameObject.transform);
        //NetworkServer.Spawn(child);
        gameObject.GetComponent<MeshRenderer>().enabled = false;
    }

    //[Command] //SERVER COMMAND
    //void CmdChangeObject()
    //{
    //    RpcMessageChangeObject();
    //}

    //[ClientRpc]
    //void RpcMessageChangeObject(GameObject prefab)
    //{

    //}
    //void ChangeChild(GameObject old, GameObject oNew)
    //{
    //    //GetComponent<MeshFilter>().mesh = oNew.GetComponent<MeshFilter>().mesh;
    //}
}
