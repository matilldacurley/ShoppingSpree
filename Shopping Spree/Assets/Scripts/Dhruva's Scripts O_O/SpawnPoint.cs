using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnPoint : MonoBehaviour
{
	Vector3 mousepos;
	public Transform target;
	public Transform player;
	Vector3 object_pos;
	float angle;
	public float pivotOffset = -0.135f;

	void Update()
	{
		transform.position = new Vector3(player.transform.position.x, player.transform.position.y + pivotOffset, 0);
		mousepos = new Vector3(Input.mousePosition.x, Input.mousePosition.y, 0);
		object_pos = Camera.main.WorldToScreenPoint(new Vector3(target.position.x, target.position.y, 0));
		mousepos.x = mousepos.x - object_pos.x;
		mousepos.y = mousepos.y - object_pos.y;
		angle = Mathf.Atan2(mousepos.y, mousepos.x) * Mathf.Rad2Deg;
		transform.rotation = Quaternion.Euler(new Vector3(0, 0, angle));
	}
}
