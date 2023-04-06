using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.XR.Interaction.Toolkit.Transformers;

public class SnapPlanetToPosition : MonoBehaviour
{
    public Rigidbody planetRigibody;
    public Transform planetTransform;
    public GameObject planetPosition;
    public GameObject planetToActivate;
    public GameObject ballSpawn;
    public GameManager gameManager;
    
    private bool haveBeenRight = false;

    // Start is called before the first frame update
    void Start()
    {
        planetToActivate.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {

    }

    void OnTriggerStay(Collider other)
    {
        if (other.tag == "PlanetSocket")
        {
            planetRigibody.useGravity = false;
            planetRigibody.velocity = new Vector3(0, 0, 0);
            Vector3 orbitTransform = other.transform.position;
            planetTransform.position = orbitTransform;
        }
    }

    void OnTriggerEnter(Collider other){
        if(other.tag == "PlanetSocket"){
            if(other.gameObject == planetPosition){
                if(!haveBeenRight){
                    gameManager.AddCorrect();
                    haveBeenRight = true;
                }
                planetToActivate.SetActive(true);    
            } else
            {
                gameManager.wrong();
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
            planetToActivate.SetActive(false);
        }
    }
}
