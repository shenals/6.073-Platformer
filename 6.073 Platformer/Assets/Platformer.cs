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

    public GameObject bulletPrefab;
    public GameObject enemyPrefab;

    private System.Random rng;

    private double enemySpawnCooldown = 0.0;
    private int enemiesSpawned = 0;

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
        rng = new System.Random();
    }

    // Update is called once per frame
    void Update()
    {
        int rightitude = 0;
        if (getLeft())  rightitude -= 1;
        if (getRight()) rightitude += 1;
        rb.velocity = new Vector2(5 * rightitude, rb.velocity.y);
        if (getUpDown() && rb.velocity.y == 0)
        {
            rb.velocity = new Vector2(rb.velocity.x, rb.velocity.y + 20);
        }
        //shoot
        if(getShootDown()) ShootBullet();

        if (enemySpawnCooldown <= 0)
        {
            SpawnEnemy();
            enemiesSpawned += 1;
            enemySpawnCooldown = 30 / (1 + 0.1 * enemiesSpawned);
        }
        else
        {
            enemySpawnCooldown -= Time.deltaTime;
        }
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

    void SpawnEnemy()
    {
        Vector2 dir = new Vector2(2 * (float) rng.NextDouble() - 1, (float) rng.NextDouble());
        dir = dir / dir.magnitude;
        Enemy enemy = Instantiate(enemyPrefab, this.transform.position + (Vector3) dir * 15, new Quaternion(0, 0, 0, 1))
            .GetComponent<Enemy>();
        enemy.target = this;
    }
}
