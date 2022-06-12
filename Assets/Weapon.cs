using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon : MonoBehaviour
{
    public GameObject projectileChicken;
    public Transform ShotPoint;

    private float TimeBtwShots;
    public float StartTimeBtwShots;

    private SoundManager soundManager;

    private void Awake()
    {
        soundManager = FindObjectOfType<SoundManager>();
    }
    void Start()
    {
        
    }

    void Update()
    {
        if (TimeBtwShots<=0)
        {
            if (Input.GetMouseButtonDown(0))
            {
                Instantiate(projectileChicken, ShotPoint.position, ShotPoint.rotation);

                soundManager.SetAudio(4, 0.5f);

                TimeBtwShots = StartTimeBtwShots;
            }
        }
        else
        {
            TimeBtwShots -= Time.deltaTime;
        }
    }
}
