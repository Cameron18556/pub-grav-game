using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class BodyController : MonoBehaviour
{
    
    public float lookSensitivity;

    public void Look(InputAction.CallbackContext context)
    {
        Vector2 input = context.ReadValue<Vector2>();

        input *= Time.deltaTime;
        input *= lookSensitivity;
        if (input.y < -80)
        {
            input.y = -80;
        }
        if (input.y > 80)
        {
            input.y = 80;
        }

        transform.localEulerAngles += new Vector3(input.y, -input.x, 0);
    }
}
