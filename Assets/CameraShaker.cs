using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;

public class CameraShaker : MonoBehaviour {

  public static CameraShaker instance;

  public float shakeDuration = 0.3f;
  public float shakeAmplitude = 1.2f;
  public float shakeFrequency = 2.0f;
  private float shakeElapsedTime = 0f;

  public CinemachineVirtualCamera virtualCamera;
  private CinemachineBasicMultiChannelPerlin virtualCameraNoise;

  void Awake() {

    if (instance == null) {
      instance = this;
    } else {
      Destroy(gameObject);
      return;
    }

    DontDestroyOnLoad(gameObject);
  }

  void Start () {
    if (virtualCamera != null) {
      virtualCameraNoise = virtualCamera.GetCinemachineComponent<CinemachineBasicMultiChannelPerlin>();
    }
  }
	
	// Update is called once per frame
	void Update () {

    if (virtualCamera != null || virtualCameraNoise != null) {
      if (shakeElapsedTime > 0) {
        virtualCameraNoise.m_AmplitudeGain = shakeAmplitude;
        virtualCameraNoise.m_FrequencyGain = shakeFrequency;

        shakeElapsedTime -= Time.deltaTime;
      } else {
        virtualCameraNoise.m_AmplitudeGain = 0f;
        shakeElapsedTime = 0f;
      }
    }
	}

  public void ShakeOnce(float shakeDuration) {

    shakeElapsedTime = shakeDuration;
  }
}
