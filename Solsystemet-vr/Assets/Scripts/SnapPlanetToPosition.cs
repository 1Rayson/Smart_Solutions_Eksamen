using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class SnapPlanetToPosition : MonoBehaviour
{
    public Rigidbody planetRigibody;
    public Transform planetTransform;
    public GameObject planetPosition;

    private bool inCorrectPlace = false;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Keyboard.current[Key.M].wasReleasedThisFrame)
        {
            if(inCorrectPlace){
                Debug.Log(transform.parent.name + " is in correct position");
            }
        }
    }

    void OnTriggerStay(Collider other){
        if(other.tag == "PlanetOrbit"){
            planetRigibody.useGravity = false;
            planetRigibody.velocity = new Vector3(0, 0, 0);
            Vector3 orbitTransform = other.transform.position;
            planetTransform.position = orbitTransform;

            if(other.gameObject == planetPosition){
                inCorrectPlace = true;
            }
        }
    }
    
    void OnTriggerExit(Collider other){
        if(other.tag == "PlanetOrbit"){
            inCorrectPlace = false;
        }
    }

    /* 
    void OnTriggerExit(Collider other){
        if(other.tag == "PlanetOrbit"){
            planetRigibody.useGravity = true;
        }
    } */
}
