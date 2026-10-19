using System;
using UnityEngine;
using UnityEngine.InputSystem;

public class InputTest : MonoBehaviour
{
    public InputActionProperty actionValue;
    public InputActionProperty actionButton;

    private void Update()
    {
        float value = actionValue.action.ReadValue<float>();
        Debug.Log("Value : " + value);
        
        bool button = actionButton.action.IsPressed();
        Debug.Log("Button : " + button);
    }
}
