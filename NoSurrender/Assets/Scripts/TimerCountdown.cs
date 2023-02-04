using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class TimerCountdown : MonoBehaviour
{
    
    float currentTime;
    public float startingTime = 60f;
    public TextMeshProUGUI countdownText;



    void Start()
    {
        // Sets the starting time of the timer to the current time when the game starts
        currentTime = startingTime;
    }


    void Update()
    {
        // Substracts 1 from the current time every second
        currentTime -= 1 * Time.deltaTime;

        // Writes the current time to the screen
        countdownText.text = "Time Left \n" + "      " + currentTime.ToString("0");

        // When the time is up, the game will end
        if(currentTime <= 0)
        {
            currentTime = 0;
            PlayerController.isGameOver = true;
        }
    }

}
