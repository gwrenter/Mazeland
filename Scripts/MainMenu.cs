using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    [SerializeField] GameObject instructions;
    [SerializeField] GameObject credits;
    public void PlayGame(){
        SceneManager.LoadScene("Level 1");
    }
    public void InstructionsBox(){
        instructions.SetActive(true);
    }
    public void CreditsBox(){
        credits.SetActive(true);
    }

    public void Back(){
        instructions.SetActive(false);
        credits.SetActive(false);
        //SceneManager.LoadScene("Menu");
    }
}
