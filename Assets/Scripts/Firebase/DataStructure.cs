using System;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
public class UserInfo
{
	public string name;
	public float ColorHUE;
	public bool Hidden;
	public Vector3 Position;
	public List<string> activeGames;
}

[Serializable]
public class GameInfo
{
	public string displayName;
	public string gameID;
	public int seed;
	public List<UserInfo> players;
}