using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using PortalFall.Portal;

namespace PortalFall.PlayerControls
{
    public class PlayerMovementController : MonoBehaviour
    {
        [SerializeField] GameObject _player;
        [SerializeField] private Transform _transform;
        [SerializeField] private bool _canFall;
        [SerializeField] private PlayerMovementSettings _playerMovementSettings;
        Touch _touch;

        //void Start()
        //{
        //    Invoke("DisplayPlayer", 2);
        //    StartCoroutine(ReadyToFall());
            
        //}
        //public void DisplayPlayer()
        //{
        //    _player.SetActive(true);
        //}

        void Update()
        {
            if (Input.touchCount > 0)
            {
                _touch = Input.GetTouch(0);
                if (_touch.phase == TouchPhase.Stationary)
                {
                    _transform.Translate(Vector3.down * 1 * Time.deltaTime, Space.World);
                }              
            }


            if (_touch.phase == TouchPhase.Ended)
            {
                _transform.Translate(Vector3.down * 8 * Time.deltaTime, Space.World);

            }
            else if (!Input.GetKey(KeyCode.V))
            {
                _transform.Translate(Vector3.down * _playerMovementSettings.FallSpeed * Time.deltaTime, Space.World);
            }
        }
       
        //IEnumerator ReadyToFall()
        //{
        //    _canFall = false;
        //    yield return new WaitForSeconds(_playerMovementSettings.TimeBeforeFall);
        //    _canFall = true;
        //}


    }
}
