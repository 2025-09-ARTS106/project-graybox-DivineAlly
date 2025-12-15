using UnityEngine;

[CreateAssetMenu(menuName = "Radio/Band Profile")]
public class RadioBandProfileSO : ScriptableObject
{
    public RadioBand band;

    [Header("Noise")]
    public AudioClip staticLoop;
    [Range(0f, 1f)] public float baseStaticVolume = 0.4f;

    [Header("Clarity Curve")]
    public AnimationCurve clarityCurve;
    // x = signal strength (0–1)
    // y = clarity multiplier

    [Header("Band Flavor")]
    public float tuningSensitivity = 1f; // AM sloppy, FM precise
    public float musicMasking = 0f;       // FM music bleed
}
