using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TutorialManager : MonoBehaviour
{
	//tutorial popups - should be same length
	public GameObject[] popUpsPlayer1;
	public GameObject[] popUpsPlayer2;

	private int popUpIndex;

    public Camera player1InnerCam;
    public Camera player2InnerCam;
    public Camera player1OuterCam;
    public Camera player2OuterCam;

    public GameObject p1Spawner;
    public GameObject p2Spawner;

    //whether players have completed a step in the tutorial
    private bool player1Done;
    private bool player2Done;

    private bool TutorialDone = false;

    public GameObject blackOut;
    // Start is called before the first frame update
    void Start()
    {
    	DisablePOVCameras();
    	SwapOuterCameras();

    	StartCoroutine(WaitForBlinking());
   	}

    // Update is called once per frame
    void Update()
    {
        for(int i = 0; i < popUpsPlayer1.Length; i++){
        	if(i == popUpIndex){
        		popUpsPlayer1[i].SetActive(true);
        		popUpsPlayer2[i].SetActive(true);
        	}
        	else{
        		popUpsPlayer1[i].SetActive(false);
        		popUpsPlayer2[i].SetActive(false);
        	}
        }

        if(popUpIndex == 0){ //0: tell players to move with WASD or arrow keys
        	if(AnyWASDKey()){
        		player1Done = true;
        	}
        	if(AnyArrowKey()){
        		player2Done = true;
        	}
        	if(player1Done && player2Done){
        		Transition();
        	}
        }
        else if(popUpIndex == 1){ //1: tell players how to shoot
        	p1Spawner.SetActive(true);
        	p2Spawner.SetActive(true);
        	if(Input.GetKeyDown(KeyCode.Space) && AnyWASDKey()){
        		player1Done = true;
        	}
        	if(Input.GetKeyDown(KeyCode.Slash) && AnyArrowKey()){
        		player2Done = true;
        	}
        	if(player1Done && player2Done){
        		Transition();
        	}
        }

        //popUpIndex == 2 is taken care of by coroutine

        else if(popUpIndex == 3){//3: 
        	p1Spawner.SetActive(true);
        	p2Spawner.SetActive(true);
        	if(Input.GetKeyDown(KeyCode.B)){
        		Transition();
        		GameManager.instance.ResetUI();
                TutorialDone = true;
        		Debug.Log("reset?");
        	}
        }
    }

    public bool isTutorialDone(){
        return TutorialDone;
    }

    IEnumerator WaitForBlinking(){
    	yield return new WaitUntil(() => popUpIndex == 2);
    	Debug.Log("STARTING");
    	StartCoroutine(Blink());
    }

    IEnumerator Blink(){
    	Debug.Log("in coroutine");

    	p1Spawner.SetActive(false);
        p2Spawner.SetActive(false);

    	yield return new WaitForSeconds(1.0f);

    	blackOut.SetActive(true);
       	
       	yield return new WaitForSeconds(2.0f);

        SwapOuterCameras();
        EnablePOVCameras();
        blackOut.SetActive(false);
        Transition();
    }

    void Transition(){
    	popUpIndex++;
    	player1Done = false;
    	player2Done = false;
    	Debug.Log("transitioned");
    }

    bool AnyWASDKey(){
    	return Input.GetKey(KeyCode.W) || 
    		   Input.GetKey(KeyCode.A) || 
    		   Input.GetKey(KeyCode.S) || 
    		   Input.GetKey(KeyCode.D);
    }

    bool AnyArrowKey(){
    	return Input.GetKey(KeyCode.RightArrow) || 
    		   Input.GetKey(KeyCode.LeftArrow) || 
    		   Input.GetKey(KeyCode.DownArrow) || 
    		   Input.GetKey(KeyCode.UpArrow);
    }

    void EnablePOVCameras(){
    	player1InnerCam.enabled = true;
    	player2InnerCam.enabled = true;
    }

    void DisablePOVCameras(){
    	player1InnerCam.enabled = false;
    	player2InnerCam.enabled = false;
    }

    void SwapOuterCameras(){
    	Rect temp = player1OuterCam.rect;
    	player1OuterCam.rect = player2OuterCam.rect;
    	player2OuterCam.rect = temp;
    }
}
