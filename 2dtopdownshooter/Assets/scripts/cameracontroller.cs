using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cameracontroller : MonoBehaviour
{
    public Transform player;
    void Update()
    {
        transform.position = new Vector3(Mathf.Clamp(player.position.x,-8.2f,8.2f),Mathf.Clamp(player.position.y, -4.5f, 12), transform.position.z);
    }
}
