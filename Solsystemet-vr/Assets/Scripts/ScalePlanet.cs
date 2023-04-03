using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScalePlanet : MonoBehaviour
{
    public GameObject scaleReference;
    public GameObject planetToLeft;
    public GameObject planetToLeftModel;
    public GameObject planetModel;
    public int planetMargin = 40;

    private Vector3 currentPosition;
    private Vector3 priorRefScale = new Vector3(0, 0, 0);
    // Start is called before the first frame update
    void Start()
    {
        currentPosition = GetComponent<Transform>().position;
        priorRefScale = scaleReference.transform.localScale;

        // MovePlanet();
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 currentRefScale = scaleReference.transform.localScale;

        if(currentRefScale != priorRefScale){
            Vector3 currentScale = transform.localScale;

            float newScaleX = (currentRefScale.x / priorRefScale.x) * currentScale.x;
            float newScaleY = (currentRefScale.y / priorRefScale.y) * currentScale.y;
            float newScaleZ = (currentRefScale.z / priorRefScale.z) * currentScale.z;
            Vector3 newScale = new Vector3(newScaleX, newScaleY, newScaleZ);

            transform.localScale = newScale;

            // planetToLeft.GetComponent<ScalePlanet>().MovePlanet();
        }
        priorRefScale = currentRefScale;
    }

    /* void MovePlanet(){
        Vector3 newPosition = currentPosition;

        float leftPlanetRadius = (planetToLeftModel.transform.localScale.x * planetToLeft.transform.localScale.x);
        float planetRadius = (planetModel.transform.localScale.x * transform.localScale.x);
        
        float planetDistance = leftPlanetRadius + planetMargin + planetRadius;
        
        newPosition.x = currentPosition.x + planetDistance;
        transform.position = newPosition;

        currentPosition = newPosition;
    } */
}
