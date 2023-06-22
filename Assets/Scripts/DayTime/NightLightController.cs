using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NightLightController : MonoBehaviour
{
    [Min(0f)]
    [SerializeField]
    private float IntensityTransitionSpeed = 3f;

    [SerializeField]
    private bool smoothIntensity;

    [SerializeField]
    private Vector3 sunRotationAxis = Vector3.right;

    [SerializeField]
    private Light light;

    private DayTimeController dayTimeController;

    private float initialIntensity;
    private float targetIntensity;

    private void Awake()
    {
        dayTimeController = FindObjectOfType<DayTimeController>();
        light = GetComponent<Light>();
        initialIntensity = light.intensity;
    }
    // Start is called before the first frame update
    void Start()
    {
        UpdateTargetIntensity();
        UpdateLightIntensity();
    }
    // Update is called once per frame
    void Update()
    {
        UpdateTargetIntensity();

        if (smoothIntensity)
            UpdateLightIntensitySmooth();
        else 
            UpdateLightIntensity();
    }

    private void UpdateLightIntensitySmooth() =>
        light.intensity = Mathf.Lerp(light.intensity, targetIntensity, Time.deltaTime * IntensityTransitionSpeed);
    private void UpdateTargetIntensity() => targetIntensity = dayTimeController.IsDay ? 0f : initialIntensity;
    private void UpdateLightIntensity() => light.intensity = targetIntensity;

   
}
