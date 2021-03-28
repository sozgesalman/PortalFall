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
        public float TimeBeforeFall = 5;


        
    }
}
