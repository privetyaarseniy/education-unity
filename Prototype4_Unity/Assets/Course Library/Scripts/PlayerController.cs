using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    Rigidbody playerRb;

    GameObject focalPoint;

    GameObject powerupIndicator;
    public float indicatorRotSpeed;
    public bool hasPowerup = false;
    public float powerupStrength;

    public float speed;
    // Start is called before the first frame update
    void Start()
    {
        playerRb = GetComponent<Rigidbody>();
        focalPoint = GameObject.Find("FocalPoint");
        powerupIndicator = GameObject.Find("PowerupIndicator");
        powerupIndicator.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        playerRb.AddForce(focalPoint.transform.forward * speed * Input.GetAxis("Vertical"));

        powerupIndicator.transform.position = transform.position;
        powerupIndicator.transform.Rotate(Vector3.up, indicatorRotSpeed * Time.deltaTime);
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Powerup"))
        {
            hasPowerup = true;
            powerupIndicator.SetActive(true);
            StartCoroutine(PowerupCountdown());
            Destroy(other.gameObject);
        }

    }

    private void OnCollisionEnter(Collision collision)
    {
        if (hasPowerup && collision.gameObject.CompareTag("Enemy"))
        {
            Debug.Log($"Collided with {collision.gameObject.name} with power up set to {hasPowerup}");
            collision.gameObject.GetComponent<Rigidbody>().AddForce((collision.gameObject.transform.position - transform.position) * powerupStrength, ForceMode.Impulse);
        }
    }

    IEnumerator PowerupCountdown()
    {
        yield return new WaitForSeconds(5);

        powerupIndicator.SetActive(false);
        hasPowerup = false;
    }
}
