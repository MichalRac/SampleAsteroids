using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DataSetupManager : MonoBehaviour
{

    public static DataSetupManager Instance { get; private set; }
    public GameInitData InitData;
    public SpawnerSettings spawnerSettings;

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
        else
        {
            Debug.LogError("Destroying illegal instance of DataSetup singleton");
            Destroy(gameObject);
        }
    }


}
