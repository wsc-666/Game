using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
    public float health = 100f;
    public float damgeInterval = 0.35f;
    public float hurtForce = 100f;
    public float damageAmount;

    private Animator anim;
    private SpriteRenderer healthBar;
    private float lastHurtTime;
    private Vector3 healthScale;
    private PlayerControl playerControl;
    private Rigidbody2D heroBody;

    private void Awake()
    {
        healthBar = GameObject.Find("HealthBar").GetComponent<SpriteRenderer>();
        heroBody = GetComponent<Rigidbody2D>();
        playerControl = GetComponent<PlayerControl>();
        healthScale = healthBar.transform.localScale;
        anim = GetComponent<Animator>();
    }

    public void UpDateHealthBar()
    {
        healthBar.material.color = Color.Lerp(Color.green, Color.red, 1 - health * 0.01f);
        healthBar.transform.localScale = new Vector3(healthScale.x * health * 0.01f,healthScale.y,healthScale.z);
    }

    void TakeDamage(Transform enemyTran)
    {
        playerControl.jump = false;
        Vector3 hurtVector3 = transform.position - enemyTran.position + Vector3.up * 5f;
        heroBody.AddForce(hurtForce * hurtVector3);
        health -= damageAmount;
        if (health < 0) health = 0;

        UpDateHealthBar();
    }

    void Death()
    {
        Collider2D[] colliers = GetComponents<Collider2D>();

        foreach (Collider2D c in colliers)
        {
            c.isTrigger = true;
        }

        SpriteRenderer[] sprites = GetComponentsInChildren<SpriteRenderer>();
        for (int i = 0; i < sprites.Length; i++)
        {
            sprites[i].sortingLayerName = "UI";
        }

        playerControl.enabled = false;
        GetComponentInChildren<Gun>().enabled = false;
        
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Enemy")
        {
            if (Time.time > lastHurtTime + damgeInterval)
            {
                if (health > 0)
                {
                    TakeDamage(collision.gameObject.transform);
                    lastHurtTime = Time.time;
                    if (health <= 0)
                    {
                        Death();
                        anim.SetTrigger("die");
                    }
                }
                else
                {
                    Death();
                    anim.SetTrigger("die");
                }
            }
        }
    }
    void Start()
    {
        
    }

 
    void Update()
    {
        
    }
}
