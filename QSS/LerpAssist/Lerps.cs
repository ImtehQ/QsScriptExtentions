using System;
using System.Collections.Generic;
using System.Text;

namespace QsScriptExtentions.Lerp
{
    public enum LerpAssistList
    {
        linear,
        quadIn,
        quadOut,
        quadInOut,
        cubicIn,
        cubicOut,
        cubicInOut,
        quartIn,
        quartOut,
        quartInOut,
        quintIn,
        quintOut,
        quintInOut,
        sineIn,
        sineOut,
        sineInOut,
        expoIn,
        expoOut,
        expoInOut,
        circIn,
        circOut,
        circInOut,
        backIn,
        backOut,
        backInOut,
        elasticIn,
        elasticOut,
        elasticInOut,
        bounceIn,
        bounceOut,
        bounceInOut
    }
    public class Quaternion
    {
        public double x, y, z, w;
        public Quaternion(double x, double y, double z, double w)
        {
            this.x = x;
            this.y = y;
            this.z = z;
            this.w = w;
        }
    }
    public class Vector3
    {
        public double x, y, z;
        public Vector3(double x, double y, double z)
        {
            this.x = x;
            this.y = y;
            this.z = z;
        }
    }

    //Converted lerp class amde for Unity3D
    public static class Lerps
    {
        public static Quaternion ToCorrectedQuaternion(Quaternion original_start, Quaternion original_end, double time)
        {
            return new Quaternion(
                LerpCorrected(original_start.x, original_end.x, time),
                LerpCorrected(original_start.y, original_end.y, time),
                LerpCorrected(original_start.z, original_end.z, time),
                LerpCorrected(original_start.w, original_end.w, time));
        }
        public static Vector3 ToCorrectedVector3(Vector3 original_start, Vector3 original_end, double time)
        {
            return new Vector3(
                LerpCorrected(original_start.x, original_end.x, time),
                LerpCorrected(original_start.y, original_end.y, time),
                LerpCorrected(original_start.z, original_end.z, time));
        }

        public static double LerpCorrected(double b, double e, double v)
        {
            return ((e - b) * v) + b;
        }

        public static double Linear(double _normalized)
        {
            return _normalized;
        }

        public static double QuadIn(double _normalized)
        {
            return _normalized * _normalized;
        }

        public static double QuadOut(double _normalized)
        {
            return _normalized * (2 - _normalized);
        }

        public static double QuadInOut(double _normalized)
        {
            if ((_normalized *= 2) < 1)
            {
                return 0.5f * _normalized * _normalized;
            }

            return -0.5f * (--_normalized * (_normalized - 2) - 1);
        }

        public static double CubicIn(double _normalized)
        {
            return _normalized * _normalized * _normalized;
        }

        public static double CubicOut(double _normalized)
        {
            return --_normalized * _normalized * _normalized + 1;
        }

        public static double CubicInOut(double _normalized)
        {
            if ((_normalized *= 2) < 1)
            {
                return 0.5f * _normalized * _normalized * _normalized;
            }

            return 0.5f * ((_normalized -= 2) * _normalized * _normalized + 2);
        }

        public static double QuartIn(double _normalized)
        {
            return _normalized * _normalized * _normalized * _normalized;
        }

        public static double QuartOut(double _normalized)
        {
            return 1 - (--_normalized * _normalized * _normalized * _normalized);
        }

        public static double QuartInOut(double _normalized)
        {
            if ((_normalized *= 2) < 1)
            {
                return 0.5f * _normalized * _normalized * _normalized * _normalized;
            }

            return -0.5f * ((_normalized -= 2) * _normalized * _normalized * _normalized - 2);
        }

        public static double QuintIn(double _normalized)
        {
            return _normalized * _normalized * _normalized * _normalized * _normalized;
        }

        public static double QuintOut(double _normalized)
        {
            return --_normalized * _normalized * _normalized * _normalized * _normalized + 1;
        }

        public static double QuintInOut(double _normalized)
        {
            if ((_normalized *= 2) < 1)
            {
                return 0.5f * _normalized * _normalized * _normalized * _normalized * _normalized;
            }

            return 0.5f * ((_normalized -= 2) * _normalized * _normalized * _normalized * _normalized + 2);
        }

        public static double SineIn(double _normalized)
        {
            return 1 - Math.Cos(_normalized * Math.PI / 2);
        }

        public static double SineOut(double _normalized)
        {
            return Math.Sin(_normalized * Math.PI / 2);
        }

        public static double SineInOut(double _normalized)
        {
            return 0.5f * (1 - Math.Cos(Math.PI * _normalized));
        }

        public static double ExpoIn(double _normalized)
        {
            return _normalized == 0 ? 0 : Math.Pow(1024, _normalized - 1);
        }

        public static double ExpoOut(double _normalized)
        {
            return _normalized == 1 ? 1 : 1 - Math.Pow(2, -10 * _normalized);
        }

        public static double ExpoInOut(double _normalized)
        {
            if (_normalized == 0)
            {
                return 0;
            }

            if (_normalized == 1)
            {
                return 1;
            }

            if ((_normalized *= 2) < 1)
            {
                return 0.5f * Math.Pow(1024, _normalized - 1);
            }

            return 0.5f * (-Math.Pow(2, -10 * (_normalized - 1)) + 2);
        }

        public static double CircIn(double _normalized)
        {
            return 1 - Math.Sqrt(1 - _normalized * _normalized);
        }

        public static double CircOut(double _normalized)
        {
            return Math.Sqrt(1 - (--_normalized * _normalized));
        }

        public static double CircInOut(double _normalized)
        {
            if ((_normalized *= 2) < 1)
            {
                return -0.5f * (Math.Sqrt(1 - _normalized * _normalized) - 1);
            }

            return 0.5f * (Math.Sqrt(1 - (_normalized -= 2) * _normalized) + 1);
        }

        public static double BackIn(double _normalized)
        {
            var s = 1.70158f;

            return _normalized * _normalized * ((s + 1) * _normalized - s);
        }

        public static double BackOut(double _normalized)
        {
            var s = 1.70158f;

            return --_normalized * _normalized * ((s + 1) * _normalized + s) + 1;
        }

        public static double BackInOut(double _normalized)
        {
            var s = 1.70158f * 1.525f;

            if ((_normalized *= 2) < 1)
            {
                return 0.5f * (_normalized * _normalized * ((s + 1) * _normalized - s));
            }

            return 0.5f * ((_normalized -= 2) * _normalized * ((s + 1) * _normalized + s) + 2);
        }

        public static double ElasticIn(double _normalized)
        {
            if (_normalized == 0)
            {
                return 0;
            }

            if (_normalized == 1)
            {
                return 1;
            }

            return -Math.Pow(2, 10 * (_normalized - 1)) * Math.Sin((_normalized - 1.1f) * 5 * Math.PI);
        }

        public static double ElasticOut(double _normalized)
        {
            if (_normalized == 0)
            {
                return 0;
            }

            if (_normalized == 1)
            {
                return 1;
            }

            return Math.Pow(2, -10 * _normalized) * Math.Sin((_normalized - 0.1f) * 5 * Math.PI) + 1;
        }

        public static double ElasticInOut(double _normalized)
        {
            if (_normalized == 0)
            {
                return 0;
            }

            if (_normalized == 1)
            {
                return 1;
            }

            _normalized *= 2;

            if (_normalized < 1)
            {
                return -0.5f * Math.Pow(2, 10 * (_normalized - 1)) * Math.Sin((_normalized - 1.1f) * 5 * Math.PI);
            }

            return 0.5f * Math.Pow(2, -10 * (_normalized - 1)) * Math.Sin((_normalized - 1.1f) * 5 * Math.PI) + 1;
        }

        public static double BounceIn(double _normalized)
        {
            return 1 - BounceOut(1 - _normalized);
        }

        public static double BounceOut(double _normalized)
        {
            if (_normalized < (1 / 2.75f))
            {
                return 7.5625f * _normalized * _normalized;
            }
            else if (_normalized < (2 / 2.75f))
            {
                return 7.5625f * (_normalized -= (1.5f / 2.75f)) * _normalized + 0.75f;
            }
            else if (_normalized < (2.5f / 2.75f))
            {
                return 7.5625f * (_normalized -= (2.25f / 2.75f)) * _normalized + 0.9375f;
            }
            else
            {
                return 7.5625f * (_normalized -= (2.625f / 2.75f)) * _normalized + 0.984375f;
            }
        }

        public static double BounceInOut(double _normalized)
        {
            if (_normalized < 0.5f)
            {
                return BounceIn(_normalized * 2) * 0.5f;
            }

            return BounceOut(_normalized * 2 - 1) * 0.5f + 0.5f;
        }
    }
}
