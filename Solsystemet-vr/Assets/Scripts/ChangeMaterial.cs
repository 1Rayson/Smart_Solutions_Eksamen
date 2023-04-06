using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeMaterial : MonoBehaviour
{
    //MATERIAL
    public Material neutral;
    public Material correct;
    public Material wrong;

    public Material coneNeutral;
    public Material coneCorrect;
    public Material coneWrong;

    public GameObject planetBall;
    public GameObject planetCone;

    void OnTriggerEnter(Collider other)
    {
        if (other.tag == "PlanetBalls")
        {
            if (other.gameObject == planetBall)
            {
                gameObject.GetComponent<Renderer>().material = correct;
                planetCone.GetComponent<Renderer>().material = coneCorrect;
            }
            else
            {
                gameObject.GetComponent<Renderer>().material = wrong;
                planetCone.GetComponent<Renderer>().material = coneWrong;
            }
        }
    }
    void OnTriggerExit(Collider other)
    {
        if (other.tag == "PlanetBalls")
        {
            gameObject.GetComponent<Renderer>().material = neutral;
            planetCone.GetComponent<Renderer>().material = coneNeutral;
        }
    }
}
