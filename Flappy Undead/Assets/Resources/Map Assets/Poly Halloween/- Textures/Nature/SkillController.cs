using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SkillController : MonoBehaviour
{
    public Player_Data data;

    public float Cooltime = 5f;
    public float LastSkillTime = 0f;

    public Collider player_col;
    public Renderer player_rend;
    public Animator player_ani;
    public AudioSource player_au;

    public AudioClip giantClip;
    public AudioClip smallClip;

    private void Awake()
    {
        player_col = GetComponent<Collider>();
        player_rend = GetComponentInChildren<Renderer>();
        player_ani = GetComponent<Animator>();
        player_au = GetComponent<AudioSource>();

        Cooltime = data.CoolTime;

        LastSkillTime = 0f;
    }
    private void Update()
    { 
        if (Input.GetKeyDown(KeyCode.Space))
        {
            if (Time.time >= LastSkillTime + Cooltime)
            {
                LastSkillTime = Time.time;
                Use_Skill();
            }
        }
    }
    public void Use_Skill()
    {
        switch (data.Type)
        {
            case Player_Data.CharType.Normal:
                StartCoroutine(Invisible_co());
                break;
            case Player_Data.CharType.Witch:
                StartCoroutine(Giant_co());
                break;
        }
    }
    public IEnumerator Invisible_co()
    {
        player_col.enabled = false;
        player_rend.material.color = new Color(255 / 255f, 255 / 255f, 255 / 255f, 0.3f);
        yield return new WaitForSeconds(3.0f);
        player_col.enabled = true;
        player_rend.material.color = new Color(255 / 255f, 255 / 255f, 255 / 255f, 1f);
    }
    public IEnumerator Giant_co()
    {
        player_ani.SetTrigger("Giant");
        transform.tag = "Super";
        player_au.PlayOneShot(giantClip);
        yield return new WaitForSeconds(3.0f);
        player_ani.SetTrigger("Small");
        player_au.PlayOneShot(smallClip);
        yield return new WaitForSeconds(1.0f);
        transform.tag = "Player";
    }
}
