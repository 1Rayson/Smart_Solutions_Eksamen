using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ChangeScene : MonoBehaviour
{

    public GameObject canvas;
    public AudioSource clickSound;
    
    public void HideUI(){
        PlayClickSound();
        canvas.SetActive(false);
    }
    public void MoveToScene(int sceneID)
    {
        PlayClickSound();
        SceneManager.LoadScene(sceneID);
    }
    public void PlayClickSound(){
        clickSound.Play();
        }
}
