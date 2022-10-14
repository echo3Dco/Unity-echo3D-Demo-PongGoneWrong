using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Script controls the ball projectile
public class ProjectileController : MonoBehaviour
{
    [SerializeField] float initialVelocity;
    [SerializeField] Vector3 ballAngle;
    [SerializeField] Transform spawnPoint;
    private Rigidbody ballPhysics;
    private Vector3 startingPosition;

    private void Start()
    {
        startingPosition = transform.position;
        ballPhysics = gameObject.GetComponent<Rigidbody>();
    }

    private void Update()
    {
        if(Input.GetKeyDown(KeyCode.Space))
        {   // Turns this section of physics off so you can launch the ball without it falling
            ballPhysics.isKinematic = false;
            //Launches ball and keeps speed continuously fast
            ballPhysics.AddForce(initialVelocity * ballAngle, ForceMode.Impulse);
            Invoke("ResetBall", 2);
        }
    }

    private void ResetBall()
    {
        transform.position = startingPosition;
        ballPhysics.isKinematic = true;
        print("resetting ball");
    }
}
