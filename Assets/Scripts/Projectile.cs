using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    public float speed;

    private Transform player;
    private Health health;
    private Vector2 target;

    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;

        health = GameObject.Find("YellowPlayer").GetComponent<Health>();

        target = new Vector2(player.position.x, player.position.y);
    }

    void Update()
    {
        transform.position = Vector2.MoveTowards(transform.position, target, speed * Time.deltaTime);

        if(transform.position.x == target.x && transform.position.y == target.y)
        {
            DestroyProjectile();
            Debug.Log("Miss!");
        }
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            DestroyProjectile();
            Debug.Log("HIT!");
            health.TakeDamage();
            //FindObjectOfType<AudioManager>().Play("SoundName"); <- This is what I will type to play the sound that I want.
        }
        if (other.CompareTag("Wall"))
        {
            Debug.Log("Hit WALL");
            DestroyProjectile();
        }
        if (other.CompareTag("Enemy"))
        {
            DestroyProjectile();
        }
    }

    void DestroyProjectile()
    {
        Destroy(gameObject);
    }
}
