using UnityEngine;

namespace Extensions
{
  public static class VectorExtensions
  {
    public static Vector3 AddY(this Vector3 vector, float value)
    {
      return new Vector3(vector.x, vector.y + value, vector.z);
    }

    public static Quaternion RotateTowardsDirection(this Quaternion currentRotation, Vector3 targetDirection, float maxDegreesDelta)
    {
      Quaternion targetRotation = Quaternion.LookRotation(targetDirection);
      return Quaternion.RotateTowards(currentRotation, targetRotation, maxDegreesDelta * Time.deltaTime);
    }
    
  }
}