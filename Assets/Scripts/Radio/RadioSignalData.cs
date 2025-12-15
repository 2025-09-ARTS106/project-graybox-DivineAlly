using UnityEngine;

[CreateAssetMenu(menuName = "Radio/Signal")]
public class RadioSignalData : ScriptableObject
{
    public string signalID;
    public RadioBand band;

    [Header("Frequency")]
    public int centerFrequency;
    public int bandwidth = 200;

    [Header("Audio")]
    public AudioClip staticClip;
    public AudioClip garbledClip;
    public AudioClip clearClip;

    [Header("Gameplay")]
    public bool dangerous;
    public bool hidden;

  
}

