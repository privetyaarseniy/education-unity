using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DetectColission : MonoBehaviour
{

    // Start is called before the first frame update
    void Start()
    {
           
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.name == "SimpleFarmer_Man_01_Black")
        {
            Destroy(gameObject);
            UI.LivesDown();
            return;
        }

       if (other.transform.parent != null && other.transform.parent.gameObject.CompareTag("Animals")) return;

       Destroy(other.gameObject);
        GetComponent<HealthBar>().Feed();
    }
}
