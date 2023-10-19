using UnityEngine;
using UnityEngine.UI;

public class TextPulse : MonoBehaviour
{
    public float minScale = 0.9f; // Minimum scale of the text
    public float maxScale = 1.1f; // Maximum scale of the text
    public float pulseSpeed = 0.75f; // Speed of the pulsation

    private RectTransform rectTransform;
    private bool isZoomingIn = true;

    void Awake()
    {
        rectTransform = GetComponent<RectTransform>();
    }

    void Update()
    {
        // Calculate the new scale based on the current scale and pulsation speed
        float newScale = rectTransform.localScale.x + (isZoomingIn ? pulseSpeed : -pulseSpeed) * Time.deltaTime;

        // Check if the text has reached the minimum or maximum scale
        if (newScale < minScale)
        {
            newScale = minScale;
            isZoomingIn = true;
        }
        else if (newScale > maxScale)
        {
            newScale = maxScale;
            isZoomingIn = false;
        }

        // Apply the new scale to the text
        rectTransform.localScale = new Vector3(newScale, newScale, 1f);
    }
}