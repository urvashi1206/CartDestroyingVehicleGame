using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private float speed;
    private float turnSpeed = 45.0f;
    private float horizontalInput;
    private float forwardInput;

    [SerializeField] GameObject centerOfMass;
    [SerializeField] TextMeshProUGUI SpeedText;
    [SerializeField] TextMeshProUGUI RPMText;
    [SerializeField] float rpm;
    [SerializeField] GameObject[] allwheels;
    [SerializeField] int wheelsOnGround;

    private Rigidbody rb;
    [SerializeField] private float HorsePower = 0;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        rb.centerOfMass = centerOfMass.transform.localPosition;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (isOnGround())
        {
            horizontalInput = Input.GetAxis("Horizontal");
            forwardInput = Input.GetAxis("Vertical");

            speed = Mathf.RoundToInt(rb.velocity.magnitude * 2.237f);
            SpeedText.text = "Speed: " + speed + " mph";

            rpm = (speed % 30) * 40;
            RPMText.text = "RPM: " + rpm;

            rb.AddRelativeForce(Vector3.forward * forwardInput * HorsePower);
            //transform.Translate(Vector3.forward * Time.deltaTime * speed * forwardInput);
            transform.Rotate(Vector3.up, Time.deltaTime * turnSpeed * horizontalInput);
        }
    }

    bool isOnGround()
    {
        wheelsOnGround = 0;
        foreach (GameObject wheel in allwheels)
        {
            if (wheel.GetComponent<WheelCollider>().isGrounded)
            {
                wheelsOnGround++;
            }
        }
        if (wheelsOnGround == 4)
        {
            return true;
        }
        else
        {
            return false;
        }
    }
}
