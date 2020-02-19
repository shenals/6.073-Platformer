using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{	
	public Text timer1, timer2, score1, score2, hp1, hp2;
    public int scorevalue, hp1value, hp2value;
    public Platformer player1, player2;
    // Start is called before the first frame update
    void Start()
    {
        scorevalue = 0;
        hp1value = 0;
        hp2value = 0;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        score1.text = "Score: " + scorevalue.ToString();
        score2.text = "Score: " + scorevalue.ToString();
        timer1.text = "Time: " + Mathf.Round(Time.timeSinceLevelLoad).ToString();
        timer2.text = "Time: " + Mathf.Round(Time.timeSinceLevelLoad).ToString();
        hp1value = player1.hp;
        hp2value = player2.hp;
        hp1.text = "HP: " + player2.hp.ToString();
        hp2.text = "HP: " + player1.hp.ToString();
    }
}
