using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class BackToMenu : MonoBehaviour
{
    private AudioSource sound;

    private void Start() {
        sound = GetComponent<AudioSource>();
    }
    public void OnClick() {
        sound.Play();
        SceneManager.LoadScene(0);
    }
}
