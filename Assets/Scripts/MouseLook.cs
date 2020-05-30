using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MouseLook : MonoBehaviour
{
    public float mouseSensitivity = 100f;
    public Transform playerBody;
    float xRotation = 0f;
    bool moveState;
    bool press;
    public Text mode;
        public Button iButton;
    public Button jButton;
    // Start is called before the first frame update
    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
        moveState = true;
        press = true;
    }

    // Update is called once per frame
    void Update()
    {
        if (moveState)
        {
            // Mouse controls camera
            float mouseX = Input.GetAxis("Mouse X") * mouseSensitivity * Time.deltaTime;
            float mouseY = Input.GetAxis("Mouse Y") * mouseSensitivity * Time.deltaTime;
            xRotation -= mouseY;
            xRotation = Mathf.Clamp(xRotation, -90f, 90f);

            transform.localRotation = Quaternion.Euler(xRotation, 0f, 0f);
            playerBody.Rotate(Vector3.up * mouseX);
        }
        // Check for input to activate/deactivate mouse

        // Open inventory using 'i'
        if (Input.GetKeyDown(KeyCode.I))
        {
            moveState = ChangeState(moveState);
            iButton.onClick.Invoke();
        }
        // Open Journal using 'j', if journal is active
        else if (Input.GetKeyDown(KeyCode.J) && jButton.isActiveAndEnabled)
        {
            moveState = ChangeState(moveState);
            jButton.onClick.Invoke();
        }
        
        // Use 'TAB' to swap states
        else if (Input.GetKeyDown(KeyCode.Tab) && press)
        {
            moveState = ChangeState(moveState);
            // holding key does nothing
            press = false;
        }
        // check for key release to allow for state change again
        if (Input.GetKeyUp(KeyCode.Tab))
        {
            press = true;
        }
    }
    bool ChangeState(bool moveState)
    {
        // activate mouse
        if (moveState)
        {
            Cursor.lockState = CursorLockMode.None;
            mode.text = "Mode:\nInventory";
        }
        else // deactivate mouse
        {
            Cursor.lockState = CursorLockMode.Locked;
            mode.text = "Mode:\nLook";
        }
        // toggle for correct result text time
        moveState = !moveState;
        return moveState;
    }
}