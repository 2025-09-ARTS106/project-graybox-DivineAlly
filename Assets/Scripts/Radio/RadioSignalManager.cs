using UnityEngine;
using System.Collections.Generic;

public class RadioSignalManager : MonoBehaviour
{
    public static RadioSignalManager Instance;

    public List<RadioSignalData> allSignals;

    void Awake()
    {
        Instance = this;
    }

    public RadioSignalData GetSignal(RadioBand band, int frequency)
    {
        RadioSignalData strongest = null;
        float strongestValue = 0f;

        foreach (var signal in allSignals)
        {
            if (signal.band != band) continue;

            float strength = signal.GetSignalStrength(frequency);
            if (strength > strongestValue)
            {
                strongestValue = strength;
                strongest = signal;
            }
        }

        return strongest;
    }
}
