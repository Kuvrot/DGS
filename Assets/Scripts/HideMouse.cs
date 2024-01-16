using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class HideMouse : MonoBehaviour
{

    public InputAction mousedown , escape;
    public bool cursorVisible = false;

    private void OnEnable()
    {
        escape.Enable();
        mousedown.Enable();
    }

    private void OnDisable()
    {
        escape.Disable();
        mousedown.Disable();
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (escape.triggered && !cursorVisible)
        {
            Cursor.visible = true;
            Cursor.lockState = CursorLockMode.None;
            cursorVisible = true;
        }

        if (mousedown.triggered && cursorVisible)
        {
            Cursor.visible = true;
            Cursor.lockState = CursorLockMode.Locked;
            cursorVisible = false;
        }
    }
}
