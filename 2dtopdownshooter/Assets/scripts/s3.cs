using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class s3 : MonoBehaviour
{
    Vector2 targetpos4;
    void Start()
    {
        targetpos4 = GameObject.Find("bulletplace4").transform.position;
    }
    void Update()
    {
        transform.position = Vector2.MoveTowards(transform.position, targetpos4, 20f * Time.deltaTime);
        if (Vector3.Distance(transform.position, targetpos4) < 0.01f)
        {
            Destroy(gameObject);
        }
    }
}
