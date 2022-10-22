using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class s1 : MonoBehaviour
{
    Vector2 targetpos2;
    void Start()
    {
        targetpos2 = GameObject.Find("bulletplace2").transform.position;
    }
    void Update()
    {
        transform.position = Vector2.MoveTowards(transform.position, targetpos2, 20f * Time.deltaTime);
        if (Vector3.Distance(transform.position, targetpos2) < 0.01f)
        {
            Destroy(gameObject);
        }
    }

}
