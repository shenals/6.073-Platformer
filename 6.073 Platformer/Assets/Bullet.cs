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
    	Debug.Log("colliding with: " + collided);
    	if(collided.GetComponent<Enemy>() != null){
    		Destroy(collided);
    		Debug.Log("destroying enemy");
    	}
    	if(collided.GetComponent<Platformer>() == null){//don't destroy if it collides with itself
    		Destroy(this.gameObject);
    		Debug.Log("destroying bullet??? in trigger?");
    	}
        
    }

    void OnCollisionEnter2D(Collision2D col)
    {
    	GameObject collided = col.collider.gameObject;
    	if(collided.GetComponent<Platformer>() == null){//don't destroy if it collides with itself
    		Destroy(this.gameObject);
    		Debug.Log("destroying bullet");
    	}
        
    }

}
