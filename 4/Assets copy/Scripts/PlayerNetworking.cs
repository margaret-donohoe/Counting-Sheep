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

    

    private string pName; //***********************************
    private string pColor;

    [SyncVar(hook = nameof(OnScoreChange))]
    public int herdCount = 0;

    private TMP_Text p1name;
    private TMP_Text p1score;
    private TMP_Text p2name;
    private TMP_Text p2score;


    private TMP_Text score;
    private TMP_Text namee;

    //[SyncVar]
    public GameObject visibleRange;

    private Timer timer;
    private GameObject startScreen;
    private GameObject endScreen;

    // Start is called before the first frame update
    void Start()
    {
        //UNCOMMENT BELOW ONCE CHARACTER CREATOR IS IMPLEMENTED
        timer = GameObject.FindObjectsOfType<Timer>()[0];
        timer.StartTimer();
        startScreen = GameObject.FindWithTag("Start");

        //if(isServer == true)
        //{
        //    endScreen = GameObject.FindWithTag("End");
        //    endScreen.SetActive(false);
        //}
        


        p1name = GameObject.Find("p1name").GetComponent<TMP_Text>();
        p2name = GameObject.Find("p2name").GetComponent<TMP_Text>();
        p1score = GameObject.Find("p1score").GetComponent<TMP_Text>();
        p2score = GameObject.Find("p2score").GetComponent<TMP_Text>();

        pName = PlayerPrefs.GetString("name");
        pColor = PlayerPrefs.GetString("material");

        visibleRange.SetActive(false);

        if (p1name.text == "player1")
        {
            namee = p1name;
            score = p1score;
        }
        else if (p1name.text != "player1")
        {
            namee = p2name;
            score = p2score;
        }

        playerNameInstance = Instantiate<TMP_Text>(playerNamePrefab);
        playerNameInstance.transform.SetParent(GameObject.FindWithTag("PlayerCanvas").transform, false);

        if (isLocalPlayer)
        {
            SetName();
            ChaseCamera.target = transform;
        }
        else
        {
            playerNameInstance.text = playerName;
            GetComponent<PlayerController>().enabled = false;
        }

        //startScreen.SetActive(false);
    }

    void FixedUpdate()
    {
        if(timer.IsFinished() == true)
        {
            StartCoroutine("End");
            
        }
    }

    void LateUpdate()
    {
        if(isLocalPlayer)
        {
            playerNameInstance.transform.position = transform.position + Vector3.up * 0.15f;
            playerNameInstance.transform.LookAt(Camera.main.transform);
        }
        
    }

    void OnDisable()
    {
        Destroy(playerNameInstance);
    }

    void RandomName()
    {
        GameObject[] players = GameObject.FindGameObjectsWithTag("Player");
        string tempPlayerName = names[players.Length - 1];
        CmdUpdatePlayerName(tempPlayerName);
    }

    void SetName()
    {
        GameObject[] players = GameObject.FindGameObjectsWithTag("Player");
        CmdUpdatePlayerName(pName);
    }

    [Command]
    void CmdUpdatePlayerName(string newPlayerName)
    {
        playerName = newPlayerName;
        namee.text = playerName;
        playerNameInstance.text = playerName;
    }

    void OnNameChange(string oldPlayerName, string newPlayerName)
    {
        if (playerNameInstance == null) return;
        playerName = newPlayerName;
        namee.text = playerName;
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

                //change herdCount based on sheep.GetComponent<SheepController>().GetColor() ***

                if (sheep.GetComponent<SheepController>().GetColor() == "gold")
                {
                    herdCount += 10;
                }
                if (sheep.GetComponent<SheepController>().GetColor() == pColor)
                {
                    herdCount += 2;
                }
                else
                {
                    herdCount++;
                }
                Debug.Log(herdCount.ToString());

                CmdUpdateScore();
            }
        }
    }

    [Command]
    void CmdUpdateScore()
    {
        score.text = herdCount.ToString();
    }

    void OnScoreChange(int oldScore, int newScore)
    {
        score.text = newScore.ToString();
    }

    [Command]
    void CmdUpdateName()
    {
        score.text = herdCount.ToString();
    }

    void OnNameChange(string oldName, int newName)
    {
        score.text = newName.ToString();
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

    IEnumerator End()
    {
        yield return new WaitForSeconds(1);
        //endScreen.SetActive(true);
    }
}

