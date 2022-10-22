using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bulletcontroller : MonoBehaviour
{
    public Animator enemyanimator;
    private void OnTriggerEnter2D(Collider2D collision)
    {
            Destroy(gameObject);
    }
}
