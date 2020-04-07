using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class lookAtplayer : MonoBehaviour
{
    public Transform T_player;
    public Vector3 offset;

    // Update is called once per frame
    void Update()
    {
        transform.position = offset + T_player.position;
    }
}
