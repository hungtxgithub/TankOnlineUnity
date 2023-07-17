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
    GameObject rocketPrefab;

    [SerializeField]
    float shootSpeed = 1;

    [SerializeField]
    GunLevel Level = GunLevel.One;

	private void Start()
	{
	    	
	}

    public void Fire()
    {
        var rocket = Instantiate(rocketPrefab, transform.position, transform.rotation);
    }
}
