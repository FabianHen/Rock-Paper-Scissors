using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SoundsliderScript : MonoBehaviour
{
    private Slider slider;
    private void Start() {
        slider = GetComponent<Slider>();
        slider.value = OptionValueScript.Instance.volume;
    }

    private void Update() {
        OptionValueScript.Instance.volume = slider.value;
    }
}
