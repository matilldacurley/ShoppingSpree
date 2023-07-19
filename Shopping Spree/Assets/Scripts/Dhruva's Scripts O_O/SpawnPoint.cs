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
	public float distNeeded = 0.75f;
	public float offset = .1f;

	void Update()
	{
		transform.position = new Vector3(player.transform.position.x, player.transform.position.y + pivotOffset, 0);
		mousepos = new Vector3(Input.mousePosition.x, Input.mousePosition.y, 0);
		objectpos = Camera.main.WorldToScreenPoint(new Vector3(target.position.x, target.position.y, 0));
		Vector2 n = Camera.main.ScreenToWorldPoint(mousepos);
		float dist = Vector3.Distance(n, player.transform.position);
		if (dist <= distNeeded)
		{
			transform.rotation = Quaternion.Euler(0,0,360 - Mathf.Abs(transform.rotation.z));
			Vector2 dir = (n - new Vector2(transform.position.x, transform.position.y)).normalized;
			//transform.position = new Vector3(player.transform.position.x, player.transform.position.y + pivotOffset, 0);
			target.localPosition = dir * offset;
		}
        else
        {
			mousepos.x = mousepos.x - objectpos.x;
			mousepos.y = mousepos.y - objectpos.y;
			angle = Mathf.Atan2(mousepos.y, mousepos.x) * Mathf.Rad2Deg;
			transform.rotation = Quaternion.Euler(new Vector3(0, 0, angle));
		}
	}
}
