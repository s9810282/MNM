using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GenericSingleton<T> where T : class, new()
{
    private static T instance = null;
    public static T Instance
    {
        get
        {
            if (instance == null)
            {
                instance = System.Activator.CreateInstance<T>();
            }
            return instance;
        }
    }
}