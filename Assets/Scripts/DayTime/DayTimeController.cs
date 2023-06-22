using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class DayTimeController : MonoBehaviour
{
    [SerializeField]
    [Range(0,1)]
    private float initialDaytimeProgress;


    [SerializeField]
    [Range(0, 1)]
    private float dayEnd = 0.5f;

    [Min(0f)]
    [SerializeField]
    private float dayDurationSeconds = 120f;

    [Min(0f)]
    [SerializeField]
    private float sunIntensityTransitionSpeed = 3f;

    [SerializeField]
    private bool smoothSunIntensity;

    [SerializeField]
    private Vector3 sunRotationAxis = Vector3.right;

    [SerializeField]
    private Light sun;

    private Material skyboxMaterial;

    private float initialSunIntensity;
    private float targetSunIntensity;
    private float dayTimeProgress;

    public bool IsDay => dayTimeProgress <= dayEnd;

    private void Awake() 
    {
        skyboxMaterial = new Material(RenderSettings.skybox);
        RenderSettings.skybox = skyboxMaterial;

        initialSunIntensity = sun.intensity;
        dayTimeProgress = initialDaytimeProgress;
    }
    void Update()
    {
        UpdateDateTimeProgress();
        UpdateSunRotation();
        UpdateTargetSunIntensity();

        if (smoothSunIntensity)
            UpdateSunIntensitySmooth();
        else
            UpdateSunIntensity();
    }

    private void UpdateDateTimeProgress()
    {
        dayTimeProgress += Time.deltaTime / dayDurationSeconds;

        if (dayTimeProgress >= 1f)
            dayTimeProgress = 0f;
    }

    private void UpdateSunRotation()
    {
        var angle = Mathf.Lerp(0, 360, dayTimeProgress);
        var rotation = Quaternion.AngleAxis(angle, sunRotationAxis);

        sun.transform.rotation = rotation;
    }

    private void UpdateTargetSunIntensity() => targetSunIntensity = IsDay ? initialSunIntensity : 0f;
    private void UpdateSunIntensitySmooth() =>
        sun.intensity = Mathf.Lerp(sun.intensity, targetSunIntensity, Time.deltaTime * sunIntensityTransitionSpeed);
    private void UpdateSunIntensity() => sun.intensity = IsDay ? initialSunIntensity : 0f;

}
