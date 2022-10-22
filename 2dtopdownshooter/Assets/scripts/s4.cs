using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class s4 : MonoBehaviour
{
    Vector2 targetpos5;
    void Start()
    {
        targetpos5 = GameObject.Find("bulletplace5").transform.position;
    }
    void Update()
    {
        transform.position = Vector2.MoveTowards(transform.position, targetpos5, 20f * Time.deltaTime);
        if (Vector3.Distance(transform.position, targetpos5) < 0.01f)
        {
            Destroy(gameObject);
        }
    }
}
