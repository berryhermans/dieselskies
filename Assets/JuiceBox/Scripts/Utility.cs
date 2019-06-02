using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace JuiceBox
{
    public static class Utility
    {
        /// <summary>
        /// Converts a direction to a rotation degree in Unity.
        /// </summary>
        /// <remarks>
        /// 0 degrees in math is at (1,0) and a positive increment is counterclockwise.
        /// 0 degrees in unity is at (0,1) and a positive increment is clockwise.
        /// </remarks>
        /// <param name="direction">a vector2 that represents a direction</param>
        /// <returns>a rotation in unity degrees</returns>
        public static float Vector2ToUnityDegrees(Vector2 direction)
        {
            #region Breakdown
            // // flip the y so positive increments have the same direction
            // Vector2 flippedDirection = new Vector2(direction.x, -direction.y);

            // // convert the vector to radians
            // float radians = Mathf.Atan2(flippedDirection.y, flippedDirection.x);

            // // convert the radians to degrees;
            // float degrees = radians * (180 / Mathf.PI);

            // // add 90 degrees to correct the origin offset
            // degrees += 90;
            // return degrees;
            #endregion

            #region Optimised
            return Mathf.Atan2(-direction.y, direction.x) * (180 / Mathf.PI) + 90;
            #endregion
        }
    }
}
