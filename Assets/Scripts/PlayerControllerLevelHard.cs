using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControllerLevelHard : MonoBehaviour
{
    public Camera MainCamera;
    public Camera HoodCamera;
    public KeyCode switchKey;
    private float speed = 20.0f;
    private float turnSpeed = 45.0f;
    private float horizontalInput;
    private float forwardInput;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        horizontalInput = Input.GetAxis("Horizontal");
        forwardInput = Input.GetAxis("Vertical");

        transform.Translate(Vector3.forward * Time.deltaTime * speed * forwardInput);
        transform.Rotate(Vector3.up, Time.deltaTime * turnSpeed * horizontalInput);

        if(Input.GetKeyDown(switchKey))
        {
            MainCamera.enabled = !MainCamera.enabled;
            HoodCamera.enabled = !HoodCamera.enabled;
        }
    }
}
