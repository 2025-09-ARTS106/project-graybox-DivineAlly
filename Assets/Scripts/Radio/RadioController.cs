using UnityEngine;

public class RadioController : MonoBehaviour
{
    [Header("Power")]
    public bool powerOn = true;
    public bool muted = false;

    [Header("Tuning")]
    [Range(3, 6000)]
    public int frequency = 3000;

    public RadioBand currentBand;

    [Header("Signal State (Read Only)")]
    public float signalStrength;
    public RadioSignalData currentSignal;

    void Start()
    {
        UpdateSignal();
    }

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
            signalStrength = currentSignal.GetSignalStrength(frequency);
        }
        else
        {
            signalStrength = 0f;
        }
    }
}
