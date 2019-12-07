using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowProjectile : MonoBehaviour
{
    public float speed;
    private float spawnTime;
    public float startBtwSpawnTime;

    private Transform player;
    private Health health;
    private Rigidbody2D rb2d;

    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;

        health = GameObject.Find("YellowPlayer").GetComponent<Health>();

        rb2d = GetComponent<Rigidbody2D>();

        spawnTime = startBtwSpawnTime;
    }

    void Update()
    {
        // transform.position = Vector2.MoveTowards(transform.position, player.position, speed * Time.deltaTime);

        if(spawnTime <= 0)
        {
            DestroyProjectile();
            spawnTime = startBtwSpawnTime;
            Debug.Log("Miss Shot Self Destructed");
        }
        else
        {
            spawnTime -= Time.deltaTime;
        }
    }

    void FixedUpdate()
    {
        Vector2 direction = player.position - transform.position;
        Vector2 velocity = direction.normalized * speed;
        Debug.DrawRay(transform.position, velocity, Color.red, .25f);
        // Take velocity and put into the rigidbody velocity
        // transform.position = (rb2d.velocity.x * velocity) + (rb2d.velocity.y * velocity);
        rb2d.velocity = new Vector2(velocity.x, velocity.y);
        Debug.Log(velocity);
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            DestroyProjectile();
            Debug.Log("Big Hit!");
            health.TakeDamage();
        }
        if (other.CompareTag("Wall"))
        {
            DestroyProjectile();
        }
        if(other.CompareTag("Enemy"))
        {
            DestroyProjectile();
        }
    }

    void DestroyProjectile()
    {
        Destroy(gameObject);
    }
}
