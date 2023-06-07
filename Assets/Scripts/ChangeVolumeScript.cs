using UnityEngine;

public class ChangeVolumeScript : MonoBehaviour
{
    private AudioSource sound;

    private void Start() {
        sound = GetComponent<AudioSource>();
    }
    private void Update() {
        sound.volume = OptionValueScript.Instance.volume;
    }

}
