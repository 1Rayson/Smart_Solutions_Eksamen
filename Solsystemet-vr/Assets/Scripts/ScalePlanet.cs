using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScalePlanet : MonoBehaviour
{
    public GameObject scaleReference;
    Vector3 priorRefScale = new Vector3(0, 0, 0);
    // Start is called before the first frame update
    void Start()
    {
        priorRefScale = scaleReference.transform.localScale;
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
        }

        priorRefScale = currentRefScale;
    }
}
