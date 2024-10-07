using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using UnityEngine.SceneManagement;

public class RubyController : MonoBehaviour
{
    public float speed = 3.0f;
    public int maxHealth = 5;
    
    int currentHealth;
    public int health { get { return currentHealth; } }

    Rigidbody2D rb2d;
    float horizontal;
    float vertical;

    public float timeInvincible = 2.0f;
    bool isInvincible;
    float invincibleTimer;

    Animator ANI;
    Vector2 lookDirection = new Vector2(1, 0);

    public GameObject projectilePrefab;

    AudioSource AS;
    // 用于存储当前游戏对象的音频源组件对象。

    void Start()
    {
        rb2d = GetComponent<Rigidbody2D>();
        QualitySettings.vSyncCount = 0;
        Application.targetFrameRate = 60;

        currentHealth = maxHealth;

        ANI = GetComponent<Animator>();

        AS = GetComponent<AudioSource>();
        // 获得当前游戏对象的音频源组件对象。
    }

    void Update()
    {
        horizontal = Input.GetAxis("Horizontal");
        vertical = Input.GetAxis("Vertical");

        if (isInvincible)
        {
            invincibleTimer -= Time.deltaTime;
            if (invincibleTimer < 0) isInvincible = false;
        }

        Vector2 Move = new Vector2(horizontal, vertical);

        if (!Mathf.Approximately(Move.x, 0.0f) || !Mathf.Approximately(Move.y, 0.0f))
        {
            lookDirection.Set(Move.x, Move.y);
            lookDirection.Normalize();

            ANI.SetFloat("Look X", lookDirection.x);
            ANI.SetFloat("Look Y", lookDirection.y);
            ANI.SetFloat("Speed", Move.magnitude);
        }

        if (Input.GetKeyDown(KeyCode.C))
        {
            Launch();
        }

        if (Input.GetKeyDown(KeyCode.X))
        {
            RaycastHit2D hit = Physics2D.Raycast(rb2d.position + Vector2.down * 0.2f, lookDirection, 1.5f, LayerMask.GetMask("NPC"));
            if (hit.collider != null)
            {
                NonPlayerCharacter character = hit.collider.GetComponent<NonPlayerCharacter>();
                if (character != null)
                {
                    character.DisplayDialog();
                }
                NPC_End end = hit.collider.GetComponent<NPC_End>();
                if(end != null)
                {
                    Application.Quit();
                    // 退出游戏。
                }
            }
        }
    }
    void FixedUpdate()
    {
        Vector2 pos = rb2d.position;
        pos.x = pos.x + speed * horizontal * Time.deltaTime;
        pos.y = pos.y + speed * vertical * Time.deltaTime;

        rb2d.MovePosition(pos);
    }
    public void ChangeHealth(int amount)
    {
        if (amount < 0)
        {
            if (isInvincible) return;
            isInvincible = true;
            invincibleTimer = timeInvincible;
        }
        currentHealth = Mathf.Clamp(currentHealth + amount, 0, maxHealth);
        if(currentHealth <= 0)
        {
            SceneManager.LoadScene("SampleScene");
            // 生命值归0，直接重新开始场景。
        }
        UIHealthBar.instance.SetValue(currentHealth / (float)maxHealth);
    }
    void Launch()
    {
        GameObject projectileObject = Instantiate(projectilePrefab, rb2d.position + Vector2.up * 0f, Quaternion.identity);

        Projectile Pro = projectileObject.GetComponent<Projectile>();
        Pro.Launch(lookDirection, 300);

        ANI.SetTrigger("Launch");
    }

    public void PlaySound(AudioClip clip)
    {
        AS.PlayOneShot(clip);
        // PlayOneShot函数将音频剪辑作为第一个参数，并在音频源的位置使用音频源的所有设置播放一次该音频剪辑。
    }
}