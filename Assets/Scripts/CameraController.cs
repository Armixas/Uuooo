using System;
using System.Collections;
using UnityEngine;

namespace Assets.Scripts
{
    public class CameraController : MonoBehaviour
    {
        [SerializeField]
        private Transform _target;
        [SerializeField]
        private Vector3 _offsetPosition = new Vector3(0f, 1.7f, -2.5f);
        private Space _offsetPositionSpace = Space.Self;

        private bool _lookAt = true;

        // Use this for initialization
        void Start()
        {

        }

        // Update is called once per frame
        void Update()
        {
            if (_target == null)
                return;
            UpdatePosition();
            UpdateRotation();
        }
        void UpdatePosition()
        {
            if (_offsetPositionSpace == Space.Self)
            {
                transform.position = _target.TransformPoint(_offsetPosition);
            }
            else
            {
                transform .position = _target.position + _offsetPosition;
            }        
        }
        private void UpdateRotation()
        {
            if (_lookAt)
            {
                transform.LookAt(_target);
            }
            else 
            {
                transform.rotation = _target.rotation;
            }
        }

        
    }
}