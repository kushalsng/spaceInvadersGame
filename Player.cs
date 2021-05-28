using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.CrossPlatformInput;

public class Player : MonoBehaviour
{
    [Header("General")]

    [Tooltip("In ms^-1")][SerializeField] float Speed = 4f;
    [Tooltip("In m")][SerializeField] float xRange = 20f;
    [Tooltip("In m")][SerializeField] float yRange = 20f;
    [Header("Screen-Position Based")]
    [SerializeField] float positionPitchFactor = -2f;
    [SerializeField] float positionYawFactor = 1f;
    [Header("Control-Throw Based")]
    [SerializeField] float ControlPitchFactor = -20f;
    [SerializeField] float ControlRollFactor = -20f;

    [SerializeField] GameObject[] guns;

    float xThrow, yThrow;
    bool isControlEnabled = true;

    // Update is called once per frame
    void Update()
    {
        if (isControlEnabled)
        {
            ProcessTranslation();
            ProcessRotation();
            ProcessFiring();
        }
        
    }
    void ProcessFiring()
    {
        if (CrossPlatformInputManager.GetButton("Fire"))
        {
            ActivateGuns(true);
        }
        else
        {
            ActivateGuns(false);
        }
    }

    private void ActivateGuns(bool isActive)
    {
        foreach (GameObject gun in guns)
        {
            gun.SetActive(isActive);
            //var emissionModule = gun.GetComponent<ParticleSystem>().emission;
            //emissionModule.enabled = isActive;
        }
    }
    void OnPlayerDeath()
    {
        isControlEnabled = false;
    }

    private void ProcessRotation()
    {
        float pitchDueToPosition = transform.localPosition.y * positionPitchFactor;
        float pitchDueToControlThrow = yThrow * ControlPitchFactor;
        float pitch = pitchDueToPosition + pitchDueToControlThrow;

        float yaw = transform.localPosition.x * positionYawFactor;
        float roll = xThrow * ControlRollFactor;
        transform.localRotation = Quaternion.Euler(pitch, yaw, roll);
    }

    private void ProcessTranslation()
    {
        yThrow = CrossPlatformInputManager.GetAxis("Vertical");
        xThrow = CrossPlatformInputManager.GetAxis("Horizontal");
        float yOffset = yThrow * Speed * Time.deltaTime;
        float xOffset = xThrow * Speed * Time.deltaTime;
        float rawYPos = transform.localPosition.y + yOffset;
        float rawXPos = transform.localPosition.x + xOffset;
        float clampedYPos = Mathf.Clamp(rawYPos, -yRange, yRange);
        float clampedXPos = Mathf.Clamp(rawXPos, -xRange, xRange);
        transform.localPosition = new Vector3(clampedXPos, clampedYPos, transform.localPosition.z);
    }
}
