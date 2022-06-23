using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class boss : MonoBehaviour
{
    [SerializeField] Transform playerPosition;
    public bool isFlipped = false;

    [SerializeField] GameObject projectil;
    [SerializeField] GameObject player;

    private int attackAngle;

    private Vector3 vectorBossPlayer;
    private Vector3 vectorBPNormalized;

    [SerializeField] float vectorMultiplier;

    // Start is called before the first frame update
    void Start()
    {
        playerPosition = GameObject.FindGameObjectWithTag("Player").transform;
        vectorMultiplier = 0.3f;
    }

    // Update is called once per frame
    void Update()
    {
        vectorBossPlayer = (playerPosition.position - transform.position);
        vectorBPNormalized = vectorBossPlayer.normalized;

        projectil.GetComponent<boss_projectile>().target = vectorBossPlayer;
    }

    public void LookAtPlayer()
    {
        Vector3 flipped = transform.localScale;
        flipped.z *= -1.0f;

        if(transform.position.x > playerPosition.position.x && !isFlipped)
        {
            isFlipped = true;
            transform.localScale = flipped;
            transform.Rotate(0f, 180f, 0f);
            
        }
        else if (transform.position.x < playerPosition.position.x && isFlipped)
        {
            isFlipped = false;
            transform.localScale = flipped;
            transform.Rotate(0f, 180f, 0f);
            
        }
    }

    public void Attack1()
    {
        player.GetComponent<PlayerLife>().TakeDamagePlayer(2);
    }

    public void Attack2()
    {
        attackAngle = 120;
        Vector3 newDirection;

        for (int i = -(attackAngle / 2); i <= (attackAngle / 2); i += attackAngle / 4)
        {
            newDirection = vectorBossPlayer + new Vector3(Mathf.Cos(i), Mathf.Sin(i), 0);

            projectil.GetComponent<boss_projectile>().target = newDirection.normalized;

            Instantiate(projectil, transform.position + vectorBPNormalized * vectorMultiplier, Quaternion.identity);
        }
    }

    public void Attack3()
    {
        attackAngle = 360;
        Vector3 newDirection;

        for (int i = -180; i <= 180; i += 40)
        {
            newDirection = new Vector3(Mathf.Cos(i), Mathf.Sin(i), 0);

            projectil.GetComponent<boss_projectile>().target = newDirection.normalized;

            Instantiate(projectil, transform.position, Quaternion.identity);
        }
    }

    public GameObject GetPlayer()
    {
        return player;
    }

    public Vector3 GetBossTransformPosition()
    {
        return transform.position;
    }


}
