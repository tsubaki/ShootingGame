using UnityEngine;
using UnityEngine.UI;

public class Score : MonoBehaviour
{
	// スコアを表示するGUIText
	public Text scoreLabel;
	
	// ハイスコアを表示するGUIText
	public Text highScoreLabel;
	
	// スコア
	private int score;
	
	// ハイスコア
	private int highScore;
	
	// PlayerPrefsで保存するためのキー
	private string highScoreKey = "highScore";

	void Start ()
	{
		Initialize ();
	}

	void UpdateScore ()
	{
		// スコアがハイスコアより大きければ
		if (highScore < score) {
			highScore = score;
		}
		
		// スコア・ハイスコアを表示する
		scoreLabel.text = score.ToString ("000000");
		highScoreLabel.text = "HighScore : " + highScore.ToString ("000000");
	}
	
	// ゲーム開始前の状態に戻す
	private void Initialize ()
	{
		// スコアを0に戻す
		score = 0;
		
		// ハイスコアを取得する。保存されてなければ0を取得する。
		highScore = PlayerPrefs.GetInt (highScoreKey, 0);

		UpdateScore ();
	}
	
	// ポイントの追加
	public static void AddPoint (int point)
	{
		Score instance = FindObjectOfType<Score>();
		if( instance != null ){
			instance.score = instance.score + point;
			instance.UpdateScore ();
		}
	}
	
	// ハイスコアの保存
	public void Save ()
	{
		// ハイスコアを保存する
		PlayerPrefs.SetInt (highScoreKey, highScore);
		PlayerPrefs.Save ();
		
		// ゲーム開始前の状態に戻す
		Initialize ();
	}
}