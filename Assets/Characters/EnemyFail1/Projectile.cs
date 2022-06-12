using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    public float speed;
    public Transform player;
    public Vector2 target;
    public LayerMask whatIsSolid;
    public int damage;
    public float distance;



    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;

        target = new Vector2(player.position.x, player.position.y);


    }

    void Update()
    {
     
        transform.position = Vector2.MoveTowards(transform.position, target, speed * Time.deltaTime);

       
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

        if (transform.position.x == target.x && transform.position.y == target.y)
        {
            DestroyProjectile();
        }
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            DestroyProjectile();
        }
    }
    void DestroyProjectile()
    {

        Destroy(gameObject);

    }

   

}
