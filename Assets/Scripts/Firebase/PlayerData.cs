using Firebase.Auth;
using UnityEngine;

public class PlayerData : MonoBehaviour
{
	public static DataStructure data;
	static string userPath;

	public clickerScript score;

	private void Start()
	{
		FindObjectOfType<FirebaseLogin>().OnSignIn += OnSignIn;
		userPath = "users/" + FirebaseAuth.DefaultInstance.CurrentUser.UserId;
	}

	void OnSignIn()
	{
		Debug.Log("In OnSignIn");
		userPath = "users/" + FirebaseAuth.DefaultInstance.CurrentUser.UserId;

		Debug.Log("onsignin 2");
		SaveManager.Instance.LoadData(userPath, OnLoadData);
	}

	void OnLoadData(string json)
	{
		
		if (json != null)
		{
			Debug.Log("Hej Hej");
			data = JsonUtility.FromJson<DataStructure>(json);

			Debug.Log(data.score);
			data.score = score.score;
		}
		else
		{
			data = new DataStructure();
			InvokeRepeating(nameof(SaveData), 0, 15);
			data.score = 100;
		}
		Debug.Log("OnLoadData before playerdataloaded");
		FindObjectOfType<FirebaseLogin>()?.PlayerDataLoaded();
	}

	public static void SaveData()
	{
		SaveManager.Instance.SaveData(userPath, JsonUtility.ToJson(data));
	}
}
