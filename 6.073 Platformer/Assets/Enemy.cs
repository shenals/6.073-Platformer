using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    private const float speed=2;
    [SerializeField] public Platformer target;  // Target player to attack.

    private Rigidbody2D rb;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        Vector2 target_dir = (Vector2) target.transform.position - (Vector2) transform.position;
        target_dir = target_dir / target_dir.magnitude;
        rb.velocity = target_dir * speed;
    }

    private void OnTriggerStay2D(Collider2D other)
    {
        if (other.gameObject != target.gameObject) return;
        target.hp = target.hp - 1;
       // Debug.Log(target.hp);
    }
}
