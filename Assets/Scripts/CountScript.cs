using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class CountScript : MonoBehaviour
{
    [SerializeField] Type type;
    [SerializeField] TextMeshProUGUI textfield;

    void Update()
    {
        textfield.SetText(CountTypes());
    }

    private string CountTypes() {
        var count = 0;
        foreach(var obj in ManagerScript.Instance.Objects) {
            if (obj.type == type) {
                count++;
            }
        }
        return count.ToString();
    }
}
 