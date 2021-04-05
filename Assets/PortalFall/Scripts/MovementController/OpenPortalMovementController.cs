using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using PortalFall.PlayerControls;

namespace PortalFall.Portal
{
    public class OpenPortalMovementController : MonoBehaviour
    {
       // [SerializeField] private GameObject _line;
        [SerializeField] private Transform _transform;
        [SerializeField] private Transform _player;
        [SerializeField] private PlayerMovementSettings _playerMovementSettings;
        Touch _touch ;
        [SerializeField] private GameObject[] _forVisibilty;

        void Update()
        {
            LineFollow();
        }

        protected void LineFollow()
        {
            for (int i = 0; i < _forVisibilty.Length; i++)
            {
                _forVisibilty[i].GetComponent<Renderer>().enabled = false;
                _forVisibilty[i].GetComponent<Collider>().enabled = false;
            }
            Vector3 offset = (_transform.up * _playerMovementSettings.PositionOffSet.y);
            _transform.position = _player.position - offset;

            if (Input.touchCount > 0)
            {
                _touch = Input.GetTouch(0);
                if (_touch.phase == TouchPhase.Stationary)
                {
                    for (int i = 0; i < _forVisibilty.Length; i++)
                    {
                        _forVisibilty[i].GetComponent<Renderer>().enabled = true;
                        _forVisibilty[i].GetComponent<Collider>().enabled = true;
                    }

                }

            }

        }

    }
}