using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Platformer : MonoBehaviour
{	
	public Rigidbody2D rb;
    [SerializeField]
    public bool isWASD;
    // Start is called before the first frame update
    private int hp_value;
    private int invuln_cooldown;

    public int hp
    {
        get { return hp_value; }
        set
        {
            if (invuln_cooldown <= 0)
            {
                hp_value = value;
                invuln_cooldown = 20; // lol stupid hacks}
            }
        }
    }
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        hp = 5;
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
            if (Input.GetKeyDown("up") && rb.velocity.y == 0)
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
            if (Input.GetKeyDown(KeyCode.W) && rb.velocity.y == 0)
            {
                rb.velocity = new Vector2(rb.velocity.x, rb.velocity.y + 20);
            }
        }
    }

    void FixedUpdate()
    {
        if (--invuln_cooldown < 0)
        {
            invuln_cooldown = 0;
        }
    }
}
