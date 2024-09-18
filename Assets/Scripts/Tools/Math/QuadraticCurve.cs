using UnityEngine;

namespace MrHatProduction.Tools.Math
{
    public class QuadraticCurve
    {
        private Vector3 _a;
        private Vector3 _b;
        private Vector3 _control;

        public QuadraticCurve(Vector3 a, Vector3 b, Vector3 control)
        {
            _a = a;
            _b = b;
            _control = control;
        }
        
        public Vector3 Evaluate(float t)
        {
            var ac = Vector3.Lerp(_a, _control, t);
            var cb = Vector3.Lerp(_control, _b, t);
            return Vector3.Lerp(ac, cb, t);
        }

        public void SetPoints(Vector3 a, Vector3 b, Vector3 control)
        {
            _a = a;
            _b = b;
            _control = control;
        }
    }
}
