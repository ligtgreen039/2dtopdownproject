using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class shotguncontrol : MonoBehaviour
{
    Vector2 targetpos1;
    void Start()
    {
        targetpos1 = GameObject.Find("bulletplace1").transform.position;
    }
    void Update()
    {
        transform.position = Vector2.MoveTowards(transform.position, targetpos1, 20f * Time.deltaTime);
        if (Vector3.Distance(transform.position, targetpos1) < 0.01f)
        {
            Destroy(gameObject);
        }
    }
}
