using UnityEngine;
using System.Collections;

public class Manager : MonoBehaviour
{
	// Playerプレハブ
	public GameObject player;
	
	// タイトル
	private GameObject title;

	// プレイ中かどうか
	public bool IsPlaying {
		get;
		private set;
	}

	IEnumerator Start ()
	{
		// Titleゲームオブジェクトを検索し取得する
		title = GameObject.Find ("Title");

		while (true) {
			//タイトルを表示し、xキーが押されるまで待機する
			title.SetActive (true);
			while (Input.GetKeyDown (KeyCode.X) == false) {
				yield return null;
			}

			// ゲームスタート時に、タイトルを非表示にしてプレイヤーを作成する
			title.SetActive (false);
			IsPlaying = true;
			Instantiate (player, player.transform.position, player.transform.rotation);

			// ゲームオーバーになるまで待機する
			while (IsPlaying == true) {
				yield return null;
			}

			// ゲームオーバー時データを保存する
			FindObjectOfType<Score> ().Save ();
		}
	}

	public static void GameOver ()
	{
		Manager manager = FindObjectOfType<Manager>();
		if( manager != null ){
			manager.IsPlaying = false;
		}
	}
}