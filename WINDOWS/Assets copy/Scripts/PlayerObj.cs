using Mirror;
using UnityEngine;

public class PlayerObj : NetworkBehaviour
{

    //[SyncVar(hook = "ChangeChild")]
    //[SerializeField] private GameObject playerObject;

    //public GameObject[] children = new GameObject[] { };
    //[SyncVar(hook = nameof(EnableChild))]
    [SerializeField]
    GameObject childPrefab;

    [SyncVar(hook = nameof(ChangeChild))]
    private string pBase;

    [SyncVar(hook = nameof(ChangeMat))]
    private string pColor;
    

    public GameObject boy0;
    public GameObject boy2;
    public GameObject boy3;
    public GameObject girl0;
    public GameObject girl1;
    public GameObject girl3;

    public Material boy0pink;
    public Material boy0green;
    public Material boy0grey;
    public Material boy0yellow;
    public Material boy0blue;
    public Material boy0black;

    public Material boy2pink;
    public Material boy2green;
    public Material boy2grey;
    public Material boy2yellow;
    public Material boy2blue;
    public Material boy2black;

    public Material boy3pink;
    public Material boy3green;
    public Material boy3grey;
    public Material boy3yellow;
    public Material boy3blue;
    public Material boy3black;

    public Material girl0pink;
    public Material girl0green;
    public Material girl0grey;
    public Material girl0yellow;
    public Material girl0blue;
    public Material girl0black;

    public Material girl1pink;
    public Material girl1green;
    public Material girl1grey;
    public Material girl1yellow;
    public Material girl1blue;
    public Material girl1black;

    public Material girl3pink;
    public Material girl3green;
    public Material girl3grey;
    public Material girl3yellow;
    public Material girl3blue;
    public Material girl3black;

    
    //[SyncVar]
    GameObject playerCharacter;

    void Start()
    {
        if (!isLocalPlayer) return;
        
        if (PlayerPrefs.GetString("material") != null && PlayerPrefs.GetString("base") != null)
        {
            string model = PlayerPrefs.GetString("base");
            string color = PlayerPrefs.GetString("material");
            SetPlayer(model, color);
        }

        else
        {
            SetPlayer("girl0", "black");
        }

      
        //ChangeMat(pColor);

        //AssignChild();
    }

    void OnDisable()
    {
        Destroy(playerCharacter);
    }

    [Command]
    public void SetPlayer(string m, string c)
    {
        pBase = m;
        pColor = c;
    }

    public void ChangeChild(string old, string kid)
    {
        if(kid == "boy0")
        {
            childPrefab = boy0;
        }

        if (kid == "boy2")
        {
            childPrefab = boy2;
        }

        if (kid == "boy3")
        {
            childPrefab = boy3;
        }

        if (kid == "girl0")
        {
            childPrefab = girl0;
        }

        if (kid == "girl1")
        {
            childPrefab = girl1;
        }

        if (kid == "girl3")
        {
            childPrefab = girl3;
        }
        Debug.Log(childPrefab);
    }

    public void ChangeMat(string oldPJs, string pajamas)
    {
        if (childPrefab == boy0)
        {
            if (pajamas == "pink")
            {
                childPrefab.GetComponentInChildren<SkinnedMeshRenderer>().material = boy0pink;
            }
            if (pajamas == "green")
            {
                childPrefab.GetComponentInChildren<SkinnedMeshRenderer>().material = boy0green;

            }
            if (pajamas == "grey")
            {
                childPrefab.GetComponentInChildren<SkinnedMeshRenderer>().material = boy0grey;

            }
            if (pajamas == "yellow")
            {
                childPrefab.GetComponentInChildren<SkinnedMeshRenderer>().material = boy0yellow;

            }
            if (pajamas == "blue")
            {
                childPrefab.GetComponentInChildren<SkinnedMeshRenderer>().material = boy0blue;

            }
            if (pajamas == "black")
            {
                childPrefab.GetComponentInChildren<SkinnedMeshRenderer>().material = boy0black;

            }
        }
        if (childPrefab == boy2)
        {
            if (pajamas == "pink")
            {
                childPrefab.GetComponentInChildren<SkinnedMeshRenderer>().material = boy2pink;
            }
            if (pajamas == "green")
            {
                childPrefab.GetComponentInChildren<SkinnedMeshRenderer>().material = boy2green;

            }
            if (pajamas == "grey")
            {
                childPrefab.GetComponentInChildren<SkinnedMeshRenderer>().material = boy2grey;

            }
            if (pajamas == "yellow")
            {
                childPrefab.GetComponentInChildren<SkinnedMeshRenderer>().material = boy2yellow;

            }
            if (pajamas == "blue")
            {
                childPrefab.GetComponentInChildren<SkinnedMeshRenderer>().material = boy2blue;

            }
            if (pajamas == "black")
            {
                childPrefab.GetComponentInChildren<SkinnedMeshRenderer>().material = boy2black;

            }
        }
        if (childPrefab == boy3)
        {
            if (pajamas == "pink")
            {
                childPrefab.GetComponentInChildren<SkinnedMeshRenderer>().material = boy3pink;
            }
            if (pajamas == "green")
            {
                childPrefab.GetComponentInChildren<SkinnedMeshRenderer>().material = boy3green;

            }
            if (pajamas == "grey")
            {
                childPrefab.GetComponentInChildren<SkinnedMeshRenderer>().material = boy3grey;

            }
            if (pajamas == "yellow")
            {
                childPrefab.GetComponentInChildren<SkinnedMeshRenderer>().material = boy3yellow;

            }
            if (pajamas == "blue")
            {
                childPrefab.GetComponentInChildren<SkinnedMeshRenderer>().material = boy3blue;

            }
            if (pajamas == "black")
            {
                childPrefab.GetComponentInChildren<SkinnedMeshRenderer>().material = boy3black;

            }
        }
        if (childPrefab == girl0)
        {
            if (pajamas == "pink")
            {
                childPrefab.GetComponentInChildren<SkinnedMeshRenderer>().material = girl0pink;
            }
            if (pajamas == "green")
            {
                childPrefab.GetComponentInChildren<SkinnedMeshRenderer>().material = girl0green;

            }
            if (pajamas == "grey")
            {
                childPrefab.GetComponentInChildren<SkinnedMeshRenderer>().material = girl0grey;

            }
            if (pajamas == "yellow")
            {
                childPrefab.GetComponentInChildren<SkinnedMeshRenderer>().material = girl0yellow;

            }
            if (pajamas == "blue")
            {
                childPrefab.GetComponentInChildren<SkinnedMeshRenderer>().material = girl0blue;

            }
            if (pajamas == "black")
            {
                childPrefab.GetComponentInChildren<SkinnedMeshRenderer>().material = girl0black;

            }
        }
        if (childPrefab == girl1)
        {
            if (pajamas == "pink")
            {
                childPrefab.GetComponentInChildren<SkinnedMeshRenderer>().material = girl1pink;
            }
            if (pajamas == "green")
            {
                childPrefab.GetComponentInChildren<SkinnedMeshRenderer>().material = girl1green;

            }
            if (pajamas == "grey")
            {
                childPrefab.GetComponentInChildren<SkinnedMeshRenderer>().material = girl1grey;

            }
            if (pajamas == "yellow")
            {
                childPrefab.GetComponentInChildren<SkinnedMeshRenderer>().material = girl1yellow;

            }
            if (pajamas == "blue")
            {
                childPrefab.GetComponentInChildren<SkinnedMeshRenderer>().material = girl1blue;

            }
            if (pajamas == "black")
            {
                childPrefab.GetComponentInChildren<SkinnedMeshRenderer>().material = girl1black;

            }
        }
        if (childPrefab == girl3)
        {
            if (pajamas == "pink")
            {
                childPrefab.GetComponentInChildren<SkinnedMeshRenderer>().material = girl3pink;
            }
            if (pajamas == "green")
            {
                childPrefab.GetComponentInChildren<SkinnedMeshRenderer>().material = girl3green;

            }
            if (pajamas == "grey")
            {
                childPrefab.GetComponentInChildren<SkinnedMeshRenderer>().material = girl3grey;

            }
            if (pajamas == "yellow")
            {
                childPrefab.GetComponentInChildren<SkinnedMeshRenderer>().material = girl3yellow;

            }
            if (pajamas == "blue") 
            {
                childPrefab.GetComponentInChildren<SkinnedMeshRenderer>().material = girl3blue;

            }
            if (pajamas == "black")
            {
                childPrefab.GetComponentInChildren<SkinnedMeshRenderer>().material = girl3black;

            }
        }
        EnableChild(childPrefab);
    }

 
    //[ClientRpc]
    //[Command(requiresAuthority = false)]
    void EnableChild(GameObject kid)
    {
        playerCharacter = Instantiate(kid, gameObject.transform.localPosition, Quaternion.identity) as GameObject;
        playerCharacter.transform.SetParent(gameObject.transform);
        //NetworkServer.Spawn(playerCharacter);
    }
}
