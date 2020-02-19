﻿using System.Collections;
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

    public float maxBulletCooldown = 0.0f;//2f;
    private float bulletCooldown;

    public GameObject bulletPrefab;
    public GameObject enemyPrefab;

    private System.Random rng;

    private double enemySpawnCooldown = 0.0;
    private int enemiesSpawned = 0;

    public GameManager manager;

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
        bulletCooldown = maxBulletCooldown;
        rng = new System.Random();
    }

    // Update is called once per frame
    void Update()
    {
        int rightitude = 0;
        if(!isWASD){
            //movement
            if(!Input.GetKey(KeyCode.Slash) || true){
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
            //shoot
            if(Input.GetKeyDown(KeyCode.Slash)){// && bulletCooldown <= 0){
                ShootBulletArrow();
            }
        }
        else{
            //movement
            if(!Input.GetKey(KeyCode.Space) || true){
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

            //shoot
            if(Input.GetKeyDown(KeyCode.Space)){ // && bulletCooldown <= 0){
                ShootBulletWASD();
            }
        }

        if (bulletCooldown  > 0){
            bulletCooldown -= Time.deltaTime;
        }
        else{
            bulletCooldown = maxBulletCooldown;
        }

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

    void ShootBulletArrow(){
        Vector2 dir = new Vector2(0, 0); //default
        /*if(Input.GetKey("up") && Input.GetKey("right")){
            dir = Vector2.forward + Vector.
        }
        else if(Input.GetKey("up") && Input.GetKey("left")){
            dir = Direction.UP_LEFT;
        }
        else if(Input.GetKey("down") && Input.GetKey("right")){
            dir = Direction.DOWN_RIGHT;
        }
        else if(Input.GetKey("down") && Input.GetKey("left")){
            dir = Direction.DOWN_LEFT;
        }*/
        if(Input.GetKey("right")){
            dir += new Vector2(1,0);
        }
        if(Input.GetKey("left")){
            dir += new Vector2(-1,0);
        }
        if(Input.GetKey("up")){
            dir += new Vector2(0,1);
        }
        if(Input.GetKey("down")){
            dir += new Vector2(0,-1);
        }
        if(!(dir.x == 0 && dir.y == 0)){
            Bullet bullet = Instantiate(bulletPrefab, this.transform.position, Quaternion.AngleAxis (180, dir)).GetComponent<Bullet>();
            bullet.SetDir(dir);
            bullet.manager = manager;
        }
    }

    void ShootBulletWASD(){
        Vector2 dir = new Vector2(0, 0); //default
        /*if(Input.GetKey("up") && Input.GetKey("right")){
            dir = Vector2.forward + Vector.
        }
        else if(Input.GetKey("up") && Input.GetKey("left")){
            dir = Direction.UP_LEFT;
        }
        else if(Input.GetKey("down") && Input.GetKey("right")){
            dir = Direction.DOWN_RIGHT;
        }
        else if(Input.GetKey("down") && Input.GetKey("left")){
            dir = Direction.DOWN_LEFT;
        }*/
        if(Input.GetKey(KeyCode.D)){
            dir += new Vector2(1,0);
        }
        if(Input.GetKey(KeyCode.A)){
            dir += new Vector2(-1,0);
        }
        if(Input.GetKey(KeyCode.W)){
            dir += new Vector2(0,1);
        }
        if(Input.GetKey(KeyCode.S)){
            dir += new Vector2(0,-1);
        }
        if(!(dir.x == 0 && dir.y == 0)){
            Bullet bullet = Instantiate(bulletPrefab, this.transform.position, Quaternion.AngleAxis (180, dir)).GetComponent<Bullet>();
            bullet.SetDir(dir);
            bullet.manager = manager;
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
