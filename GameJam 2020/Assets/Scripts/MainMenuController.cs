using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
 
public class MainMenuController : MonoBehaviour
{
    public GameObject mainMenu;
    public GameObject optionsMenu;

    void Awake()
    {
        mainMenu.SetActive(true);
        optionsMenu.SetActive(false);
    }
 
 
    public void playGame() {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }
 
    public void options() {
        mainMenu.SetActive(false);
        optionsMenu.SetActive(true);
    }
 
    public void back() {
        mainMenu.SetActive(true);
        optionsMenu.SetActive(false);
    }
 
    public void exitGame() {
        Application.Quit();
    }
}