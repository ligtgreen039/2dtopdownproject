using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class s2 : MonoBehaviour
{
    Vector2 targetpos3;

    void Start()
    {
        targetpos3 = GameObject.Find("bulletplace3").transform.position;
    }
    void Update()
    {
        transform.position = Vector2.MoveTowards(transform.position, targetpos3, 20f * Time.deltaTime);
        if (Vector3.Distance(transform.position, targetpos3) < 0.01f)
        {
            Destroy(gameObject);
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == "enemy")
        {
            Destroy(gameObject);
        }
    }
}
