using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    public float speed_enemy = 1.5f;
    public bool vertical_enemy = false;
    public float changeTime_direction = 3.0f;
    public float changeTime_vertical = 1.0f;

    Rigidbody2D rb2d;
    float timer_direction;
    float timer_vertical;
    int direction = 1;

    Animator ANI;

    bool broken = true;

    public ParticleSystem SE;

    public int Health_enemy = 10;

    public AudioClip HitClip;

    AudioSource AS;

    void Start()
    {
        rb2d = GetComponent<Rigidbody2D>();
        QualitySettings.vSyncCount = 0;
        Application.targetFrameRate = 60;

        timer_direction = changeTime_direction;
        timer_vertical = changeTime_vertical;

        ANI = GetComponent<Animator>();

        AS = GetComponent<AudioSource>();
    }

    void Update()
    {
        if (!broken)
        {
            return;
        }

        timer_direction -= Time.deltaTime;
        timer_vertical -= Time.deltaTime;

        if (timer_direction < 0)
        {
            direction = -direction;

            changeTime_direction = Random.Range(0f,4f);

            timer_direction = changeTime_direction;
        }
        if (timer_vertical < 0)
        {
            if (vertical_enemy == false)
            {
                vertical_enemy = true;
            }
            else
            {
                vertical_enemy = false;
            }
            changeTime_vertical = Random.Range(0f,4f);

            timer_vertical = changeTime_vertical;
        }
    }

    void FixedUpdate()
    {
        if (!broken)
        {
            return;
        }

        Vector2 pos = rb2d.position;

        if (vertical_enemy)
        {
            pos.y = pos.y + speed_enemy * Time.deltaTime * direction;
            ANI.SetFloat("Move X", 0);
            ANI.SetFloat("Move Y", direction);
        }
        else
        {
            pos.x = pos.x + speed_enemy * Time.deltaTime * direction;
            ANI.SetFloat("Move X", direction);
            ANI.SetFloat("Move Y", 0);
        }

        rb2d.MovePosition(pos);
    }

    void OnCollisionEnter2D(Collision2D other)
    {
        RubyController player = other.gameObject.GetComponent<RubyController>();

        if (player != null)
        {
            player.ChangeHealth(-1);
        }
    }

    public void Fix()
    {
        Health_enemy -= 1;
        AS.PlayOneShot(HitClip);
        if (Health_enemy < 0)
        {
            broken = false;
            rb2d.simulated = false;
            ANI.SetTrigger("Fixed");

            SE.Stop();

            AS.enabled = false;
            // 修理完成后停止发出行走的声音。
        }
    }
}