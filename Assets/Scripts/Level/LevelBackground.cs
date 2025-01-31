using System;
using UnityEngine;

namespace ShootEmUp
{
    public sealed class LevelBackground : MonoBehaviour
    {
        private float _startPositionY;
        private float _endPositionY;
        private float _movingSpeedY;
        private float _positionX;
        private float _positionZ;
        private Transform _myTransform;
        [SerializeField] private Params m_params;

        private void Awake()
        {
            SetLevelBoard();
        }

        private void SetLevelBoard()
        {
            _startPositionY = m_params.m_startPositionY;
            _endPositionY = m_params.m_endPositionY;
            _movingSpeedY = m_params.m_movingSpeedY;
            _myTransform = transform;
            var position = _myTransform.position;
            _positionX = position.x;
            _positionZ = position.z;
        }

        private void FixedUpdate()
        {
            MoveLevelBoard();
        }

        private void MoveLevelBoard()
        {
            if (_myTransform.position.y <= _endPositionY)
            {
                _myTransform.position = new Vector3(
                    _positionX,
                    _startPositionY,
                    _positionZ
                );
            }

            _myTransform.position -= new Vector3(
                _positionX,
                _movingSpeedY * Time.fixedDeltaTime,
                _positionZ
            );
        }

        [Serializable]
        public sealed class Params
        {
            [SerializeField] public float m_startPositionY;
            [SerializeField] public float m_endPositionY;
            [SerializeField] public float m_movingSpeedY;
        }
    }
}