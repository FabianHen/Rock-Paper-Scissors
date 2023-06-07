using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuScript : MonoBehaviour
{
    [SerializeField] private GameObject mainMenu, optionsMenu;
    private AudioSource buttonClick;
    private void Start() {
        buttonClick = GetComponent<AudioSource>();
    }
    public void PlayGame() {
        ManagerScript.Instance.ClearObjects();
        buttonClick.Play();
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }

    public void Options() {
        buttonClick.Play();
        mainMenu.SetActive(false);
        optionsMenu.SetActive(true);
    }

    public void Back() {
        buttonClick.Play();
        optionsMenu.SetActive(false);
        mainMenu.SetActive(true);
    }

    public void Quit() {
        buttonClick.Play();
        Application.Quit();
    }
}
