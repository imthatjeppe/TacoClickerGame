using Firebase.Auth;
using UnityEngine;

public class PlayerData : MonoBehaviour
{
	public static UserInfo data;
	static string userPath;

	private void Start()
	{
		FindObjectOfType<FirebaseLogin>().OnSignIn += OnSignIn;
		userPath = "users/" + FirebaseAuth.DefaultInstance.CurrentUser.UserId;
	}

	void OnSignIn()
	{
		userPath = "users/" + FirebaseAuth.DefaultInstance.CurrentUser.UserId;
		SaveManager.Instance.LoadData(userPath, OnLoadData);
	}

	void OnLoadData(string json)
	{
		if (json != null)
		{
			data = JsonUtility.FromJson<UserInfo>(json);
		}
		else
		{
			data = new UserInfo();
			SaveData();
		}

		FindObjectOfType<FirebaseLogin>()?.PlayerDataLoaded();
	}

	public static void SaveData()
	{
		SaveManager.Instance.SaveData(userPath, JsonUtility.ToJson(data));
	}
}
