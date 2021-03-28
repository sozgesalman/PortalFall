using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace PortalFall.Camera
{
    [CreateAssetMenu (menuName ="Portal Fall/Camera/Camera Settings")]
    public class CameraSettings : ScriptableObject
    {
        
        [Header("Position")]
        [SerializeField] private Vector3 _positionOffSet;
        public Vector3 PositionOffSet { get { return _positionOffSet; } }

        [SerializeField] private float _positionLerp = 1;
        public float PositionLerb { get { return _positionLerp; } }
    }
}
