using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlanetDistance : MonoBehaviour
{
    public GameManager gameManager;
    public float startYRotation = 73f;
    public float tolerance = 1f;

    private bool rightPlace = false;
    Vector3 correctDistance;
    Vector3 startPosition;
    Vector3 startRotation;
    Vector3 newRotation;
    // Start is called before the first frame update
    void Start()
    {
        correctDistance = transform.localEulerAngles;
        transform.localEulerAngles = new Vector3(0, startYRotation, 0);

        startPosition = transform.position;
        startRotation = transform.eulerAngles;
    }

    // Update is called once per frame
    void Update()
    {       
        if(
            transform.localEulerAngles.y > correctDistance.y - tolerance && 
            transform.localEulerAngles.y < correctDistance.y + tolerance
        )
        {
            transform.localEulerAngles = correctDistance;
            if(!rightPlace){
                gameManager.AddCorrect();
                rightPlace = true;
            }
        }

        float newRotationY = transform.eulerAngles.y;

        newRotation = new Vector3(startRotation.x, newRotationY, startRotation.z);
    }

    void LateUpdate(){
        transform.position = startPosition;
        transform.eulerAngles = newRotation;
    }
}
