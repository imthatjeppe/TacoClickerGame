using System;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
public class DataStructure
{
	public string name;
	public float passiveIncome;
	public float itemCost;
	public float score;
	public float clickMultiplier;
}

[Serializable]
public class GameInfo
{
	public string displayName;
	public string gameID;
	public int seed;
	public List<DataStructure> players;
}