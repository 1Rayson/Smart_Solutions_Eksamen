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
    private float tolerance = 0.3f;
    private bool correctSize = false;
    
    void Start()
    {
        currentPosition = GetComponent<Transform>().position;
        priorRefScale = scaleReference.transform.localScale;
    }

    void Update()
    {
        if(!correctSize)
        {
            Vector3 currentRefScale = scaleReference.transform.localScale;

            if(currentRefScale != priorRefScale)
            {
                Vector3 currentScale = transform.localScale;

                /* 
                    Da planeterne skalere det samme på x, y og z, så behøver jeg kun at finde en værdi
                    og så gange det på en (1, 1, 1) vektor. 
                */
                float newScaleX = (currentRefScale.x / priorRefScale.x) * currentScale.x;
                float newScaleY = (currentRefScale.y / priorRefScale.y) * currentScale.y;
                float newScaleZ = (currentRefScale.z / priorRefScale.z) * currentScale.z;

                /*
                    Denne linje kan jeg bruge til begrænse skalering, også til planetboldene
                    newScaleX = Mathf.Clamp(newScaleX, 0.5f, 2f);
                */

                Vector3 newScale = new Vector3(newScaleX, newScaleY, newScaleZ);

                transform.localScale = newScale;

                if(
                    (newScaleX > 1 - tolerance && newScaleX < 1 + tolerance) &&
                    (newScaleY > 1 - tolerance && newScaleY < 1 + tolerance) &&
                    (newScaleZ > 1 - tolerance && newScaleZ < 1 + tolerance)
                )
                {
                    correctSize = true;
                    transform.localScale = new Vector3(1, 1, 1);
                }
            }

            priorRefScale = currentRefScale;

        }

        Vector3 newPosition = currentPosition;

        float leftPlanetRadius = (planetToLeftModel.transform.localScale.x * planetToLeft.transform.localScale.x);
        float planetRadius = (planetModel.transform.localScale.x * transform.localScale.x);
        
        float planetDistance = (leftPlanetRadius + planetMargin + planetRadius) * -1;
        
        newPosition.x = planetToLeft.transform.position.x + planetDistance;
        transform.position = newPosition;

        currentPosition = newPosition;
    }
}
