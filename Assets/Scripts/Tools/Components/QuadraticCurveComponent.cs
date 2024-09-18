using System;
using MrHatProduction.Tools.Math;
using UnityEngine;

namespace MrHatProduction.Tools.Components
{
    public class QuadraticCurveComponent : MonoBehaviour
    {
        [SerializeField] private Transform _pointA = null;
        [SerializeField] private Transform _pointB = null;
        [SerializeField] private Transform _controlPoint = null;

        [SerializeField] private int _sphereAmount = 20;
        [SerializeField] private float _sphereRadius = 0.5f;

        private QuadraticCurve _curve = null;

        public QuadraticCurve Curve => _curve;

        private void Start()
        {
            _curve = new QuadraticCurve(_pointA.position, _pointB.position, _controlPoint.position);
        }

        private void OnDrawGizmos()
        {
            if (_pointA == null || _pointB == null || _controlPoint == null)
                return;
            
            if (_curve == null)
                _curve = new QuadraticCurve(_pointA.position, _pointB.position, _controlPoint.position);

            _curve.SetPoints(_pointA.position, _pointB.position, _controlPoint.position);
            
            for (int i = 0; i < _sphereAmount; i++)
            {
                Gizmos.DrawWireSphere(_curve.Evaluate((float)i / _sphereAmount), _sphereRadius);
            }
        }
    }
}
