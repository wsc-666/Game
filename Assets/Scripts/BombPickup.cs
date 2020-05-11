using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BombPickup : MonoBehaviour
{
	private Animator anim;              // Reference to the animator component.
	private bool landed = false;        // Whether or not the crate has landed yet.

	void Awake()
	{
		anim = transform.root.GetComponent<Animator>();
	}


	void OnTriggerEnter2D(Collider2D other)
	{
		// 炸弹还在半空被接住
		if (other.tag == "Player")
		{
			// 销毁炮弹
			Destroy(transform.root.gameObject);
		}
		// 掉地上
		else if (other.tag == "ground" && !landed)
		{
			anim.SetTrigger("Land");
			transform.parent = null;
			gameObject.AddComponent<Rigidbody2D>();
			landed = true;
		}
	}
	// Start is called before the first frame update
	void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
