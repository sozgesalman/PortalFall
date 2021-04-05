using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using PortalFall.PlayerControls;

namespace PortalFall.Portal
{
    public class ClosePortalVisibilityController : MonoBehaviour
    {
        [SerializeField] private Transform _line;
        [SerializeField] private Transform _transform;
        [SerializeField] private PlayerMovementSettings _playerMovementSettings;
        [SerializeField] private GameObject[] _forVisibilty;
        public Touch _touch;


        void Update()
        {
            Vector3 offset = (_line.transform.up * _playerMovementSettings.PositionOffSet.y);
        
            _transform.position = _line.position - offset;

            for (int i = 0; i < _forVisibilty.Length; i++)
            {
                _forVisibilty[i].GetComponent<Renderer>().enabled = false;
                _forVisibilty[i].GetComponent<Collider>().enabled = false;
            }
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