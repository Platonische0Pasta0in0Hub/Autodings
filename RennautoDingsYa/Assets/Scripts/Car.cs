using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Car : MonoBehaviour
{
    public float acceleration;
    public float rotationspeed;
    public float maxspeed;
    Rigidbody rigid;
    // Start is called before the first frame update
    void Start()
    {
        rigid = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        AddSpeed();
        AddRotation();
        AdjustVelocity();

        
    }

    void AddSpeed()
    {
        if (rigid.velocity.magnitude < maxspeed)
        {
            float InputForward = Input.GetAxis("Vertical");
            rigid.AddForce(transform.forward * acceleration * InputForward);
        }
        
    }

    void AddRotation()
    {
        float rotation = Input.GetAxis("Horizontal");
        transform.Rotate(new Vector3(0, rotation*rotationspeed, 0));
    }

    void AdjustVelocity()
    {
        Vector3 velocity = rigid.velocity;

        float direction = Vector3.Dot(transform.forward, velocity.normalized);

        if (direction > 0)
        {
            velocity = transform.forward * velocity.magnitude;
        }

        if (direction < 0)
        {
            velocity = -transform.forward * velocity.magnitude;
        }

        rigid.velocity = velocity;
    }

}
