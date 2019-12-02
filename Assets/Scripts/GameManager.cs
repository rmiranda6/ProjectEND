using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    private Health playerHealth;
    public Player player;
    void Start()
    {
        playerHealth = GameObject.Find("YellowPlayer").GetComponent<Health>();
        player = GameObject.Find("YellowPlayer").GetComponent<Player>();
    }

    void Update()
    {
        if(playerHealth.health <= 0)
        {
            player.enabled = false;
            Debug.Log("Dead");
        }
    }
}
