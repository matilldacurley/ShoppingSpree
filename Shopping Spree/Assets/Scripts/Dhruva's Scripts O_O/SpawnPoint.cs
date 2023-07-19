using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnPoint : MonoBehaviour
{
	Vector3 mousepos;
	public Transform target;
	Vector3 object_pos;
	float angle;

	void Update()
	{
		mousepos = Input.mousePosition;
		mousepos.z = 5.23f; //The distance between the camera and object
		object_pos = Camera.main.WorldToScreenPoint(target.position);
		mousepos.x = mousepos.x - object_pos.x;
		mousepos.y = mousepos.y - object_pos.y;
		angle = Mathf.Atan2(mousepos.y, mousepos.x) * Mathf.Rad2Deg;
		transform.rotation = Quaternion.Euler(new Vector3(0, 0, angle));
	}
}
