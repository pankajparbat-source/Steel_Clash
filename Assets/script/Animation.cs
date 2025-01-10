using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Animation : MonoBehaviour
{
    public RectTransform imageRectTransform; // Assign the RectTransform of the UI Image in the Inspector
    public float scaleDuration = 0.5f;       // Duration for each scaling phase (increase/decrease)
    public Vector3 targetScale = new Vector3(1.5f, 1.5f, 1); // Target scale for increase (example)

    void Start()
    {
        StartScalingAnimation();
    }

    // Method to start the continuous scaling animation
    private void StartScalingAnimation()
    {
        // Create a scaling animation that increases, then decreases, in a loop
        imageRectTransform.DOScale(targetScale, scaleDuration)
            .SetEase(Ease.InOutSine) // Smooth easing for increase and decrease
            .OnComplete(() =>
            {
                // Once increase completes, scale back to original size and loop
                imageRectTransform.DOScale(Vector3.one, scaleDuration)
                    .SetEase(Ease.InOutSine)
                    .OnComplete(StartScalingAnimation); // Repeat the process
            });
    }
}
