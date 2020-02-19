using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public class Bullet : MonoBehaviour
{

	public float velocity = 2.0f;
	Vector2 dir;

    // Start is called before the first frame update
    void Start()
    {   
    }

    // Update is called once per frame
    void Update()
    {
    }

    void FixedUpdate()
    {
        transform.Translate(dir * velocity * Time.deltaTime);
    }

    public void SetDir(Vector2 dir){
    	this.dir = dir.normalized;
    }

    void OnTriggerEnter2D(Collider2D col)
    {
    	GameObject collided = col.gameObject;
    	if(collided.GetComponent<Enemy>() != null){ // bullet colliding with enemy
    		Destroy(collided);
            Destroy(this.gameObject);
            GameManager.instance.incrementScore();
        }
    	if(collided.GetComponent<Platformer>() == null){ // bullet is colliding with something that is not the player
    		Destroy(this.gameObject);
    	}
        
    }

}
