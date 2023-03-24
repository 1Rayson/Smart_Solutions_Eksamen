using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class SnapPlanetToPosition : MonoBehaviour
{
    public Rigidbody planetRigibody;
    public Transform planetTransform;
    public GameObject planetPosition;
    public GameObject planetToActivate;
    public GameObject ballSpawn;

    private bool inCorrectPlace = false;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(inCorrectPlace)
        {
            planetToActivate.SetActive(true);
        }
        else 
        {
            planetToActivate.SetActive(false);
        }
    }

    void OnTriggerStay(Collider other){
        if(other.tag == "PlanetSocket"){
            planetRigibody.useGravity = false;
            planetRigibody.velocity = new Vector3(0, 0, 0);
            Vector3 orbitTransform = other.transform.position;
            planetTransform.position = orbitTransform;

            if(other.gameObject == planetPosition){
                inCorrectPlace = true;
            }
        }

        if(other.tag == "BallRespawner"){
            Vector3 spawnTransform = ballSpawn.transform.position;
            planetTransform.position = spawnTransform;
            planetRigibody.velocity = new Vector3(0, -1, 0);
        }
    }
    
    void OnTriggerExit(Collider other){
        if(other.tag == "PlanetSocket"){
            inCorrectPlace = false;
        }
    }
}
