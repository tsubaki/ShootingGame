using UnityEngine;

public class Background : MonoBehaviour
{
	// スクロールするスピード
	public float speed = 0.1f;

	void Update ()
	{
		// 時間によってYの値が0から1に変化していく。1になったら0に戻り、繰り返す。
		float y = Mathf.Repeat (Time.time * speed, 1);
		// マテリアルにオフセットを設定する
		Rect uvRect = GetComponent<UnityEngine.UI.RawImage> ().uvRect;
		uvRect.y = y;
		GetComponent<UnityEngine.UI.RawImage>().uvRect = uvRect;
	}
}