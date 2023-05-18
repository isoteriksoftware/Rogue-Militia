using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GlobalManagers : MonoBehaviour
{
    public static GlobalManagers Instance { get; private set; }

    [SerializeField] GameObject parent;
    [field: SerializeField] public NetworkRunnerController NetworkRunnerController { get; private set; }

    void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
        else
        {
            Destroy(parent);
        }
    }
}
