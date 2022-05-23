using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon : MonoBehaviour
{
    public GameObject projectileChicken;
    public Transform ShotPoint;

    private float TimeBtwShots;
    public float StartTimeBtwShots;


    void Start()
    {
        
    }

    void Update()
    {
        if (TimeBtwShots<=0)
        {
            if (Input.GetMouseButtonDown(0))
            {
                Instantiate(projectileChicken, ShotPoint.position, transform.rotation);
                TimeBtwShots = StartTimeBtwShots;
            }
            else
            {
                TimeBtwShots -= Time.deltaTime; 
            }
        }
        if (Input.GetMouseButtonDown(0))
        {
            Instantiate(projectileChicken, ShotPoint.position, transform.rotation); 
        }
    }
}
