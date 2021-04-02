using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace PortalFall.Camera
{
    public class CameraController : MonoBehaviour
    {
        [SerializeField] private CameraSettings _cameraSettings;
        [SerializeField] private Transform _positionTarget;
        [SerializeField] private Transform _cameraTransform;
        
       
        private void Update()
        {
            CameraMovementFollow();            
        }


        private void CameraMovementFollow()
        {
            Vector3 offset = (_cameraTransform.right * _cameraSettings.PositionOffSet.x) + (_cameraTransform.up * _cameraSettings.PositionOffSet.y) +
                (_cameraTransform.forward * _cameraSettings.PositionOffSet.z);
            _cameraTransform.position = Vector3.Lerp(_cameraTransform.position, _positionTarget.position + offset,
                Time.deltaTime * _cameraSettings.PositionLerb);

            
        }
    }
}
