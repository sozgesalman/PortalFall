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

        [SerializeField] private GameObject _line ;
        [SerializeField] private Transform _transform ;
        [SerializeField] private Transform _player;
        [SerializeField] private PlayerMovementSettings _playerMovementSettings ;
        [SerializeField] private GameObject[] _forVisibilty ;
        private Collision _collision;

        void Update()
        {
            

            for (int i = 0; i < _forVisibilty.Length; i++)
            {
                _forVisibilty[i].GetComponent<Renderer>().enabled = false ;
                _forVisibilty[i].GetComponent<Collider>().enabled = false ;
                
            }


            if (!Input.GetKey(KeyCode.V))
            {
                Vector3 offset = (_transform.up * _playerMovementSettings.PositionOffSet.y);
                _transform.position = Vector3.Lerp(_transform.position, _player.position - offset, Time.deltaTime);

            }


            if (Vector3.Distance(waypoints[current].transform.position, _transform.position) < WPradius)
            {
                current++ ;
                if (current >= waypoints.Length)
                {
                    current = 0 ;
                }
            }

            if (Input.GetKey(KeyCode.V))                
            {
                
                for (int i = 0; i < _forVisibilty.Length; i++)
                {
                    _forVisibilty[i].GetComponent<Renderer>().enabled = true ;
                    _forVisibilty[i].GetComponent<Collider>().enabled = true;
                }
                _transform.position = Vector3.MoveTowards(_transform.position, waypoints[current].transform.position, Time.deltaTime * _playerMovementSettings.PortalSpeed) ;
            }
            else if (Input.GetKeyUp(KeyCode.V))
            {
                for (int i = 0; i < _forVisibilty.Length; i++)
                {
                    _forVisibilty[i].GetComponent<Renderer>().enabled = true;
                    _forVisibilty[i].GetComponent<Collider>().enabled = true;
                }
                
                //_transform.GetComponent<Transform>().enabled = false;
            }

        }

        void OnCollisionEnter(Collision collision)
        {
            //Check for a match with the specified name on any GameObject that collides with your GameObject
            if (collision.gameObject == _player)
            {
                //If the GameObject's name matches the one you suggest, output this message in the console
                Debug.Log("Do something here");
            }

            //Check for a match with the specific tag on any GameObject that collides with your GameObject
            if (collision.gameObject == _line)
            {
                //If the GameObject has the same tag as specified, output this message in the console
                Debug.Log("Do something else here");
            }
        }
    }
}
