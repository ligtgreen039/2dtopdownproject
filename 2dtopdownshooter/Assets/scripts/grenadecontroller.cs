using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class grenadecontroller : MonoBehaviour
{
    float speed;
    Vector2 targetpos;
    public GameObject explosion;
    void Start()
    {
        speed =55f;
        targetpos = GameObject.Find("menzil").transform.position;
    }
    void Update()
    {
        if (speed <= 0f)
        {
            Instantiate(explosion, transform.position, Quaternion.identity);
            Destroy(gameObject);
        }
        if (speed >= 0)
        {
            speed -= Time.deltaTime * 150f;

            transform.position = Vector2.MoveTowards(transform.position, targetpos, speed * Time.deltaTime);
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        Instantiate(explosion, transform.position, Quaternion.identity);
        Destroy(gameObject);
    }
    void destroyer()
    {

    }
}
