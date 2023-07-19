using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnPoint : MonoBehaviour
{
	Vector3 mousepos;
	public Transform target;
	public Transform player;
	Vector3 objectpos;
	float angle;
	public float pivotOffset = -0.135f;

	void Update()
	{
		transform.position = new Vector3(player.transform.position.x, player.transform.position.y + pivotOffset, 0);
		mousepos = new Vector3(Input.mousePosition.x, Input.mousePosition.y, 0);
		objectpos = Camera.main.WorldToScreenPoint(new Vector3(target.position.x, target.position.y, 0));
		mousepos.x = mousepos.x - objectpos.x;
		mousepos.y = mousepos.y - objectpos.y;
		angle = Mathf.Atan2(mousepos.y, mousepos.x) * Mathf.Rad2Deg;
		transform.rotation = Quaternion.Euler(new Vector3(0, 0, angle));
	}
}
