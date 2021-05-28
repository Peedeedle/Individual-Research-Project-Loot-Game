///\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\
///     File:            CameraFollow.cs
///     Author:          Jack Peedle
///     Date Created:    10/10/2020
///     Brief:
///\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    // Player transform
    public Transform player;
    
    // Update 
    void Update()
    {
        // Follow the players position continuously
        transform.position = new Vector3 (player.transform.position.x, player.transform.position.y, transform.position.z);
    }
}
