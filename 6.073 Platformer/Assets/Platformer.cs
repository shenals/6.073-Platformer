using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Platformer : MonoBehaviour
{	
	public Rigidbody2D rb;
    [SerializeField]
    public bool isWASD;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();   
    }

    // Update is called once per frame
    void Update()
    {
        int rightitude = 0;
        if(!isWASD){
            if (Input.GetKey("left"))
            {
                // rb.velocity = new Vector2(-5, 0);
                rightitude -= 1;
            }    
            if (Input.GetKey("right"))
            {
                rightitude += 1;
            }
            rb.velocity = new Vector2(5 * rightitude, rb.velocity.y);
            if (Input.GetKeyDown("up"))
            {
                rb.velocity = new Vector2(rb.velocity.x, rb.velocity.y + 20);
            }
        }
        else{
            if (Input.GetKey(KeyCode.A))
            {
                // rb.velocity = new Vector2(-5, 0);
                rightitude -= 1;
            }    
            if (Input.GetKey(KeyCode.D))
            {
                rightitude += 1;
            }
            rb.velocity = new Vector2(5 * rightitude, rb.velocity.y);
            if (Input.GetKeyDown(KeyCode.W))
            {
                rb.velocity = new Vector2(rb.velocity.x, rb.velocity.y + 20);
            }
        }
    }
}
