using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Score : MonoBehaviour
{

    public TextMeshProUGUI playerScoreText;
    public TextMeshProUGUI enemyScoreText;


    void Start()
    {

    }


    void Update()
    {
        if(PlayerController.power == 0)
        {
            playerScoreText.text = "Player Score\n" + PlayerController.power.ToString("0");
        }
        else if(PlayerController.power < 10)
        {
            playerScoreText.text = "Player Score\n" + PlayerController.power.ToString("0") + "00";
        }
        else if(PlayerController.power >= 10)
        {
            playerScoreText.text = "Player Score\n" + PlayerController.power.ToString("0") + "0";
        }



        if(Enemy.power == 0)
        {
            enemyScoreText.text = "Enemy Score\n" + Enemy.power.ToString("0");
        }
        else if(Enemy.power < 10)
        {
            enemyScoreText.text = "Enemy Score\n" + Enemy.power.ToString("0") + "00";
        }
        else if(Enemy.power >= 10)
        {
            enemyScoreText.text = "Enemy Score\n" + Enemy.power.ToString("0") + "0";
        }
        
    }
}
