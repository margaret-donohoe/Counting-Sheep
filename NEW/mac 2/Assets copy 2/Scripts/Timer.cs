using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Timer : MonoBehaviour
{
    private bool done = false;
    private bool timerOn = false;
    private float duration = 121; //31 for testing
    private float timeRemaining;

    public TMP_Text timerText;

    // Start is called before the first frame update
    void Start()
    {
        timeRemaining = duration;
    }

    // Update is called once per frame
    void Update()
    {
        if(timerOn == true && timeRemaining > 0)
        {
            timeRemaining -= Time.deltaTime;
            int seconds = ((int)timeRemaining % 60);
            int minutes = ((int)timeRemaining / 60);
            string time = string.Format("{0:00}:{1:00}", minutes, seconds);
            timerText.text = time;
        }

        else if(timeRemaining <= 0)
        {
            done = true;
        }
    }

    public void StartTimer()
    {
        timerOn = true;
    }

    public bool IsActive()
    {
        return timerOn;
    }

    public bool IsFinished()
    {
        return done;
    }

    public float TimeLeft()
    {
        return timeRemaining;
    }
    //WHEN TIMER ENDS, CALL PLAYERNETWORKING FOR END SCREEN
}
