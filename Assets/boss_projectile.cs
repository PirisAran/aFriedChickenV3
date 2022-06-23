using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class boss_projectile : MonoBehaviour
{
    [SerializeField] GameObject player;
    
    public float speed;
    public Vector3 target;
    public LayerMask whatIsSolid;
    public int damage;
    public float distance = 0.1f;
    public float distanceToPlayer = 0.1f;

    Vector3 vectorBulletPlayer;

    [SerializeField] GameObject destroyEffect;

    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");

        //target = new Vector2(player.position.x, player.position.y);


    }

    void Update()
    {
        transform.position += target * speed * Time.deltaTime;

        vectorBulletPlayer = player.GetComponent<Transform>().position - transform.position;

        RaycastHit2D hitInfo = Physics2D.Raycast(transform.position, transform.up, distance, whatIsSolid);

        if (hitInfo.collider != null)
        {
            if (hitInfo.collider.CompareTag("Player"))
            {
                Debug.Log("PLAYER MUST TAKE DAMAGE!");
                hitInfo.collider.GetComponent<PlayerLife>().TakeDamagePlayer(damage);
            }
            DestroyProjectile();
        }

        if (vectorBulletPlayer.magnitude <= distanceToPlayer)
        {
            player.GetComponent<PlayerLife>().TakeDamagePlayer(damage);
            DestroyProjectile();
        }
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            player.GetComponent<PlayerLife>().TakeDamagePlayer(damage);
            DestroyProjectile();
        }
    }
    void DestroyProjectile()
    {
        Instantiate(destroyEffect, transform.position, Quaternion.identity);
        Destroy(gameObject);
    }
}
