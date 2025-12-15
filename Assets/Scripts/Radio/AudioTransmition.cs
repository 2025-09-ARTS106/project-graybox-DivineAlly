using UnityEngine;

public class RadioAudio : MonoBehaviour
{
    public RadioController radio;
    public AudioSource source;

    void Update()
    {
        if (!radio.powerOn || radio.muted)
        {
            source.volume = 0;
            return;
        }

        if (radio.currentSignal == null)
        {
            source.volume = 0.2f;
            return;
        }

        source.volume = Mathf.Lerp(0.1f, 1f, radio.signalStrength);
    }
}
