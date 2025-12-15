using UnityEngine;


[CreateAssetMenu(menuName = "Radio/Band Profile")]
public class RadioBandProfile : ScriptableObject
{
    public RadioBand band;

    [Header("Noise")]
    public AudioClip staticLoop;
    [Range(0f, 1f)] public float baseStaticVolume = 0.4f;

    [Header("Clarity Curve")]
    public AnimationCurve clarityCurve;

    [Header("Band Flavor")]
    public float tuningSensitivity = 1f;
    public float musicMasking = 0f;
}