using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;
	public Text timer1, timer2, score1, score2, hp1, hp2, GameOverText;
    public int scorevalue, hp1value, hp2value;
    public float time;
    public Platformer player1, player2;
    public TutorialManager tutorial;
    public GameObject GameOverPanel;
    // Start is called before the first frame update
    void Start()
    {
        Time.timeScale = 1.0f;
        instance = this;
        scorevalue = 0;
        hp1value = 0;
        hp2value = 0;
        time = 0;
    }

    public void ResetUI(){
        player1.hp = Platformer.MAX_HP;
        player2.hp = Platformer.MAX_HP;
        scorevalue = 0;
        time = 0;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        score1.text = "Score: " + scorevalue.ToString();
        score2.text = "Score: " + scorevalue.ToString();
        GameOverText.text = "Score: " + scorevalue.ToString();
        
        time += Time.deltaTime;
        timer1.text = "Time: " + Mathf.Round(time).ToString();
        timer2.text = "Time: " + Mathf.Round(time).ToString();
        
        hp1value = player1.hp;
        hp2value = player2.hp;
        hp1.text = "HP: " + player2.hp.ToString();
        hp2.text = "HP: " + player1.hp.ToString();

        //Game Over
        if(tutorial.isTutorialDone() && (hp1value <= 0 || hp2value <= 0)){
            Time.timeScale = 0;
            GameOverPanel.SetActive(true);
        }
    }

    public void incrementScore()
    {
        if ((hp1value > 0 && hp2value > 0))
        {
            scorevalue++;
        }
    }
}
