using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
    private Vector2 inputMovementVector;
    private Vector3 inputMovementVector3;
    private Rigidbody rb;
    public float movementSpeed;
    public float lookSensitivity;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        
        transform.position += transform.forward * inputMovementVector3.z * movementSpeed * Time.deltaTime;
        transform.position += transform.right * inputMovementVector3.x * movementSpeed * Time.deltaTime;
    }

    public void Move(InputAction.CallbackContext context)
    {
        inputMovementVector = context.ReadValue<Vector2>();
        inputMovementVector3 = new Vector3(inputMovementVector.x, 0, inputMovementVector.y);
    }

    public void Look(InputAction.CallbackContext context)
    {
        Vector2 input = context.ReadValue<Vector2>();
        
        input *= Time.deltaTime;
        input *= lookSensitivity;
        if(input.y < -90)
        {
            input.y = -90;
        }
        if (input.y > 90)
        {
            input.y = 90;
        }

        transform.localEulerAngles += new Vector3(input.y, -input.x, 0);
    }
}
