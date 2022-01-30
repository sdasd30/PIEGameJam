using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowPlayer : MonoBehaviour
{
    public Transform playert;
    // Start is called before the first frame update
    void Start()
    {
        playert = FindObjectOfType<PlayerController>().gameObject.transform;
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = new Vector3(playert.position.x, playert.position.y, -10f);
    }
}
