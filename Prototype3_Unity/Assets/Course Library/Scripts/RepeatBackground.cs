using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RepeatBackground : MonoBehaviour
{
    float startPosX;
    float repeatWidth;

    // Start is called before the first frame update
    void Start()
    {
        startPosX = transform.position.x;
        repeatWidth = GetComponent<Collider>().bounds.size.x / 2;
    }

    // Update is called once per frame
    void Update()
    {
        if (transform.position.x < startPosX - repeatWidth) transform.position = new Vector3(startPosX, transform.position.y, transform.position.z);
    }
}
