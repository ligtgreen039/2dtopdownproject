using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemycontroller : MonoBehaviour
{
    GameObject player;
    Rigidbody2D crb;
    public Animator enemyanimator;
    bool isdead;
    public static float para = 0;
    public float health = 2;
    public float speed = 3;
    public int amount = 5;
    public static int olendusmansayisi = 0;
    float degreamount = 15f;
    public float shotgundamage = 1;
    public void Start()
    {
        crb = gameObject.GetComponent<Rigidbody2D>();
        player = GameObject.FindGameObjectWithTag("Player");
    }
    void Update()
    {
        enemymove();
        healthcheck();

    }
    
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("bullet"))
        {
            health -= 1;
            
        }
        if (collision.CompareTag("riflebullet"))
        {
            health -= 2;
        }
        if (collision.CompareTag("explosionarea"))
        {
            health -= 2;
        }
        if (collision.CompareTag("shotgunbullet"))
        {
            health -= shotgundamage;

        }

    }
    void enemymove()
    {
        if(gameObject.GetComponent<SpriteRenderer>().sprite.name == "zombie_0")
        {
            degreamount = 90f;
        }
        if (Vector3.Distance(transform.position, player.transform.position) > 0.735f && isdead == false)
        {
            transform.position = Vector3.MoveTowards(transform.position, player.transform.position, speed * Time.deltaTime);
        }
        Vector2 dir = player.transform.position - transform.position;
        float angle = (Mathf.Atan2(dir.x, dir.y) * Mathf.Rad2Deg) - degreamount;
        crb.rotation = -angle;
    }
    void destroyed()
    {
        Destroy(gameObject);
        para += amount;
        olendusmansayisi += 1;
    }
    public void healthcheck()
    {
        if(health <= 0)
        {
            gameObject.GetComponent<BoxCollider2D>().enabled = false;
            enemyanimator.SetBool("isdead", true);
            isdead = true;
        }
    }
}
