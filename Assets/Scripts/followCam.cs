using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class followCam : MonoBehaviour
{
    public GameObject followTarget;
    public bool isFollowing;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    void LateUpdate()
    {
        if (isFollowing)
        {
            if (followTarget == null)
            {
                isFollowing = false;
            }
            else
            {
                Vector3 targetPos = followTarget.transform.position;
                transform.position = new Vector3(targetPos.x, targetPos.y, transform.position.z);

            }
        }
    }
}

