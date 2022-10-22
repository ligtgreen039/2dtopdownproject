using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class explosion : MonoBehaviour
{
    public float radius;
    enemycontroller enemycontroller;
    public AudioClip explodesound;
    private void Update()
    {
        Invoke("explosions", 0.1f);
    }
    void destroyfonc()
    {
        Destroy(gameObject);
    }
    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.black;
        Gizmos.DrawSphere(transform.position, radius);
    }
    void explosions()
    {
        Collider2D[] enemyhit = Physics2D.OverlapCircleAll(transform.position, radius);
        foreach (Collider2D col in enemyhit)
            NewMethod(col);
    }

    private void NewMethod(Collider2D col)
    {
        enemycontroller = col.GetComponent<enemycontroller>();
        enemycontroller.health = 0;
    }

    void soundstarter()
    {
        GameObject.Find("soundcontroller").GetComponent<AudioSource>().PlayOneShot(explodesound);
    }
}