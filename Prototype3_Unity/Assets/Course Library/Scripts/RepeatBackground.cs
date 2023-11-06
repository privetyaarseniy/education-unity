using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RepeatBackground : MonoBehaviour
{
    private float startPosX;
    public float repeatPosX = -10;

    // Start is called before the first frame update
    void Start()
    {
        startPosX = transform.position.x;
    }

    // Update is called once per frame
    void Update()
    {
        if (transform.position.x < repeatPosX) transform.position = new Vector3(startPosX, transform.position.y, transform.position.z);
    }
}
