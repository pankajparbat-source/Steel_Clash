using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraShake : MonoBehaviour
{
    // Variables to control shake duration and intensity
    public float shakeDuration = 0.5f;
    public float shakeIntensity = 0.3f;

    // Original position of the camera
    private Vector3 originalPosition;


    public static CameraShake instance;
    private void Awake()
    {
        instance = this;
    }
    void Start()
    {
        // Store the original position of the camera
        originalPosition = transform.localPosition;
    }

    public void Shake()
    {
        // Start the shake effect
        Debug.Log("shake the camera");
        StartCoroutine(ShakeRoutine());
    }

    private IEnumerator ShakeRoutine()
    {
        float elapsedTime = 0f;

        while (elapsedTime < shakeDuration)
        {
            // Generate random shake offset
            Vector3 randomPoint = originalPosition + Random.insideUnitSphere * shakeIntensity;
            transform.localPosition = randomPoint;

            elapsedTime += Time.deltaTime;
            yield return null;
        }

        // Reset camera to its original position
        transform.localPosition = originalPosition;
    }

}
