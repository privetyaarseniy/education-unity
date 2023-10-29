using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyOutOfBounds : MonoBehaviour
{
    readonly float topBound = 30f;
    readonly float bottomBound = -10f;
    readonly float sideBound = 40f;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (transform.position.z > topBound || transform.position.x < -sideBound || transform.position.x > sideBound)
        {
            Destroy(gameObject);
        }
        if (transform.position.z < bottomBound)
        {
            Destroy(gameObject);
            UI.LivesDown();

        }
    }
}
