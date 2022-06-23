using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    // Movement Input
    public float horizontalInput;
    public float speed = 50.0f;
    //[SerializeField] Rigidbody playerRb;

    public float minRange = -13.0f;
    public float maxRange = 13.0f;

    // Ball Collision
    public GameObject ball;

    // Sound
    public AudioClip ballCollision;
    public AudioSource audioSource;

    // Particles
    public ParticleSystem collisionParticleSystem;

    // Start is called before the first frame update
    void Start()
    {
        //playerRb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        // Check for left and right bounds, limits the movement on the z axis
        if (transform.position.z < minRange)
        {
            transform.position = new Vector3(transform.position.x, transform.position.y, minRange);
        }

        if (transform.position.z > maxRange)
        {
            transform.position = new Vector3(transform.position.x, transform.position.y, maxRange);
        }

        horizontalInput = Input.GetAxis("Horizontal");

        transform.Translate(Vector3.forward * horizontalInput * speed * Time.deltaTime);
    }

    private void OnCollisionEnter(Collision other)
    {
        //other.gameObject.GetComponent<Rigidbody>().AddForce(Vector3.up, ForceMode.Impulse);
        ball.GetComponent<Rigidbody>().AddForce(Vector3.up, ForceMode.Impulse);
        audioSource.PlayOneShot(ballCollision);
        collisionParticleSystem.Play();
    }
}
