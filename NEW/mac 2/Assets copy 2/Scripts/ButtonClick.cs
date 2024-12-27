using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ButtonClick : MonoBehaviour
{
    private Button button;
    private AudioSource click;
    // Start is called before the first frame update
    void Start()
    {
        button = GetComponent<Button>();
        click = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Onclick()
    {
        click.Play();
    }
}
