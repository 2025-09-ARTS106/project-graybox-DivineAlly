using UnityEngine;

[CreateAssetMenu(menuName = "Radio/Signal")]
public class RadioSignalData : ScriptableObject
{
    public string signalID;
    public RadioBand band;

    [Header("Frequency")]
    public int centerFrequency;
    public int bandwidth = 200;

    public float GetSignalStrength(int frequency)
    {
        float distance = Mathf.Abs(frequency - centerFrequency);
        float halfBand = bandwidth * 0.5f;

        if (distance > halfBand) return 0f;
        return 1f - (distance / halfBand);
    }
    [Header("Audio")]
    public AudioClip staticClip;
    public AudioClip garbledClip;
    public AudioClip clearClip;

    [Header("Gameplay")]
    public bool dangerous;
    public bool hidden;

  
}

