using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using PortalFall.PlayerControls;

namespace PortalFall.Portal
{
    public class ClosePortalController : MonoBehaviour
    {
        public GameObject[] waypoints;
        int current = 0;
        float WPradius = 0.1f;

        [SerializeField] private GameObject _line;
        [SerializeField] private Transform _player;
        [SerializeField] private PlayerMovementSettings _playerMovementSettings;
        [SerializeField] private GameObject[] _forVisibilty;
        public Touch _touch;


        void Update()
        {
            
            Vector3 offset = (_line.transform.up * _playerMovementSettings.PositionOffSet.y);

            for (int i = 0; i < _forVisibilty.Length; i++)
            {
                _forVisibilty[i].GetComponent<Renderer>().enabled = false;
                _forVisibilty[i].GetComponent<Collider>().enabled = false;

            }

            if (Vector3.Distance(waypoints[current].transform.position, _line.transform.position) < WPradius)
            {
                current++;
                if (current >= waypoints.Length)
                {
                    current = 0;
                }
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

                    _line.transform.position = Vector3.MoveTowards(_line.transform.position, waypoints[current].transform.position, Time.deltaTime * _playerMovementSettings.PortalSpeed);
                }

            }
            if (_touch.phase == TouchPhase.Ended)
            {

                for (int i = 0; i < _forVisibilty.Length; i++)
                {
                    _forVisibilty[i].GetComponent<Renderer>().enabled = true;
                    _forVisibilty[i].GetComponent<Collider>().enabled = true;

                    _line.transform.position = Vector3.MoveTowards(_line.transform.position, waypoints[current].transform.position, Time.deltaTime * 0);
                    
                }

            }

            else if (!Input.GetKey(KeyCode.V))
            {
                

                _line.transform.position = Vector3.Lerp(_line.transform.position, _player.position - offset, Time.deltaTime);
            }

        }


    }
}


