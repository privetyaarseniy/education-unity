using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraTweaks : MonoBehaviour
{
    public Camera FPCamera;
    public Camera TPCamera;
    // Start is called before the first frame update
    void Start()
    {
        FPCamera.enabled = false;
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.V))
        {
                FPCamera.enabled = !FPCamera.enabled;
                TPCamera.enabled = !TPCamera.enabled;
        }
    }
}
