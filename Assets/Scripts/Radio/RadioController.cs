using UnityEngine;

public enum RadioBand
{
    AM,
    FM,
    MW,
    LW
}

public class RadioController : MonoBehaviour
{
    [Header("Power State")]
    public bool powerOn;
    public bool muted;

    [Header("Tuning")]
    public RadioBand currentBand = RadioBand.AM;

    [Range(3, 6000)]
    public int frequency = 3000;

    [Header("Signal")]
    [Range(0f, 1f)]
    public float signalStrength;

    public RadioSignal currentSignal;

    public void SetFrequency(int newFrequency)
    {
        frequency = Mathf.Clamp(newFrequency, 3, 6000);
        UpdateSignal();
    }

    public void SetBand(RadioBand band)
    {
        currentBand = band;
        UpdateSignal();
    }

    void UpdateSignal()
    {
        if (RadioSignalManager.Instance == null)
        {
            signalStrength = 0f;
            currentSignal = null;
            return;
        }

        currentSignal = RadioSignalManager.Instance.GetSignal(currentBand, frequency);

        if (currentSignal != null)
        {
            signalStrength = currentSignal.GetStrength(frequency);
        }
        else
        {
            signalStrength = 0f;
        }
    }
}
