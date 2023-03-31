using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class GameManager : MonoBehaviour

{
    public GameObject PlanetBalls;
    private int amountCorrect = 0;
    public GameObject winPopUp;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
            for (int i = 0; i < PlanetBalls.transform.childCount; i++)
            {
                if (PlanetBalls.transform.GetChild(i).GetComponent<SnapPlanetToPosition>().inCorrectPlace)
                {
                    amountCorrect++;
                }
            }

            if(amountCorrect == 8)
            {
                winPopUp.gameObject.SetActive(true);
                Debug.Log("You won, ehhe");
            } else
            {
                amountCorrect = 0;
            }
        } 
}