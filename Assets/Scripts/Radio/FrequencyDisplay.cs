using TMPro;
using UnityEngine;

public class FrequencyDisplay : MonoBehaviour
{
    public RadioController radio;
    public TextMeshProUGUI text;

    void Update()
    {
        int mhz = radio.frequency * 10;
        text.text = mhz.ToString();
    }
}
