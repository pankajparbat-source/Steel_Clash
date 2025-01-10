using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class CanvasBounceAnimation : MonoBehaviour
{
    public RectTransform canvasRectTransform; // Assign the RectTransform of the Canvas/UI Panel in the Inspector
    public float targetXPosition = 0f;        // Target X position to stop at (centered position)
    public float animationDuration = 1.5f;    // Duration for the animation

    public static CanvasBounceAnimation instance;

    private void Awake()
    {
        instance = this;
    }
    void Start()
    {
        // Start the bouncing animation
        ///StartBounceAnimation();
    }

    public void StartBounceAnimation()
    {
        float startXPosition = -Screen.width;

        // Set the starting position
        canvasRectTransform.anchoredPosition = new Vector2(startXPosition, canvasRectTransform.anchoredPosition.y);

        // Animate the canvas from left to right with an elastic effect
        canvasRectTransform.DOAnchorPosX(targetXPosition, animationDuration)
            .SetEase(Ease.OutElastic, 1.2f, 0.5f) ; // Elastic easing with custom overshoot and period for extra elasticity
           
} 

}
