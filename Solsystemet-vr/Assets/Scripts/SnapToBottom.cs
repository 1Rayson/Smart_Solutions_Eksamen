using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SnapToBottom : MonoBehaviour
{
     private Vector3 currentPosition;

     private Vector3 priorScale;
    
    // Start is called before the first frame update
    void Start()
    {
        priorScale = transform.localScale;
    }

    // Update is called once per frame
    void Update()
    {
        // ScaleAround(gameObject, transform.localPosition, transform.localScale);
        //transform.position = transform.position + new Vector3(0, currentPosition.y, 0);

        Vector3 currentScale = transform.localScale;
        Vector3 currentPosition = transform.position;

        float newPositionY = currentPosition.y + (priorScale.y - currentScale.y);

        Vector3 newPosition = new Vector3(currentPosition.x, newPositionY, currentPosition.z);

        if(Input.GetKeyDown(KeyCode.M)){
            Debug.Log(newPositionY);
        }

        transform.position = newPosition;
        priorScale = currentScale;

    }

    public void ScaleAround(GameObject target, Vector3 pivot, Vector3 newScale)
    {
        Vector3 A = target.transform.localPosition;
        Vector3 B = pivot;
    
        Vector3 C = A - B; // diff from object pivot to desired pivot/origin
    
        float RS = newScale.x / target.transform.localScale.x; // relative scale factor
    
        // calc final position post-scale
        Vector3 FP = B + C * RS;
    
        // finally, actually perform the scale/translation
        target.transform.localScale = newScale;
        target.transform.localPosition = FP;
    }
}
