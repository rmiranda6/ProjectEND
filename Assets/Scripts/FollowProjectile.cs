using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowProjectile : MonoBehaviour
{
    public float speed;
    private float spawnTime;
    public float startBtwSpawnTime;

    private Transform player;

    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;

        spawnTime = startBtwSpawnTime;
    }

    void Update()
    {
        transform.position = Vector2.MoveTowards(transform.position, player.position, speed * Time.deltaTime);

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

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            DestroyProjectile();
            Debug.Log("Big Hit!");
        }
    }

    void DestroyProjectile()
    {
        Destroy(gameObject);
    }
}
