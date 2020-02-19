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
    public float walk_speed;
    public float jump_speed;

    public GameObject bulletPrefab;
    public GameObject enemyPrefab;

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
        if (getLeft())  rightitude -= 1;
        if (getRight()) rightitude += 1;
        rb.velocity = new Vector2(walk_speed * rightitude, rb.velocity.y);
        if (getUpDown() && rb.velocity.y == 0) // TODO: fix this horrible hack
        {
            rb.velocity = new Vector2(rb.velocity.x, rb.velocity.y + jump_speed);
        }
        //shoot
        if(getShootDown()) ShootBullet();
    }

    private bool getLeft()
    {
        return isWASD ? Input.GetKey(KeyCode.A) : Input.GetKey(KeyCode.LeftArrow);
    }

    private bool getRight()
    {
        return isWASD ? Input.GetKey(KeyCode.D) : Input.GetKey(KeyCode.RightArrow);
    }

    private bool getUp()
    {
        return isWASD ? Input.GetKey(KeyCode.W) : Input.GetKey(KeyCode.UpArrow);
    }

    private bool getDown()
    {
        return isWASD ? Input.GetKey(KeyCode.S) : Input.GetKey(KeyCode.DownArrow);
    }

    private bool getUpDown() // note that this means when the up key is pressed down
    {
        return isWASD ? Input.GetKeyDown(KeyCode.W) : Input.GetKeyDown(KeyCode.UpArrow);
    }

    private bool getShootDown()
    {
        return isWASD ? Input.GetKeyDown(KeyCode.Space) : Input.GetKeyDown(KeyCode.Slash);
    }

    void ShootBullet()
    {
        Vector2 dir = new Vector2(0, 0);
        if (getRight())
        {
            dir += new Vector2(1, 0);
        }
        if (getLeft())
        {
            dir += new Vector2(-1, 0);
        }
        if (getUp())
        {
            dir += new Vector2(0, 1);
        }
        if (getDown())
        {
            dir += new Vector2(0, -1);
        }
        if (!(dir.x == 0 && dir.y == 0))
        {
            Bullet bullet = Instantiate(bulletPrefab, this.transform.position, Quaternion.AngleAxis(180, dir)).GetComponent<Bullet>();
            bullet.SetDir(dir);
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
