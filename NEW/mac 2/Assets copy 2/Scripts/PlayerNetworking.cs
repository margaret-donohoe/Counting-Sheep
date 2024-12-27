using Mirror;
using TMPro;
using UnityEngine;
using System.Collections;

public class PlayerNetworking : NetworkBehaviour
{
   
    public TMP_Text playerNamePrefab;
    TMP_Text playerNameInstance;

    [SyncVar(hook = nameof(OnNameChange))]
    public string playerName = "Player";

    

    private string pName; //***********************************

    [SyncVar]
    public string pColor;


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

    private TMP_Text winnerName;
    private TMP_Text winnerScore;
    private TMP_Text loserName;
    private TMP_Text loserScore;

    private AudioSource music1;
    private AudioSource music2;

    // Start is called before the first frame update
    void Start()
    {

        music1 = GameObject.Find("Moosic1").GetComponent<AudioSource>();
        music2 = GameObject.Find("Moosic2").GetComponent<AudioSource>();
        

        //UNCOMMENT BELOW ONCE CHARACTER CREATOR IS IMPLEMENTED
        timer = GameObject.FindObjectsOfType<Timer>()[0];

        startScreen = GameObject.FindWithTag("Start");
        endScreen = GameObject.FindWithTag("End");



        p1name = GameObject.Find("p1name").GetComponent<TMP_Text>();
        p2name = GameObject.Find("p2name").GetComponent<TMP_Text>();
        p1score = GameObject.Find("p1score").GetComponent<TMP_Text>();
        p2score = GameObject.Find("p2score").GetComponent<TMP_Text>();

        if (isLocalPlayer)
        {
            pName = PlayerPrefs.GetString("name");
            pColor = PlayerPrefs.GetString("material");
            
        }
            
            
        visibleRange.SetActive(false);

        

        playerNameInstance = Instantiate<TMP_Text>(playerNamePrefab);
        playerNameInstance.transform.SetParent(GameObject.FindWithTag("PlayerCanvas").transform, false);

        if (isLocalPlayer)
        {
            SetName();
            ChaseCamera.target = transform;
        }

        else
        {
            //SetName();
            playerNameInstance.text = playerName;
            //GetComponent<PlayerController>().enabled = false;
        }

        

    }

    void FixedUpdate()
    {
        GameObject[] players = GameObject.FindGameObjectsWithTag("Player");
        if(players.Length > 2 && timer.IsActive() == false)
        {
            timer.StartTimer();
            music1.Play();
            music2.Play();
            music2.mute = true;

            if (startScreen.activeInHierarchy == true)
            {
                startScreen.SetActive(false);
            }

            if (endScreen.activeInHierarchy == true)
            {
                endScreen.SetActive(false);
            }
        }

        if (timer.IsFinished() == true)
        {
            StartCoroutine("End");
            
        }

    }

    void LateUpdate()
    {
            playerNameInstance.transform.position = transform.position + Vector3.up * 0.15f;
            playerNameInstance.transform.LookAt(Camera.main.transform);

        if (p1name.text == "player1" && p2name.text != playerName)
        {
            namee = p1name;
            score = p1score;
            namee.text = playerName;
        }
    }

    void OnDisable()
    {
        Destroy(playerNameInstance);
    }

    void SetName()
    {
        GameObject[] players = GameObject.FindGameObjectsWithTag("Player");
        CmdUpdatePlayerName(pName);
    }

   

    [Command(requiresAuthority = false)]
    void CmdUpdatePlayerName(string newPlayerName)
    {
        playerName = newPlayerName;
        //GameObject[] players = GameObject.FindGameObjectsWithTag("Player");
        //namee.text = playerName;
        playerNameInstance.text = playerName;
        //OnNameChange(playerName);
    }

    //[ClientRpc]
    void OnNameChange(string oldPlayerName, string newPlayerName)
    {
        if (playerNameInstance == null) return;

        GameObject[] players = GameObject.FindGameObjectsWithTag("Player");

        //Scoreboard();
        if (players.Length <= 2)
        {
            namee = p1name;
            score = p1score;
        }

        else
        {
            namee = p2name;
            score = p2score;
        }

        namee.text = playerName;
        playerName = newPlayerName;
        
        playerNameInstance.text = playerName;
    }

    //try using this
    public void Scoreboard()
    {
        GameObject[] players = GameObject.FindGameObjectsWithTag("Player");

        if (players.Length <= 2)
        {
            namee = p1name;
            score = p1score;
        }

        else
        {
            namee = p2name;
            score = p2score;
        }
        namee.text = playerName;
    }


    [Command(requiresAuthority = false)]
    public void MakeSheepFollow()
    {
        RpcMessageRange();
        GameObject[] spawnedSheep = GameObject.FindGameObjectsWithTag("Sheep");

        foreach (GameObject sheep in spawnedSheep)
        {
            
            if (Vector3.Distance(sheep.transform.position, gameObject.transform.position) < 5 && sheep.GetComponent<SheepController>().GetDiscoverable() == true)
            {
                //Follow(sheep);
                sheep.GetComponent<SheepController>().FollowPlayer(gameObject, gameObject);

                //change herdCount based on sheep.GetComponent<SheepController>().GetColor() ***
                sheep.GetComponent<SheepController>().FollowPlayer(gameObject, gameObject);

                Debug.Log(pColor.ToString());

                if (sheep.GetComponent<SheepController>().GetColor() == "gold")
                {
                    herdCount += 10;
                }
                if (sheep.GetComponent<SheepController>().GetColor() == gameObject.GetComponent<PlayerObj>().SendColor())
                {
                    herdCount += 2;
                }
                else
                {
                    herdCount++;
                }
                CmdUpdateScore();

            }
        }
    }

    //[ClientRpc]
    //public void Follow(GameObject s)
    //{
    //    s.GetComponent<SheepController>().FollowPlayer(gameObject, gameObject);

    //    if (s.GetComponent<SheepController>().GetColor() == "gold")
    //    {
    //        herdCount += 10;
    //    }
    //    if (s.GetComponent<SheepController>().GetColor() == pColor)
    //    {
    //        herdCount += 2;
    //    }
    //    else
    //    {
    //        herdCount++;
    //    }
    //    CmdUpdateScore();
    //}

    [Command(requiresAuthority = false)]
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
        if (endScreen.activeInHierarchy == false)
        {
            music1.mute = true;
            music2.mute = false;
            endScreen.SetActive(true);

            GetComponent<PlayerController>().enabled = false;

            winnerName = GameObject.Find("winner").GetComponent<TMP_Text>();
            winnerScore = GameObject.Find("winnerScore").GetComponent<TMP_Text>();
            loserName = GameObject.Find("loser").GetComponent<TMP_Text>();
            loserScore = GameObject.Find("loserScore").GetComponent<TMP_Text>();

            int scoreOne;
            int scoreTwo;

            int.TryParse(p1score.text, out scoreOne);
            int.TryParse(p2score.text, out scoreTwo);

            if(scoreOne > scoreTwo)
            {
                winnerName.text = p1name.text;
                winnerScore.text = p1score.text;
                loserName.text = p2name.text;
                loserScore.text = p2score.text;
            }

            if (scoreOne < scoreTwo)
            {
                winnerName.text = p2name.text;
                winnerScore.text = p2score.text;
                loserName.text = p1name.text;
                loserScore.text = p1score.text;
            }

            else if(scoreOne == scoreTwo)
            {
                winnerName.text = p1name.text + " & " + p2name.text;
                winnerScore.text = p1score.text;
            }
        }
    }
}

