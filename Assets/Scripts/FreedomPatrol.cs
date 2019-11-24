using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FreedomPatrol : MonoBehaviour
{
    public float speed;
    private float waitTime;
    public float startWaitTime;

    public Transform moveSpot; // You only need one move spot GameObject on the scene to make the character move anywhere on the screen.
    public float minX;         // You need to specify the size of the map/location where you would want the character to move around.
    public float maxX;         // The bigger the X and Y, the more freedom the character has to move randomly move around.
    public float minY;
    public float maxY;
    void Start()
    {
        waitTime = startWaitTime;

        moveSpot.position = new Vector2(Random.Range(minX, maxX), Random.Range(minY, maxY));
    }

    void Update()
    {
        transform.position = Vector2.MoveTowards(transform.position, moveSpot.position, speed * Time.deltaTime);

        if (Vector2.Distance(transform.position, moveSpot.position) < 0.2f)
        {
            if (waitTime <= 0)
            {
                moveSpot.position = new Vector2(Random.Range(minX, maxX), Random.Range(minY, maxY));
                waitTime = startWaitTime;
            }
            else
            {
                waitTime -= Time.deltaTime;
            }
        }

    }
}
