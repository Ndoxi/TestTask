using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;


public class Cutscene1 : MonoBehaviour
{
    [Header("Cutscene camera")]
    [SerializeField] private CinemachineVirtualCamera _camera;

    [Header("Camera settings")]
    [SerializeField] private int _cameraPriority;
    [SerializeField] private float _cameraSpeed;

    [Header("Camera path")]
    [SerializeField] private CinemachineSmoothPath _cameraPath;

    [Header("Cutscine settings")]
    [SerializeField] private bool _showCutscineOnStart;

    private int _cameraStarterPriority;


    void Start()
    {
        _cameraStarterPriority = _camera.Priority;

        if (_showCutscineOnStart)
        {
            StartCoroutine(ShowCutscine());
        }
    }


    IEnumerator ShowCutscine()
    {
        _camera.Priority = _cameraPriority;
        CinemachineTrackedDolly _trackedDolly = _camera.GetCinemachineComponent<CinemachineTrackedDolly>();

        if (_trackedDolly == null) 
        {
            _camera.Priority = _cameraStarterPriority;
            yield return 0; 
        }

        while (true)
        {
            _trackedDolly.m_PathPosition += _cameraSpeed * Time.deltaTime;

            if (_trackedDolly.m_PathPosition >= _trackedDolly.m_Path.MaxPos) { break; }

            yield return new WaitForEndOfFrame();
        }

        _camera.Priority = _cameraStarterPriority;
        _trackedDolly.m_PathPosition = 0;
    }
}
