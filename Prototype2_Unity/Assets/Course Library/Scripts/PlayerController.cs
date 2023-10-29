using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    readonly float speed = 30;
    readonly float rangeLimLeft = -20f;
    readonly float rangeLimRight = 20f;
    readonly float rangeLimFront = 15f;
    readonly float rangeLimBack = 0f;
    readonly float foodDelay = 0.2f;
    float foodTimer = 0f;
    public GameObject projectilePrefab;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        foodTimer -= Time.deltaTime;

        transform.position = new Vector3(Mathf.Clamp(transform.position.x, rangeLimLeft, rangeLimRight), transform.position.y, 
            Mathf.Clamp(transform.position.z, rangeLimBack, rangeLimFront));

        transform.Translate(Vector3.right * Time.deltaTime * Input.GetAxis("Horizontal") * speed);
        transform.Translate(Vector3.forward * Time.deltaTime * Input.GetAxis("Vertical") * speed);

        if (Input.GetKey(KeyCode.Space) && foodTimer <= 0)
        {
            Instantiate(projectilePrefab, transform.position, projectilePrefab.transform.rotation);
            foodTimer = foodDelay;
        }
    }
}
