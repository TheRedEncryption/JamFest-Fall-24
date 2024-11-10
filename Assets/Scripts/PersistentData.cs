
using NUnit.Framework;
using System.Collections.Generic;
using UnityEngine;

public class PersistentData
{

    public static bool SeenCode = false;
    public static List<Vector3> broombaLocations;

    public static void Reset()
    {
        SeenCode = false;
        broombaLocations = new List<Vector3>();
    }

}