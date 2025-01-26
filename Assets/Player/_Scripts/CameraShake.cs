using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;

public class CameraShake : MonoBehaviour
{
    public static CameraShake Instance { get; private set; }

    private CinemachineVirtualCamera _cam;
    private float _shakeTime;
    private void Awake()
    {
        Instance = this;
        _cam = GetComponent<CinemachineVirtualCamera>();
    }


    public void ShakeCamera(float intensity, float timer)
    {
        CinemachineBasicMultiChannelPerlin cinemachinePerlin = _cam.GetCinemachineComponent<CinemachineBasicMultiChannelPerlin>(); 

        cinemachinePerlin.m_AmplitudeGain = intensity;
        _shakeTime = timer;


    }

    private void Update()
    {
        if(_shakeTime > 0)
        {
            _shakeTime -= Time.deltaTime;
            if( _shakeTime < 0 )
            {
                CinemachineBasicMultiChannelPerlin cinemachinePerlin = _cam.GetCinemachineComponent<CinemachineBasicMultiChannelPerlin>();

                cinemachinePerlin.m_AmplitudeGain = 0;

            }
        }
    }
}
