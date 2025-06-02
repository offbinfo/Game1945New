using Cinemachine;
using Sirenix.OdinInspector;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : Singleton<CameraController>
{

    private Animator animator;
    public bool isInActive = true;
    private const string nameCloseBtnAnim = "close";
    private const string nameOpenBtnAnim = "open";

    public Camera mainCam;

    //Shake
    private float ShakeDuration = 0.3f;          
    private float ShakeAmplitude = 1.2f;         
    private float ShakeFrequency = 2.0f;        

    private float ShakeElapsedTime = 0f;

    public float shakeLow = 0.1f;
    public float shakeMedium = 0.2f;
    public float shakeHigh = 0.3f;

    public CinemachineVirtualCamera VirtualCamera;
    private CinemachineBasicMultiChannelPerlin virtualCameraNoise;
    public TypeShake typeShake;

    private float targetOrthoSize = 2;
    private float zoomSpeed = 0.8f;

    protected override void Awake()
    {
        base.Awake();
        animator = GetComponent<Animator>();
        mainCam = GetComponent<Camera>();   
        if (VirtualCamera != null)
            virtualCameraNoise = VirtualCamera.GetCinemachineComponent<Cinemachine.CinemachineBasicMultiChannelPerlin>();
    }

    public void ZoomOutSmooth()
    {
        if (VirtualCamera != null)
        {
            targetOrthoSize += 0.2f;
        }
    }

    private void Update()
    {
        if (VirtualCamera != null)
        {
            VirtualCamera.m_Lens.OrthographicSize = Mathf.Lerp(
                VirtualCamera.m_Lens.OrthographicSize,
                targetOrthoSize,
                Time.deltaTime * zoomSpeed
            );
        }

        if (virtualCameraNoise == null) return;

        if (ShakeElapsedTime > 0)
        {
            virtualCameraNoise.m_AmplitudeGain = ShakeAmplitude;
            virtualCameraNoise.m_FrequencyGain = ShakeFrequency;

            ShakeElapsedTime -= Time.deltaTime;
        }
        else
        {
            virtualCameraNoise.m_AmplitudeGain = 0f;
            virtualCameraNoise.m_FrequencyGain = 0f;
        }
    }

    public void SmoothUpOthorSizeCam()
    {
        if (VirtualCamera != null)
        {
            VirtualCamera.m_Lens.OrthographicSize += 0.2f;
        }
    }

    private void LateUpdate()
    {
        if (VirtualCamera == null) return;

        Vector3 pos = VirtualCamera.transform.position;
        pos.z = -10f;  
        VirtualCamera.transform.position = pos;
    }

    [Button("Test")]
    public void Test()
    {
        StartShake(ShakeDuration, shakeLow, ShakeFrequency);
    }

    public void Shake(TypeShake typeShake)
    {
        switch(typeShake)
        {
            case TypeShake.Low:
                StartShake(ShakeDuration, shakeLow, ShakeFrequency);
                break;
            case TypeShake.High:
                StartShake(ShakeDuration, shakeHigh, ShakeFrequency);
                break;
            case TypeShake.Medium:
                StartShake(ShakeDuration, shakeMedium, ShakeFrequency);
                break;
            default: 
                break;
        }
    }

    private void StartShake(float duration, float amplitude, float frequency)
    {
        ShakeDuration = duration;
        ShakeAmplitude = amplitude;
        ShakeFrequency = frequency;
        ShakeElapsedTime = duration;
    }

    public void InActiveCamCinematic()
    {
        if(isInActive) return;
        isInActive = true;
        animator.Play(nameOpenBtnAnim);
    }
    public void ActiveCamCinematic()
    {
        isInActive = false;
        animator.Play(nameCloseBtnAnim);
    }
}
