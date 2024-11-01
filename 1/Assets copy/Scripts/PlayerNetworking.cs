using Mirror;
using TMPro;
using UnityEngine;


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
    private int pNumber;

    // Start is called before the first frame update
    void Start()
    {
        //UNCOMMENT BELOW ONCE CHARACTER CREATOR IS IMPLEMENTED

        //pName = PlayerPrefs.GetString("name");
        //pColor = PlayerPrefs.GetString("color");
        //pNumber = PlayerPrefs.GetInt("number");

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
}

