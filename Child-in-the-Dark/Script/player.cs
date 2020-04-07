using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class player : MonoBehaviour
{
    public int playerHP = 5;
    public GameObject[] ggameObject;
    float timer;
    float timer2;
    bool GameOver = false;
    int count_GameOver = 0;
    public bool can_ache = true;
    Animator animator;
    Rigidbody2D rigi;
    public Text text;
    public Text text2;

    private void Start()
    {
        animator = GetComponent<Animator>();
        rigi = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        if (playerHP <= 0) { GameOver = true; }
        if (GameOver == true)
        {
            if (timer2 < 0.1f)
            {
                timer2 += Time.deltaTime;
            }
            else
            {
                timer2 = 0;
                count_GameOver++;
            }
        }
        if (count_GameOver == 0) { text.text = ""; }
        else if (count_GameOver == 1) { text.text = "G"; }
        else if (count_GameOver == 2) { text.text = "Ga"; }
        else if (count_GameOver == 3) { text.text = "Gam"; }
        else if (count_GameOver == 4) { text.text = "Game"; }
        else if (count_GameOver == 5) { text.text = "Game "; }
        else if (count_GameOver == 6) { text.text = "Game O"; }
        else if (count_GameOver == 7) { text.text = "Game Ov"; }
        else if (count_GameOver == 8) { text.text = "Game Ove"; }
        else if (count_GameOver >= 9) { text.text = "Game Over"; text2.text = "Press R for Restart"; text.fontSize++; }

        if (text.fontSize >= 3500) { text.fontSize = 3500; }

        if (can_ache == false)
        {
            animator.SetBool("ache", true);

            if (timer <= 1.5f)
            {
                timer += Time.deltaTime;
            }
            else
            {
                animator.SetBool("ache", false);

                can_ache = true;
                timer = 0;
            }
        }

        if (Input.GetKey(KeyCode.A))
        {
            animator.SetBool("walk", true);
            transform.Translate(-3 * Time.deltaTime, 0, 0);
        }
        else if (Input.GetKey(KeyCode.D))
        {
            animator.SetBool("walk", true);
            transform.Translate(3 * Time.deltaTime, 0, 0);
        }
        else
        {
            animator.SetBool("walk", false);
        }

        #region HP
        if (playerHP == 5)
        {
            ggameObject[0].SetActive(true);
            ggameObject[1].SetActive(true);
            ggameObject[2].SetActive(true);
            ggameObject[3].SetActive(true);
            ggameObject[4].SetActive(true);
        }
        else if (playerHP == 4)
        {
            ggameObject[0].SetActive(true);
            ggameObject[1].SetActive(true);
            ggameObject[2].SetActive(true);
            ggameObject[3].SetActive(true);
            ggameObject[4].SetActive(false);
        }
        else if (playerHP == 3)
        {
            ggameObject[0].SetActive(true);
            ggameObject[1].SetActive(true);
            ggameObject[2].SetActive(true);
            ggameObject[3].SetActive(false);
            ggameObject[4].SetActive(false);
        }
        else if(playerHP == 2)
        {
            ggameObject[0].SetActive(true);
            ggameObject[1].SetActive(true);
            ggameObject[2].SetActive(false);
            ggameObject[3].SetActive(false);
            ggameObject[4].SetActive(false);
        }
        else if(playerHP == 1)
        {
            ggameObject[0].SetActive(true);
            ggameObject[1].SetActive(false);
            ggameObject[2].SetActive(false);
            ggameObject[3].SetActive(false);
            ggameObject[4].SetActive(false);
        }
        else if (playerHP <= 0)
        {
            ggameObject[0].SetActive(false);
            ggameObject[1].SetActive(false);
            ggameObject[2].SetActive(false);
            ggameObject[3].SetActive(false);
            ggameObject[4].SetActive(false);
        }
        #endregion
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("wall"))
        {
            rigi.AddForce(new Vector2(-10 * Time.deltaTime, 0), ForceMode2D.Impulse);
        }
        if (collision.gameObject.CompareTag("wall2"))
        {
            Debug.Log("dsfsdfd");
            rigi.AddForce(new Vector2(10 * Time.deltaTime, 0), ForceMode2D.Impulse);
        }
    }
}
