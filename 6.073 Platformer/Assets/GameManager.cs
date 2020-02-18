using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{	
	public Text timer1, timer2, score1, score2, hp1, hp2;
    public Platformer player1, player2;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        timer1.text = "Time: " + Mathf.Round(Time.timeSinceLevelLoad).ToString();
        timer2.text = "Time: " + Mathf.Round(Time.timeSinceLevelLoad).ToString();
        hp1.text = "HP: " + player1.hp.ToString();
        hp2.text = "HP: " + player2.hp.ToString();
    }
}
