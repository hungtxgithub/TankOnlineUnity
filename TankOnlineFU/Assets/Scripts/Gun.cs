using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gun : MonoBehaviour
{
	public enum GunLevel
	{
		One = 1
	}

	[SerializeField]
	private GameObject rocketPrefab;

	[SerializeField]
	private float shootSpeed = 1;

	[SerializeField]
	private bool AutoMode;

	private float timer;

	[SerializeField]
	GunLevel Level = GunLevel.One;

	private void Update()
	{
		if (AutoMode)
		{
			ShootAuto();
		}
	}

	void ShootAuto()
	{
		timer += Time.deltaTime;
		if (timer >= shootSpeed)
		{
			timer = 0;
			Fire();
		}
	}

	public void Fire()
	{
		var rocket = Instantiate(rocketPrefab, transform.position, transform.rotation);
	}
}
