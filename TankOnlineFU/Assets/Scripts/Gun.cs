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
    bool AutoMode;

    private float timer;

    [SerializeField]
    GunLevel Level = GunLevel.One;

	private void Start()
	{
	    	
	}

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
        if (timer >= 1.5f)
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
