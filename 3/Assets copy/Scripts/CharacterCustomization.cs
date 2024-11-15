using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CharacterCustomization : MonoBehaviour
{
    public Button submit;
    public InputField nameInput;
    private string playerName;

    private GameObject playerBase;
    private string baseText;
    private Material playerMaterial;
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

    // Start is called before the first frame update
    void Start()
    {
        submit.onClick.AddListener(SetCharacter);

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
        if (child == boy0)
        {
            //SET PLAYERBASE, PLUS SET PAJAMAS IF playerMaterial != null
        }

        if (child == boy2)
        {

        }

        if (child == boy3)
        {

        }

        if (child == girl0)
        {

        }

        if (child == girl1)
        {

        }

        if (child == girl3)
        {

        }

        baseText = playerBase.name.ToString();
    }

    void CustomizeMat(string color)
    {
        if (color == "pink")
        {
            //SET PLAYERMATERIAL. 6 if statements in each here, based on which base
        }

        if (color == "green")
        {

        }

        if (color == "grey")
        {

        }

        if (color == "yellow")
        {

        }

        if (color == "blue")
        {

        }

        if (color == "black")
        {

        }

        matText = playerMaterial.name.ToString();
    }

    void SetCharacter()
    {
        playerName = nameInput.text;
        PlayerPrefs.SetString("name",playerName);
        PlayerPrefs.SetString("base", baseText);
        PlayerPrefs.SetString("material", matText);
    }
}
