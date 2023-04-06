using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class GameManager : MonoBehaviour

{
    // public GameObject PlanetBalls;
    private int amountCorrect = 0;
    public GameObject winPopUp;

    //AUDIO
    public AudioSource correctSoundEffect;
    public AudioSource wrongSroundEffect;


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void AddCorrect(){
        amountCorrect++;
        correctSoundEffect.Play();

        if(amountCorrect == 8)
        {
            winPopUp.gameObject.SetActive(true);
        }
    }

    public void wrong(){
        wrongSroundEffect.Play();
    }
}