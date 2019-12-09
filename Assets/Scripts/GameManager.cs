using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{

    private Health playerHealth;
    public Vector2 playerPosition;
    public Player player;
    private bool respawn = true;

    public GameObject deadScreen;
    void Start()
    {
        playerHealth = GameObject.Find("YellowPlayer").GetComponent<Health>();

        player = GameObject.Find("YellowPlayer").GetComponent<Player>();

    }

    void Update()
    {
        //if (respawn == true)
        //{
        //    GameObject player = Instantiate(playerPrefab, playerPosition, Quaternion.identity);
        //    Rigidbody2D rb2D = player.GetComponent<Rigidbody2D>();


        //    respawn = false;
        //}

        if (playerHealth.health <= 0)
        {
            player.enabled = false;
            Debug.Log("Dead");
            Respawn();
            deadScreen.SetActive(true);
        }
    }

    void Respawn()
    {
        respawn = true;
    }
}
