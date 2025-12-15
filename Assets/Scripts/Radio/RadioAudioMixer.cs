using UnityEngine;

public class RadioAudioMixer : MonoBehaviour
{
    public RadioController radio;
    public RadioBandProfile currentBand;

    public AudioSource staticSource;
    public AudioSource garbleSource;
    public AudioSource clearSource;

    void Start()
    {
        if (staticSource != null && staticSource.clip != null)
            staticSource.Play();
    }

    void Update()
    {
        if (radio == null || !radio.powerOn)
        {
            SetAllVolumes(0f);
            return;
        }

        float strength = radio.signalStrength;
        float clarity = currentBand != null
            ? currentBand.clarityCurve.Evaluate(strength)
            : strength;

        staticSource.volume = Mathf.Lerp(0.5f, 0.05f, clarity);
        garbleSource.volume = Mathf.Clamp01(1f - clarity * 1.5f);
        clearSource.volume = Mathf.Clamp01(clarity);

        if (radio.currentSignal != null)
        {
            if (garbleSource.clip != radio.currentSignal.garbledClip)
            {
                garbleSource.clip = radio.currentSignal.garbledClip;
                garbleSource.Play();
            }

            if (clearSource.clip != radio.currentSignal.clearClip)
            {
                clearSource.clip = radio.currentSignal.clearClip;
                clearSource.Play();
            }
        }
    }

    void SetAllVolumes(float v)
    {
        staticSource.volume = v;
        garbleSource.volume = v;
        clearSource.volume = v;
    }

    public void SetBandProfile(RadioBandProfile profile)
    {
        currentBand = profile;

        if (staticSource != null)
        {
            staticSource.clip = profile.staticLoop;
            staticSource.Play();
        }
    }
}
