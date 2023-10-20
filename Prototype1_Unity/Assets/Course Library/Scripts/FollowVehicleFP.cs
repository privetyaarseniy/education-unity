using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowVehicleFP : MonoBehaviour
{
    Vector3 offset = new Vector3(0, 1.9f, 1.3f); //Offset of camera. Now not used
    public GameObject vehicle;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void LateUpdate()
    {
        transform.position = vehicle.transform.position + offset;
    }
}
