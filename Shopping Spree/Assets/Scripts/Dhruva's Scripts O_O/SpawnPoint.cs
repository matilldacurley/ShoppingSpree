using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnPoint : MonoBehaviour
{
	Vector3 mousepos;
	public Transform target;
	public Transform player;
	public float pivotOffset = -0.135f;
	public float offset = .1f;

	void Update()
	{
		transform.position = new Vector3(player.transform.position.x, player.transform.position.y + pivotOffset, 0);
		mousepos = new Vector3(Input.mousePosition.x, Input.mousePosition.y, 0);
		Vector2 n = Camera.main.ScreenToWorldPoint(mousepos);
		transform.rotation = Quaternion.Euler(0,0,360 - Mathf.Abs(transform.rotation.z));
		Vector2 dir = (n - new Vector2(transform.position.x, transform.position.y)).normalized;
		//transform.position = new Vector3(player.transform.position.x, player.transform.position.y + pivotOffset, 0);
		target.localPosition = dir * offset;
	}
}
