
using NUnit.Framework;
using System.Collections.Generic;
using UnityEngine;

public class PersistentData
{

    public static bool SeenCode = false;
    public static Vector3[] broombaLocations;
    public static string lastbroomba = null;
    public static void Reset()
    {
        SeenCode = false;
        broombaLocations = null;
        lastbroomba = null;
    }

}