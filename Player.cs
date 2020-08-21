﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    Transform tr_A;
    Transform tr_S;
    Transform tr_K;
    Transform tr_L;

    public GameObject prefabBread;
    public bool isPlayerEnter;       //개미랑 빵이 충돌했는지 확인하는 변수
    private float inputLate = 0.03f;

    public static bool start = false;


    public static bool isParent_A;
    public static bool isParent_S;
    public static bool isParent_K;
    public static bool isParent_L;



    public static bool[] breadCount = { false, false, false, false }; //a s k l


    Vector3 vec; //식빵의 로컬위치

    void Start()
    {


        tr_A = GameObject.FindGameObjectWithTag("EquipPoint_A").GetComponent<Transform>();
        tr_S = GameObject.FindGameObjectWithTag("EquipPoint_S").GetComponent<Transform>();
        tr_K = GameObject.FindGameObjectWithTag("EquipPoint_K").GetComponent<Transform>();
        tr_L = GameObject.FindGameObjectWithTag("EquipPoint_L").GetComponent<Transform>();

        //tr = GameObject.FindGameObjectWithTag("EquipPoint").GetComponent<Transform>();
        //Debug.Log(breadEquipPoint);
    }

    // Update is called once per frame
    void Update()
    {
        // Move();

        StartCoroutine(KeyDown_A());
        StartCoroutine(KeyDown_S());
        StartCoroutine(KeyDown_K());
        StartCoroutine(KeyDown_L());
    }

    /*void Move() //위아래로 움직이기
    {
        Vector3 move = new Vector3(Input.GetAxis("Vertical") * 0.5f, 0, 0);
        transform.Translate(move);
    }*/



    private IEnumerator KeyDown_A()
    {

        float y = this.inputLate;

        while (y > 0)
        {
            if (Input.GetKeyDown(KeyCode.A) && isPlayerEnter)
            {
                isParent_A = true;
                start = true;
                vec = new Vector3(tr_A.position.x + 0.8f, tr_A.position.y, tr_A.position.z - 0.05f);
                Instantiate(prefabBread, vec, Quaternion.identity); //빵생성

                breadCount[0] = true;
                
            }

            if (Input.GetKeyUp(KeyCode.A))
            {
                isParent_A = false;

                breadCount[0] = false;
            }

            y -= Time.deltaTime;
            yield return null;
        }
        yield return null;
    }

    private IEnumerator KeyDown_S()
    {

        float y = this.inputLate;

        while (y > 0)
        {
            if (Input.GetKeyDown(KeyCode.S) && isPlayerEnter)
            {
                isParent_S = true;
                start = true;
                vec = new Vector3(tr_S.position.x + 0.8f, tr_S.position.y, tr_S.position.z - 0.05f);
                Instantiate(prefabBread, vec, Quaternion.identity);

                breadCount[1] = true;

            }

            if (Input.GetKeyUp(KeyCode.S))
            {
                isParent_S = false;

                breadCount[1] = false;

            }

            y -= Time.deltaTime;
            yield return null;
        }
        yield return null;
    }
    private IEnumerator KeyDown_K()
    {


        float y = this.inputLate;

        while (y > 0)
        {
            if (Input.GetKeyDown(KeyCode.K) && isPlayerEnter)
            {
                isParent_K = true;
                start = true;
                vec = new Vector3(tr_K.position.x - 0.8f, tr_K.position.y, tr_K.position.z - 0.05f);
                Instantiate(prefabBread, vec, Quaternion.identity);

                breadCount[2] = true;

            }

            if (Input.GetKeyUp(KeyCode.K))
            {
                isParent_K = false;

                breadCount[2] = false;


            }

            y -= Time.deltaTime;
            yield return null;
        }
        yield return null;
    }
    private IEnumerator KeyDown_L()
    {


        float y = this.inputLate;

        while (y > 0)
        {
            if (Input.GetKeyDown(KeyCode.L) && isPlayerEnter)
            {
                isParent_L = true;
                start = true;
                vec = new Vector3(tr_L.position.x - 0.8f, tr_L.position.y, tr_L.position.z - 0.05f);
                Instantiate(prefabBread, vec, Quaternion.identity);

                breadCount[3] = true;

            }

            if (Input.GetKeyUp(KeyCode.L))
            {
                isParent_L = false;

                breadCount[3] = false;

            }

            y -= Time.deltaTime;
            yield return null;
        }
        yield return null;
    }


    void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Bread")
        {
            Debug.Log("개미가 빵에 닿음");
            isPlayerEnter = true;
        }

    }
    void OnTriggerExit(Collider other)
    {
        if (other.tag == "Bread")
        {
            Debug.Log("개미가 빵에서 떨어짐!");
            isPlayerEnter = false;
        }

    }
}