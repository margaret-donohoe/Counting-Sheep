using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class CharacterCustomization : MonoBehaviour
{
    public Button submit;
    public TMP_InputField nameInput;
    private string playerName;
    public Image createdPlayer;
    public GameObject chooseFirst;

    private GameObject playerBase;
    private string baseText;
    //private Material playerMaterial;
    private string matText;

    public Button chooseBoy0;
    public Button chooseBoy2;
    public Button chooseBoy3;
    public Button chooseGirl0;
    public Button chooseGirl1;
    public Button chooseGirl3;

    public Button choosePink;
    public Button chooseGreen;
    public Button chooseGrey;
    public Button chooseYellow;
    public Button chooseBlue;
    public Button chooseBlack;

    public GameObject boy0;
    public GameObject boy2;
    public GameObject boy3;
    public GameObject girl0;
    public GameObject girl1;
    public GameObject girl3;

    public Sprite boy0base;
    public Sprite boy2base;
    public Sprite boy3base;
    public Sprite girl0base;
    public Sprite girl1base;
    public Sprite girl3base;

    public Sprite boy0pink;
    public Sprite boy0green;
    public Sprite boy0grey;
    public Sprite boy0yellow;
    public Sprite boy0blue;
    public Sprite boy0black;

    public Sprite boy2pink;
    public Sprite boy2green;
    public Sprite boy2grey;
    public Sprite boy2yellow;
    public Sprite boy2blue;
    public Sprite boy2black;

    public Sprite boy3pink;
    public Sprite boy3green;
    public Sprite boy3grey;
    public Sprite boy3yellow;
    public Sprite boy3blue;
    public Sprite boy3black;

    public Sprite girl0pink;
    public Sprite girl0green;
    public Sprite girl0grey;
    public Sprite girl0yellow;
    public Sprite girl0blue;
    public Sprite girl0black;

    public Sprite girl1pink;
    public Sprite girl1green;
    public Sprite girl1grey;
    public Sprite girl1yellow;
    public Sprite girl1blue;
    public Sprite girl1black;

    public Sprite girl3pink;
    public Sprite girl3green;
    public Sprite girl3grey;
    public Sprite girl3yellow;
    public Sprite girl3blue;
    public Sprite girl3black;

    // Start is called before the first frame update
    void Start()
    {
        submit.onClick.AddListener(SetCharacter);
        chooseFirst.SetActive(false);

        chooseBoy0.onClick.AddListener(() => CustomizeBase(boy0));
        chooseBoy2.onClick.AddListener(() => CustomizeBase(boy2));
        chooseBoy3.onClick.AddListener(() => CustomizeBase(boy3));
        chooseGirl0.onClick.AddListener(() => CustomizeBase(girl0));
        chooseGirl1.onClick.AddListener(() => CustomizeBase(girl1));
        chooseGirl3.onClick.AddListener(() => CustomizeBase(girl3));

        choosePink.onClick.AddListener(() => CustomizeMat("pink"));
        chooseGreen.onClick.AddListener(() => CustomizeMat("green"));
        chooseGrey.onClick.AddListener(() => CustomizeMat("grey"));
        chooseYellow.onClick.AddListener(() => CustomizeMat("yellow"));
        chooseBlue.onClick.AddListener(() => CustomizeMat("blue"));
        chooseBlack.onClick.AddListener(() => CustomizeMat("black"));
    }


    void CustomizeBase(GameObject child)
    {
        
        playerBase = child;

        if (child == boy0)
        {
            createdPlayer.sprite = boy0base;
            //SET USING SCREENSHOT
            baseText = "boy0";
        }

        if (child == boy2)
        {
            createdPlayer.sprite = boy2base;
            baseText = "boy2";
        }

        if (child == boy3)
        {
            createdPlayer.sprite = boy3base;
            baseText = "boy3";
        }

        if (child == girl0)
        {
            createdPlayer.sprite = girl0base;
            baseText = "girl0";
        }

        if (child == girl1)
        {
            createdPlayer.sprite = girl1base;
            baseText = "girl1";
        }

        if (child == girl3)
        {
            createdPlayer.sprite = girl3base;
            baseText = "girl3";
        }
    }

    void CustomizeMat(string color)
    {
        if (baseText == null)
        {
            chooseFirst.SetActive(true);
            StartCoroutine(Fade());
        }

        if (color == "pink" && playerBase != null)
        {
            matText = "pink";

            if(playerBase == boy0)
            {
                createdPlayer.sprite = boy0pink;
            }

            if (playerBase == boy2)
            {
                createdPlayer.sprite = boy2pink;
            }

            if (playerBase == boy3)
            {
                createdPlayer.sprite = boy3pink;
            }

            if (playerBase == girl0)
            {
                createdPlayer.sprite = girl0pink;
            }

            if (playerBase == girl1)
            {
                createdPlayer.sprite = girl1pink;
            }

            if (playerBase == girl3)
            {
                createdPlayer.sprite = girl3pink;
            }
        }

        if (color == "green" && playerBase != null)
        {
            matText = "green";

            if (playerBase == boy0)
            {
                createdPlayer.sprite = boy0green;
            }

            if (playerBase == boy2)
            {
                createdPlayer.sprite = boy2green;
            }

            if (playerBase == boy3)
            {
                createdPlayer.sprite = boy3green;
            }

            if (playerBase == girl0)
            {
                createdPlayer.sprite = girl0green;
            }

            if (playerBase == girl1)
            {
                createdPlayer.sprite = girl1green;
            }

            if (playerBase == girl3)
            {
                createdPlayer.sprite = girl3green;
            }
        }

        if (color == "grey" && playerBase != null)
        {
            matText = "grey";

            if (playerBase == boy0)
            {
                createdPlayer.sprite = boy0grey;
            }

            if (playerBase == boy2)
            {
                createdPlayer.sprite = boy2grey;
            }

            if (playerBase == boy3)
            {
                createdPlayer.sprite = boy3grey;
            }

            if (playerBase == girl0)
            {
                createdPlayer.sprite = girl0grey;
            }

            if (playerBase == girl1)
            {
                createdPlayer.sprite = girl1grey;
            }

            if (playerBase == girl3)
            {
                createdPlayer.sprite = girl3grey;
            }
        }

        if (color == "yellow" && playerBase != null)
        {
            matText = "yellow";

            if (playerBase == boy0)
            {
                createdPlayer.sprite = boy0yellow;
            }

            if (playerBase == boy2)
            {
                createdPlayer.sprite = boy2yellow;
            }

            if (playerBase == boy3)
            {
                createdPlayer.sprite = boy3yellow;
            }

            if (playerBase == girl0)
            {
                createdPlayer.sprite = girl0yellow;
            }

            if (playerBase == girl1)
            {
                createdPlayer.sprite = girl1yellow;
            }

            if (playerBase == girl3)
            {
                createdPlayer.sprite = girl3yellow;
            }
        }

        if (color == "blue" && playerBase != null)
        {
            matText = "blue";

            if (playerBase == boy0)
            {
                createdPlayer.sprite = boy0blue;
            }

            if (playerBase == boy2)
            {
                createdPlayer.sprite = boy2blue;
            }

            if (playerBase == boy3)
            {
                createdPlayer.sprite = boy3blue;
            }

            if (playerBase == girl0)
            {
                createdPlayer.sprite = girl0blue;
            }

            if (playerBase == girl1)
            {
                createdPlayer.sprite = girl1blue;
            }

            if (playerBase == girl3)
            {
                createdPlayer.sprite = girl3blue;
            }
        }

        if (color == "black" && playerBase != null)
        {
            matText = "black";

            if (playerBase == boy0)
            {
                createdPlayer.sprite = boy0black;
            }

            if (playerBase == boy2)
            {
                createdPlayer.sprite = boy2black;
            }

            if (playerBase == boy3)
            {
                createdPlayer.sprite = boy3black;
            }

            if (playerBase == girl0)
            {
                createdPlayer.sprite = girl0black;
            }

            if (playerBase == girl1)
            {
                createdPlayer.sprite = girl1black;
            }

            if (playerBase == girl3)
            {
                createdPlayer.sprite = girl3black;
            }
        }

        matText = color;
    }

    void SetCharacter()
    {
        if(nameInput.text != null && baseText != null && matText != null)
        {
            playerName = nameInput.text;
            PlayerPrefs.SetString("name", playerName);
            PlayerPrefs.SetString("base", baseText);
            PlayerPrefs.SetString("material", matText);
        }
    }

    IEnumerator Fade()
    {
        float alpha = 1;
        yield return new WaitForSeconds(0.5f);
        while (chooseFirst.GetComponent<TMP_Text>().alpha > 0)
        {
            alpha -= 0.05f;
            chooseFirst.GetComponent<TMP_Text>().alpha = alpha;
            yield return new WaitForSeconds(0.05f);
        }
        chooseFirst.SetActive(false);
    }
}
