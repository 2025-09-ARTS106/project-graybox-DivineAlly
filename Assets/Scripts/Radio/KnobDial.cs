using UnityEngine;
using UnityEngine.EventSystems;

public class KnobDial : MonoBehaviour, IDragHandler
{
    public RadioController radio;
    public int step = 1; // right knob = 1, left knob = 10

    float lastX;

    public void OnDrag(PointerEventData eventData)
    {
        float delta = eventData.delta.x;

        if (Mathf.Abs(delta) < 1f) return;

        int direction = delta > 0 ? 1 : -1;
        radio.SetFrequency(radio.frequency + (direction * step));

        RotateVisual(direction);
    }

    void RotateVisual(int direction)
    {
        transform.Rotate(Vector3.forward, -direction * 2f);
    }
}
