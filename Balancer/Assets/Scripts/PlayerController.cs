using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public Rigidbody playerRB;
    public float Speed = 2.0f;
    private GameObject focalPoint;
    public bool haspower = false;
    private float powerUPstrength = 15.0f;
    public GameObject PowerupIndicator;
    // Start is called before the first frame update
    void Start()
    {
        playerRB = GetComponent<Rigidbody>();
        focalPoint = GameObject.Find("Focal Point");
    }

    // Update is called once per frame
    void Update()
    {
        float forwardInput = Input.GetAxis("Vertical");
        playerRB.AddForce(focalPoint.transform.forward*Speed * forwardInput);
         PowerupIndicator.transform.position = transform.position + new Vector3(0, -0.5f, 0); 
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Powerup"))
        {
            haspower = true;
               Destroy(other.gameObject);
            StartCoroutine(powerupCountdownRoutine());
             PowerupIndicator.gameObject.SetActive(true); 

        }
    }
    IEnumerator powerupCountdownRoutine()
    {
        yield return new WaitForSeconds(7);
        haspower = false;
         PowerupIndicator.gameObject.SetActive(false); 
    }



    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.CompareTag("Enemy") && haspower)
        {
            Rigidbody enemyRigidbody = collision.gameObject.GetComponent<Rigidbody>();
            Vector3 awayFromPlayer = collision.gameObject.transform.position - transform.position;

            enemyRigidbody.AddForce(awayFromPlayer * powerUPstrength, ForceMode.Impulse);
            Debug.Log("collided with: " + collision.gameObject.name + "with power set to" + haspower);
        }
    }
}
