using UnityEngine;

[System.Serializable]
public class RadioSignal
{
    public RadioBand band;
    public int minFrequency;
    public int maxFrequency;

    public AudioClip garbledClip;
    public AudioClip clearClip;

    public bool dangerous;
    public string signalID;

    public float GetSignalStrength(int frequency)
    {
        float distance = Mathf.Abs(frequency - centerFrequency);
        float halfBand = bandwidth * 0.5f;

        if (distance > halfBand)
            return 0f;

        float t = 1f - (distance / halfBand);
        return t;
    }

}

