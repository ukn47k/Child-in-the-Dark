using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class randombot : MonoBehaviour
{
    public GameObject[] bot;// = new GameObject bot[];
    public float timer;
    public float timer2;
    public Transform ttransform;

    private void Start()
    {
        ttransform = GameObject.Find("Player").GetComponent<Transform>();
    }

    void Update()
    {
        float a = Random.Range(-15, 15);
        float b = Random.Range(-9, 9);

        if (a < -9.5) { b = -9.5f; }
        if (a > 9.5) { b = 9.5f; }
        if (b < 6) { b = 6; }

        if (timer < 3)
        {
            timer += Time.deltaTime;
        }
        else
        {
            Instantiate(bot[0], new Vector3(ttransform.position.x + a, ttransform.position.y + b, 0), Quaternion.identity);
            timer = 0;
        }

        if (timer2 < 1f)
        {
            timer2 += Time.deltaTime;
        }
            else
        {
            Instantiate(bot[0], new Vector3(ttransform.position.x + a, ttransform.position.y + b, 0), Quaternion.identity);
            timer2 = 0;
        }
    }
}
