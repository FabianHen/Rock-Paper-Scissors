using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CheckBoxScript : MonoBehaviour
{
    private AudioSource sound;
    private void Start() {
        sound = GetComponent<AudioSource>();
    }
    public void OnToggle() {
        sound.Play();
        if (gameObject.GetComponent<Toggle>().isOn) {
            ManagerScript.Instance.destroyOnHit = true;
        } else {
            ManagerScript.Instance.destroyOnHit = false;
        }
    }
}
