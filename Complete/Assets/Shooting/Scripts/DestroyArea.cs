using UnityEngine;

[ExecuteInEditMode]
public class DestroyArea : MonoBehaviour
{
	void Start()
	{
		transform.localScale = new Vector3(Camera.main.aspect * Camera.main.orthographicSize * 2, Camera.main.orthographicSize * 2);
	}

	void OnTriggerExit2D (Collider2D c)
	{
		Destroy (c.gameObject);
	}
}