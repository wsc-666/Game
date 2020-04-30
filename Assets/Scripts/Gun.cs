using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gun : MonoBehaviour
{
    public Rigidbody2D rocket;
    public float speed = 20f;
    private PlayerControl playerCtrl;
    private AudioSource audio;
    private Animator anim;
    void Start()
    {
        //playerCtrl = GameObject.Find("Hero").transform.GetComponent<PlayerControl>();
        playerCtrl = transform.parent.GetComponent<PlayerControl>();
        anim = transform.root.gameObject.GetComponent<Animator>();
        audio = GetComponent<AudioSource>();
    }
    void Update()
    {
        if (Input.GetButtonDown("Fire1"))
        {
            anim.SetTrigger("shoot");
            audio.Play();
            if (playerCtrl.faceRight)
            {
                Rigidbody2D bullet = Instantiate(rocket, transform.position, Quaternion.Euler(new Vector3(0, 0, 0)));
                bullet.velocity = new Vector2(speed, 0);
            }
            else
            {
                Rigidbody2D bullet = Instantiate(rocket, transform.position, Quaternion.Euler(new Vector3(0, 0, 180)));
                bullet.velocity = new Vector2(-speed, 0);
            }
        }
    }
}
