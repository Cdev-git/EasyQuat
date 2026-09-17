using UnityEngine;

namespace EasyQuat
{
    public static class Quat
    {
        const float MinLength = 1e-6f;

        public static Quaternion Vec3ToQuat(Vector3 direction)
        {
            return Vec3ToQuat(direction, Vector3.up);
        }

        public static Quaternion Vec3ToQuat(Vector3 direction, Vector3 up)
        {
            if (direction.sqrMagnitude < MinLength)
                return Quaternion.identity;

            if (up.sqrMagnitude < MinLength)
                up = Vector3.up;

            direction.Normalize();
            up.Normalize();

            if (Mathf.Abs(Vector3.Dot(direction, up)) > 0.9999f)
                up = Mathf.Abs(direction.y) > 0.9999f ? Vector3.forward : Vector3.up;

            return Quaternion.LookRotation(direction, up);
        }

        public static Quaternion Vec3ToQuat(float x, float y, float z)
        {
            return Vec3ToQuat(new Vector3(x, y, z), Vector3.up);
        }

        public static Quaternion EulerToQuat(Vector3 eulerAngles)
        {
            return Quaternion.Euler(eulerAngles);
        }

        public static Quaternion EulerToQuat(float pitch, float yaw, float roll)
        {
            return Quaternion.Euler(pitch, yaw, roll);
        }
    }

    public static class QuatExtensions
    {
        public static Quaternion Vec3ToQuat(this Vector3 direction)
        {
            return Quat.Vec3ToQuat(direction, Vector3.up);
        }

        public static Quaternion Vec3ToQuat(this Vector3 direction, Vector3 up)
        {
            return Quat.Vec3ToQuat(direction, up);
        }

        public static Quaternion EulerToQuat(this Vector3 eulerAngles)
        {
            return Quat.EulerToQuat(eulerAngles);
        }
    }
}
