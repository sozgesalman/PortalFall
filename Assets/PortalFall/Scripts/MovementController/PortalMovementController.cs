using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using PortalFall.PlayerControls;

namespace PortalFall.Portal
{
    public class PortalMovementController : MonoBehaviour
    {
       // [SerializeField] private GameObject _line;
        [SerializeField] private Transform _transform;
        [SerializeField] private Transform _player;
        [SerializeField] private PlayerMovementSettings _playerMovementSettings;
        private bool _push = false;

        


        void Update()
        {
            LineFollow();                        

        }

        protected void LineFollow()
        {
            Vector3 offset = (_transform.up * _playerMovementSettings.PositionOffSet.y);
            // For the OpenLine Position 
            _transform.position = Vector3.Lerp(_transform.position, _player.position - offset, Time.deltaTime);
        }

    }
}