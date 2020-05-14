using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthPickup : MonoBehaviour
{
	public float healthBonus;               // How much health the crate gives the player.
	private PickupSpawner pickupSpawner;    // Reference to the pickup spawner.
	private Animator anim;                  // Reference to the animator component.
	private bool landed = false;                    // Whether or not the crate has landed.


	void Awake()
	{
		anim = transform.root.GetComponent<Animator>();
		pickupSpawner = GameObject.Find("pickupManager").GetComponent<PickupSpawner>();
		Debug.Log(GameObject.Find("pickupManager"));
	}


	void OnTriggerEnter2D(Collider2D other)
	{
		// 半空中被接着
		if (other.tag == "Player")
		{
			PlayerHealth playerHealth = other.GetComponent<PlayerHealth>();

			// 加血
			playerHealth.health += healthBonus;
			if (playerHealth.health > 100)
				playerHealth.health = 100;

			// 更新血条.
			playerHealth.UpDateHealthBar();

			// 开启新协程
			pickupSpawner.StartCoroutine(pickupSpawner.DeliverPickup());

			// 销毁医疗包
			Destroy(transform.root.gameObject);
		}
		// 落在地面
		else if (other.tag == "ground" && !landed)
		{
			anim.SetTrigger("Land");

			transform.parent = null;
			gameObject.AddComponent<Rigidbody2D>();
			landed = true;
		}
	}
}
