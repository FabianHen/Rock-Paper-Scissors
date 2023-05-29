using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuScript : MonoBehaviour
{
    [SerializeField] private GameObject mainMenu, optionsMenu;

    private void Start() {
        
    }
    public void PlayGame() {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }

    public void Options() {
        mainMenu.SetActive(false);
        optionsMenu.SetActive(true);
    }

    public void Back() {
        optionsMenu.SetActive(false);
        mainMenu.SetActive(true);
    }

    public void Quit() {
        Application.Quit();
    }
}
