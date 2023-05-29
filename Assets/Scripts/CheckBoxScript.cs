using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CheckBoxScript : MonoBehaviour
{
 public void OnToggle() {
        if (gameObject.GetComponent<Toggle>().isOn) {
            ManagerScript.Instance.destroyOnHit = true;
        }
        else {
            ManagerScript.Instance.destroyOnHit = false;
        }
    }
}
