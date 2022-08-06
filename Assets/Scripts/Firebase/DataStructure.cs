using System;
using System.Collections.Generic;
using UnityEngine;

[Serializable]

public class DataStructureStyle
{
	public string userName;
	public float passiveIncome, score, clickMultiplier;
}

[Serializable]
public class DataStructure : MonoBehaviour//UserData
{
    public string userName;
    public float passiveIncome, score, clickMultiplier;

    private static DataStructure _instance;
	
	public static DataStructure Instance {get { return _instance; } }

    private void Start()
    {
        if(_instance == null)
        {
			_instance = this;
			DontDestroyOnLoad(gameObject);
        } else {
            Destroy(this.gameObject);
        }

    }
}
