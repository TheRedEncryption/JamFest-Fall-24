using UnityEngine;

public static class Utils
{
    public static Vector3 XZVec(this Vector3 v)
    {
        return new Vector3(v.x, 0, v.z);
    } 

    public static float XZDist(Vector3 v1, Vector3 v2)
    {
        return Vector3.Distance(XZVec(v1), XZVec(v2));
    }
    public static Color WithAlpha(this Color c, float alpha)
    {
        c.a = alpha;
        return c;

    }
}