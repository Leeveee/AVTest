using UnityEngine;

namespace Extensions
{
    public static class CameraExtensions
    {
        public static Vector3 ScreenToLocalCamPos (this Camera cam, Vector3 screenPos, float camZ)
        {
            Vector3 pos = cam.ScreenToWorldPoint(new Vector3(screenPos.x, screenPos.y, camZ));
            return cam.transform.InverseTransformPoint(pos);
        }
    }
}