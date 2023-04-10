using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlanetDistance : MonoBehaviour
{

    public GameManager gameManager;
    Vector3 correctDistance;
    public float startYRotation = 73f;
    public float tolerance = 1f;
    private bool rightPlace = false;
    // Start is called before the first frame update
    void Start()
    {
        correctDistance = transform.localEulerAngles;
        transform.localEulerAngles = new Vector3(0, startYRotation, 0);
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
    }
}
