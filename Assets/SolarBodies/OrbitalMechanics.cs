using Unity.Mathematics;
using Unity.VisualScripting;
using UnityEngine;

namespace SolarBodies
{
    public class OrbitalMechanics
    {
        public static Vector3 CaculateNewPos(GameObject orbiter, GameObject orbiting, float angle, float distance)
        {
            // float distance = (orbiter.transform.position - orbiting.transform.position).magnitude;

            angle *= 1/distance;
            
            Vector3 relativeSpawnPositionToObject = new Vector3(
                Mathf.Cos(angle) * distance,
                Mathf.Sin(angle) * distance,
                0
            );

            return orbiting.transform.position + relativeSpawnPositionToObject;
        }
    }
}