using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball : MonoBehaviour
{
    //config parameters
    [SerializeField] Paddle paddle1;
    [SerializeField] float xVelocity = 2f;
    [SerializeField] float yVelocity = 15f;
    [SerializeField] AudioClip[] sounds;

    //states
    Vector2 paddleToBallVector;
    private bool hasStarted;

    //Cached components
    AudioSource audioSource;

    // Start is called before the first frame update
    void Start()
    {
        paddleToBallVector = transform.position - paddle1.transform.position;
        hasStarted = false;
        audioSource = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        if (!hasStarted)
        {
            LockToPaddle();
            LaunchOnClick();
        }
    }

    private void LockToPaddle()
    {
        Vector2 paddlePos = new Vector2(paddle1.transform.position.x, paddle1.transform.position.y);
        transform.position = paddlePos + paddleToBallVector;
    }

    private void LaunchOnClick()
    {
        if (Input.GetMouseButtonDown(0))
        {
            GetComponent<Rigidbody2D>().velocity = new Vector2(xVelocity, yVelocity);
            hasStarted = true;
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (hasStarted)
        {
            AudioClip tempClip = sounds[Random.Range(0, sounds.Length)];
            audioSource.PlayOneShot(tempClip);
        }
    }
}
