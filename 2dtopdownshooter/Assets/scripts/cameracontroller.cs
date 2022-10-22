using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cameracontroller : MonoBehaviour
{
    public Transform player;
    void Update()
    {
        transform.position = new Vector3(Mathf.Clamp(player.position.x,-7,7),Mathf.Clamp(player.position.y, -4, 12), transform.position.z);
    }
}
