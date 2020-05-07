using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rocket : MonoBehaviour
{
    public GameObject explosion;
    private Enemy enemys;
    //private AudioSource audio;
    void Start()
    {
        Destroy(gameObject, 2);
        //enemys = GameObject.Find("Enemy1").GetComponent<Enemy>();
        //audio = GetComponent<AudioSource>();
    }

    void OnExplode()
    {
       // audio.Play();
        Quaternion randRotation = Quaternion.Euler(0, 0, Random.Range(0f, 360f));
        Instantiate(explosion, transform.position, randRotation);
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag != "Player")
        {
            OnExplode();                //实例化爆炸效果
            Destroy(gameObject);        //销毁炮弹
        }

        if (collision.tag == "Enemy")
        {
            enemys = collision.GetComponent<Enemy>();
            if (enemys != null)
            {
                enemys.Hurt();
            }
        }

        
    }



    // Update is called once per frame
    void Update()
    {
        
    }
}
