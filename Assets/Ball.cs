using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Ball : MonoBehaviour
{
    // Ball
    public float ballStrength = 15.0f;

    // Crates to be destroyed
    public GameObject[] crates;
    public int cratesCount;

    // Sound
    public AudioSource audioSource;
    public AudioClip destroySFX;

    // Particle
    public ParticleSystem destroyParticle;
    public ParticleSystem dustParticle;

    // UI
    public Text scoreText;
    private int score = 0;

    // Start is called before the first frame update
    void Start()
    {
        //crates[] = FindObjectsOfType<Crate>();
        score = 0;
    }

    // Update is called once per frame
    void Update()
    {
        cratesCount = crates.Length;
    }

    private void OnCollisionEnter(Collision col)
    {
        /*
        Destroy(crate.gameObject);
        audioSource.PlayOneShot(destroySFX);
        destroyParticle.Play();
        //other.gameObject = crates[];
        //crates.Length = - 1;
        */

        if (crates != null)
        {
            if (col.gameObject.CompareTag("Crate"))
            {
                Rigidbody crateRigidbody = col.gameObject.GetComponent<Rigidbody>();
                Vector3 away = - col.contacts[0].normal;
                crateRigidbody.AddForce(away * ballStrength, ForceMode.Impulse);
                Instantiate(destroyParticle, col.transform.position, destroyParticle.transform.rotation);
                audioSource.PlayOneShot(destroySFX);
                Destroy(col.gameObject);
                score += 1;
                scoreText.text = "Score: " + score;
            }

            else if (col.gameObject.CompareTag("Paddle"))
            {
                Rigidbody paddleRigidbody = col.gameObject.GetComponent<Rigidbody>();
                Vector3 away = - col.contacts[0].normal;
                paddleRigidbody.AddForce(away * ballStrength, ForceMode.Impulse);
                Instantiate(dustParticle, col.transform.position, dustParticle.transform.rotation);
            }
            else
            {
                dustParticle.Stop();
            }
        }
    }
}
