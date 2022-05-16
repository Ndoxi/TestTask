using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;


public class CameraMovement : MonoBehaviour
{
    [Header("Player script manager")]
    [SerializeField] private PlayerScriptManager _scriptManager;

    [Header("Virtual camera")]
    [SerializeField] private CinemachineVirtualCamera _virtualCamera;

    [Header("Camara zoom")]
    [Range(0.1f, 1)]
    [SerializeField] private float _zoomSensitivity = 0.55f;
    [SerializeField] private float _minCameraZoom = 2;
    [SerializeField] private float _maxCameraZoom = 7;


    private void Update()
    {
        ZoomCamera();
    }


    private void ZoomCamera()
    {
        float scrollAxisY = -1 * _scriptManager.InputHandler.ScrollInput.y;
        float zoomValue = _virtualCamera.m_Lens.OrthographicSize;
        zoomValue += scrollAxisY * _zoomSensitivity * Time.deltaTime;
        zoomValue = Mathf.Clamp(zoomValue, _minCameraZoom, _maxCameraZoom);
        _virtualCamera.m_Lens.OrthographicSize = zoomValue;
    }
}
