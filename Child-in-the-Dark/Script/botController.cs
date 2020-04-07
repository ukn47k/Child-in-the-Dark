using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class botController : MonoBehaviour
{
    Transform target;
    float speed;
    Rigidbody2D rigi;
    private float distance;
    bool can_go = true;
    float opacity = 1;
    public float timer;
    player player;

    SpriteRenderer spriteRenderer;

    private void Start()
    {
        rigi = GetComponent<Rigidbody2D>();
        target = GameObject.Find("Player").GetComponent<Transform>();
        spriteRenderer = GetComponent<SpriteRenderer>();
        speed = Random.Range(0.005f, 0.015f);
        player = GameObject.Find("Player").GetComponent<player>();
    }

    private void Update()
    {
        distance = Vector2.Distance(transform.position, target.position);

        //Color color = new Color(0,0,0,opacity);

        spriteRenderer.color = new Color(0,0,0,opacity);

        if (can_go == true)
        {
            transform.position = Vector2.Lerp(transform.position, target.position, speed / distance);
        }
        else if(can_go == false)
        {
            transform.position = Vector2.Lerp(transform.position, target.position, speed * 0.5f / distance);
            if (timer <= 0.05f)
            {
                timer += Time.deltaTime;
            }
            else
            {
                opacity -= 0.075f;
                timer = 0;
            }
        }

        if (opacity == 0) {
            Destroy(gameObject);
        }
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("light"))
        {
            can_go = false;
        }
        if (collision.gameObject.CompareTag("Player"))
        {
            if (player.can_ache == true)
            {
                player.playerHP -= 1;
                player.can_ache = false;
            }
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("light"))
        {
            can_go = true;
        }
    }
}
