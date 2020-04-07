using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomEnviro : MonoBehaviour
{
    float positionEnviro;
    public GameObject[] GameObject;

    // Start is called before the first frame update
    void Start()
    {
        for (int i = 0; i < 60; i++) {
            int a = Random.Range(0, 5);
            positionEnviro = Random.Range(-45f, 45f);
            Instantiate(GameObject[a],new Vector3(positionEnviro,-2f,0f),Quaternion.identity);
        }
    }
}
