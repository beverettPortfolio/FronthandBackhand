using UnityEngine;
using System.Collections;

/// <summary>
/// A script that creates camera shake. This should be attached to the camera object that will be shaking.
/// If the camera needs to move around, put the camera in an empty game object and move that game object instead.
/// </summary>
public class CameraShakeScript : MonoBehaviour
{
    public static float DEFAULT_SHAKE_AMOUNT = .7f;
    // How long the object should shake for.
    public float shake = 0f;

    // Amplitude of the shake. A larger value shakes the camera harder.
    public float shakeAmount = 0.7f;
    public float decreaseFactor = 1.0f;

    public Vector3 originalPos;

    private bool shakeStart;

    /// <summary>
    /// Sets the camera's original position, relative to its parent
    /// </summary>
    void OnEnable()
    {
        originalPos = Camera.main.transform.localPosition;
    }

    /// <summary>
    /// Moves the camera to a random location within the radius of shakeAmount
    /// </summary>
    void Update()
    {
        //if shakestart then set original and start shaking
        if (shake > 0 && !shakeStart)
        {
            shakeStart = true;
        }
        //if shake has started and still shake left
        else if (shake > 0 && shakeStart)
        {
            Camera.main.transform.localPosition = originalPos + Random.insideUnitSphere * shakeAmount;

            shake -= Time.deltaTime * decreaseFactor;
        }
        else if (shake <= 0 && shakeStart)
        {
            shake = 0f;
            Camera.main.transform.localPosition = originalPos;
        }
        else
        {
            Camera.main.transform.localPosition = originalPos;
        }
    }

    /// <summary>
    /// Shakes the screen for the specified amount of time.
    /// </summary>
    /// <param name="shake">Time in seconds</param>
    public void screenShake(float shake)
    {
        this.shake += shake;
        shakeAmount = DEFAULT_SHAKE_AMOUNT;
    }

    /// <summary>
    /// Shakes the screen for the specified amount of time at the specified amplitude.
    /// </summary>
    /// <param name="shakeAmount">Time in seconds</param>
    /// <param name="shake">Amplitude of the shake</param>
    public void screenShake(float shakeAmount, float shake)
    {
        this.shake += shake;
        this.shakeAmount = shakeAmount;
    }
}