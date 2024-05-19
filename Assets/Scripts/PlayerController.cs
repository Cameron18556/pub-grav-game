using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
    private Vector2 inputMovementVector;
    private Vector3 inputMovementVector3;

    public float movementSpeed;
    public GameObject body;
    public float gravityForce;
    public float bootRayDistance = 2;

    private Rigidbody rb;

    private void Start()
    {
        body = GetComponentInChildren<BodyController>().gameObject;
        rb = GetComponent<Rigidbody>();
    }

    void Update()
    {

        //transform.position += body.transform.forward * inputMovementVector3.z * movementSpeed * Time.deltaTime;
        //transform.position += body.transform.right * inputMovementVector3.x * movementSpeed * Time.deltaTime;

        RaycastHit hit;
        Ray ray = new Ray(transform.position, -transform.up);

        if(Physics.Raycast(ray, out hit, bootRayDistance))
        {
            transform.up = hit.normal;
        }
    }

    private void FixedUpdate()
    {
        if (rb != null)
        {
            //gravity
            rb.AddForce(-transform.up * gravityForce, ForceMode.Force);

            Vector3 movement = Vector3.zero;
            movement += body.transform.forward * inputMovementVector3.z * movementSpeed * Time.fixedDeltaTime;
            movement += body.transform.right * inputMovementVector3.x * movementSpeed * Time.fixedDeltaTime;

            //movement
            rb.AddForce(movement);
        }
    }

    public void Move(InputAction.CallbackContext context)
    {
        inputMovementVector = context.ReadValue<Vector2>();
        inputMovementVector3 = new Vector3(inputMovementVector.x, 0, inputMovementVector.y);
    }
}
