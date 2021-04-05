using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace PortalFall.PlayerControls
{
    [CreateAssetMenu(menuName = "Portal Fall/Player/Movement Settings")]

    public class PlayerMovementSettings : ScriptableObject
    {
        public float FallSpeed = 5;
        public float PortalSpeed = 2;
        

        [SerializeField] private Vector3 _positionOffSet;
        public Vector3 PositionOffSet { get { return _positionOffSet; } }
    }
}
