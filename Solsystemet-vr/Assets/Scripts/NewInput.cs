using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class NewInput : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Keyboard.current[Key.Space].wasPressedThisFrame)
        {
            print("Spaced clicked New");
        }
        //Mouse.current.IsPressed();
    }
}
