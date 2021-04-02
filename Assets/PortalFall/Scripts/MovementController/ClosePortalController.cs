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
        float WPradius = 1;

        //[SerializeField] private GameObject _line;
        [SerializeField] private Transform _transform;
        //[SerializeField] private Transform _player;
       
        [SerializeField] private PlayerMovementSettings _playerMovementSettings;
        

        void Update()
        {

            if (Vector3.Distance(waypoints[current].transform.position, _transform.position) < WPradius)
            {
                current++;
                if (current >= waypoints.Length)
                {
                    current = 0;
                }
            }
            _transform.position = Vector3.MoveTowards(_transform.position, waypoints[current].transform.position, Time.deltaTime * _playerMovementSettings.PortalSpeed);

            //if (Input.GetKeyDown(KeyCode.Mouse0))
            //{
            //    _push = true;
            //    //_line.GetComponent<MeshRenderer>().enabled = !GetComponent<MeshRenderer>().enabled;

            //}



        }


    }
}
