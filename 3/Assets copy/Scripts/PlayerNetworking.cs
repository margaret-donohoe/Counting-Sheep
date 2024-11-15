using Mirror;
using TMPro;
using UnityEngine;
using System.Collections;

public class PlayerNetworking : NetworkBehaviour
{
    [SyncVar]
    public string[] names = new string[] { "schmoink", "kamala harris", "steve buschemi", "the entire roster of abba" };

    public TMP_Text playerNamePrefab;
    TMP_Text playerNameInstance;

    [SyncVar(hook = nameof(OnNameChange))]
    string playerName = "Player";

    private string pName;
    private string pColor;
    private int pBase;

    public int herdCount = 0;

    //[SyncVar]
    public GameObject visibleRange;

    // Start is called before the first frame update
    void Start()
    {
        //UNCOMMENT BELOW ONCE CHARACTER CREATOR IS IMPLEMENTED

        //pName = PlayerPrefs.GetString("name");
        //pColor = PlayerPrefs.GetString("material");
        //pBase = PlayerPrefs.GetInt("base");
        visibleRange.SetActive(false);

        playerNameInstance = Instantiate<TMP_Text>(playerNamePrefab);
        playerNameInstance.transform.SetParent(GameObject.FindWithTag("PlayerCanvas").transform, false);

        if (isLocalPlayer)
        {
            RandomName();
            ChaseCamera.target = transform;
        }
        else
        {
            playerNameInstance.text = playerName;
            GetComponent<PlayerController>().enabled = false;
        }
    }

    void OnDisable()
    {
        Destroy(playerNameInstance);
    }

    void LateUpdate()
    {
        playerNameInstance.transform.position = transform.position + Vector3.up * 0.05f;
        playerNameInstance.transform.LookAt(Camera.main.transform);
    }

    void RandomName()
    {
        GameObject[] players = GameObject.FindGameObjectsWithTag("Player");
        string tempPlayerName = names[players.Length - 1];
        CmdUpdatePlayerName(tempPlayerName);
    }

    [Command]
    void CmdUpdatePlayerName(string newPlayerName)
    {
        playerName = newPlayerName;
        playerNameInstance.text = playerName;
    }

    void OnNameChange(string oldPlayerName, string newPlayerName)
    {
        if (playerNameInstance == null) return;
        playerName = newPlayerName;
        playerNameInstance.text = playerName;
    }

    [Command]
    public void MakeSheepFollow()
    {
        RpcMessageRange();
        GameObject[] spawnedSheep = GameObject.FindGameObjectsWithTag("Sheep");

        foreach (GameObject sheep in spawnedSheep)
        {
            
            if (Vector3.Distance(sheep.transform.position, gameObject.transform.position) < 4 && sheep.GetComponent<SheepController>().GetDiscoverable() == true)
            {
                sheep.GetComponent<SheepController>().FollowPlayer(gameObject, gameObject);

                //change herdCount based on sheep.GetComponent<SheepController>().GetColor()
                herdCount++;
                Debug.Log(herdCount.ToString());
            }
        }
    }

    [ClientRpc]
    void RpcMessageRange()
    {
        visibleRange.SetActive(true);
        StartCoroutine(TurnOffRange());
    }

    IEnumerator TurnOffRange()
    {
        yield return new WaitForSeconds(1f);
        visibleRange.SetActive(false);
    }
}

