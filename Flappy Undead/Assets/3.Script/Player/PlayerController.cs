using UnityEngine;
using System.Collections;
using System.Collections.Generic;
public class PlayerController : MonoBehaviour
{
    public Player_Data data;
    public float Speed = 5f;
    public int Health = 2;
    public float Cooltime = 5f;

    public float LastSkillTime = 0f;

    public Rigidbody player_rid;
    public Collider player_col;
    public Renderer player_rend;
    public Animator player_ani;

    private void Awake()
    {
        player_rid = GetComponent<Rigidbody>();
        player_col = GetComponent<Collider>();
        player_rend = GetComponentInChildren<Renderer>();
        player_ani = GetComponent<Animator>();

        Speed = data.Speed;
        Health = data.Health;
        Cooltime = data.CoolTime;

        LastSkillTime = 0f;
    }
    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Jump();
        }
        if (Input.GetKeyDown(KeyCode.Space))
        {
            if (Time.time >= LastSkillTime + Cooltime)
            {
                LastSkillTime = Time.time;
                Use_Skill();
            }
        }
    }
    public void Jump()
    {
        player_rid.velocity = Vector3.up * Speed;
    }
    public void Hit()
    {
        Health--;
        if(Health <= 0)
        {
            Dead();
        }
    }
    public void Dead()
    {

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
        player_rend.material.color = new Color(255/255f, 255/255f, 255/255f, 0.3f);
        yield return new WaitForSeconds(3.0f);
        player_col.enabled = true;
        player_rend.material.color = new Color(255/255f, 255/255f, 255/255f, 1f);
    }
    public IEnumerator Giant_co()
    {
        player_ani.SetTrigger("Giant");
        transform.tag = "Super";
        yield return new WaitForSeconds(3.0f);
        player_ani.SetTrigger("Small");
        yield return new WaitForSeconds(1.0f);
        transform.tag = "Player";
    }
}