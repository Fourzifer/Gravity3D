using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    public Transform FollowPlayer;

    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        Vector3 pos = new Vector3(Mathf.Clamp(FollowPlayer.position.x, 0f, 1000f), transform.position.y, transform.position.z);
        transform.position = pos;
    }
}