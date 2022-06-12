using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public float speed;
    public float stoppingDistance;
    public float retreatDistance;

    public Transform player;

    private float TimeBtwShots;
    public float StartTimeBtwShots;

    public GameObject projectil;


    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;

        TimeBtwShots = StartTimeBtwShots;
    }

    void Update()
    {

        if (Vector2.Distance(transform.position, player.position)> stoppingDistance)
        {
            transform.position = Vector2.MoveTowards(transform.position,player.position,speed*Time.deltaTime);

        }
        else if (Vector2.Distance(transform.position, player.position) < stoppingDistance && Vector2.Distance(transform.position, player.position) > retreatDistance)
        {
            transform.position = this.transform.position;
        }
        else if (Vector2.Distance(transform.position, player.position) < retreatDistance)
        {
            transform.position = Vector2.MoveTowards(transform.position, player.position, -speed * Time.deltaTime);

        }

        if (TimeBtwShots <= 0)
        {
            Instantiate(projectil, transform.position, Quaternion.identity);
            TimeBtwShots = StartTimeBtwShots;
        }
        else
        {
                TimeBtwShots -= Time.deltaTime;
        }
    }
}
