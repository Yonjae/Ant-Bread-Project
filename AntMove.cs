using UnityEngine;
using System.Collections;
using System.Collections.Generic;


public class AntMove : MonoBehaviour
{

   
    
    private Coroutine inputForwardRout;
    private float inputLate = 0.03f;


    public int[,] btn = new int[6, 2];
    public int pre_move = 0;


    [Header("Speed")]
    public float speedMovement = 0.5f;
    public float speedRotation = 30f;
    public float speedAnimation = 3f;


    [Header("Inverse Kinematics")]
    public bool isIKEnabled = true;
    public float IKFactor = 20f;
    float IKAngle = 0f;

    float verticalAxis;
    float horizontalAxis;
    float rotationalAxis;

    /// <summary>
    /// trigger catch
    /// </summary>
    public int chk = 0;
    void OnTriggerEnter(Collider col)
    {
        if (col.tag == "Bread")
        {
            chk = 1;
        }
    }

    void OnTriggerStay(Collider col)
    {
        if (col.tag == "Bread")
        {
            chk = 1;
        }
    }

    void OnTriggerExit(Collider col)
    {
        if (col.tag == "Bread")
        {
            chk = 0;
        }
    }

    /// <summary>
    /// trigger catch
    /// </summary>

    void Awake()
    {

    }


    void Update()
    {
       
        StartCoroutine(this.BtnState());

        StartCoroutine(this.Forward());
        StartCoroutine(this.FallDown());
        AxesUpdate();


    }

    void AxesUpdate()
    {
        // verticalAxis = Input.GetAxis("Horizontal");
        // horizontalAxis = Input.GetAxis("Vertical");

        if (Input.GetKey(KeyCode.Q))
        {
            rotationalAxis = -1f;
        }
        else if (Input.GetKey(KeyCode.E))
        {
            rotationalAxis = 1f;
        }
        else
        {
            rotationalAxis = 0f;
        }

        transform.position += (transform.forward * verticalAxis + transform.right * horizontalAxis) * Time.deltaTime * speedMovement;
        transform.rotation *= Quaternion.Euler(Vector3.up * rotationalAxis * Time.deltaTime * speedRotation);
        Debug.Log(transform.eulerAngles);
    }




    private IEnumerator BtnState()
    {

        float t = this.inputLate;

        while (t > 0)
        {

            if (Input.GetKeyDown(KeyCode.A))
            {
                btn[0, 0] = 1;
                string array = "";
                for (int i = 0; i < 6; i++)
                {
                    array += btn[i, 0].ToString();
                }
                Debug.Log(array);
            }


            if (Input.GetKeyDown(KeyCode.S))
            {
                btn[1, 0] = 1;
                string array = "";
                for (int i = 0; i < 6; i++)
                {
                    array += btn[i, 0].ToString();
                }
                Debug.Log(array);
            }


            if (Input.GetKeyDown(KeyCode.D))
            {
                btn[2, 0] = 1;
                string array = "";
                for (int i = 0; i < 6; i++)
                {
                    array += btn[i, 0].ToString();
                }
                Debug.Log(array);
            }



            if (Input.GetKeyDown(KeyCode.J))
            {
                btn[3, 0] = 1;
                string array = "";
                for (int i = 0; i < 6; i++)
                {
                    array += btn[i, 0].ToString();
                }
                Debug.Log(array);
            }



            if (Input.GetKeyDown(KeyCode.K))
            {
                btn[4, 0] = 1;
                string array = "";
                for (int i = 0; i < 6; i++)
                {
                    array += btn[i, 0].ToString();
                }
                Debug.Log(array);
            }

            if (Input.GetKeyDown(KeyCode.L))
            {
                btn[5, 0] = 1;
                string array = "";
                for (int i = 0; i < 6; i++)
                {
                    array += btn[i, 0].ToString();
                }
                Debug.Log(array);
            }

            t -= Time.deltaTime;
            yield return null;
        }



        float p = this.inputLate;

        while (p > 0)
        {


            if (Input.GetKeyUp(KeyCode.A))
            {
                btn[0, 0] = 0;
                string array = "";
                for (int i = 0; i < 6; i++)
                {
                    array += btn[i, 0].ToString();
                }
                Debug.Log(array);

            }

            if (Input.GetKeyUp(KeyCode.S))
            {
                btn[1, 0] = 0;
                string array = "";
                for (int i = 0; i < 6; i++)
                {
                    array += btn[i, 0].ToString();
                }
                Debug.Log(array);
            }

            if (Input.GetKeyUp(KeyCode.D))
            {
                btn[2, 0] = 0;
                string array = "";
                for (int i = 0; i < 6; i++)
                {
                    array += btn[i, 0].ToString();
                }
                Debug.Log(array);
            }

            if (Input.GetKeyUp(KeyCode.J))
            {
                btn[3, 0] = 0;
                string array = "";
                for (int i = 0; i < 6; i++)
                {
                    array += btn[i, 0].ToString();
                }
                Debug.Log(array);
            }

            if (Input.GetKeyUp(KeyCode.K))
            {
                btn[4, 0] = 0;
                string array = "";
                for (int i = 0; i < 6; i++)
                {
                    array += btn[i, 0].ToString();
                }
                Debug.Log(array);
            }

            if (Input.GetKeyUp(KeyCode.L))
            {
                btn[5, 0] = 0;
                string array = "";
                for (int i = 0; i < 6; i++)
                {
                    array += btn[i, 0].ToString();
                }
                Debug.Log(array);
            }

            p -= Time.deltaTime;
            yield return null;

        }


        yield return null;

    }


    private IEnumerator Forward()
    {
        while (true)
        {
            if (btn[2, 0] == 1 && btn[3, 0] == 1)
            {
                if (btn[0, 0] == 1 && btn[0, 1] == 0)
                {
                    if (Input.GetKeyUp(KeyCode.D) || Input.GetKeyUp(KeyCode.J))
                    {
                        btn[0, 1] = 1;
                        Debug.Log("A: " + btn[0, 1]);
                    }
                }
                if (btn[1, 0] == 1 && btn[1, 1] == 0)
                {
                    if (Input.GetKeyUp(KeyCode.D) || Input.GetKeyUp(KeyCode.J))
                    {
                        btn[1, 1] = 1;
                        Debug.Log("S: " + btn[1, 1]);
                    }
                }
                if (btn[4, 0] == 1 && btn[4, 1] == 0)
                {
                    if (Input.GetKeyUp(KeyCode.D) || Input.GetKeyUp(KeyCode.J))
                    {
                        btn[4, 1] = 1;
                        Debug.Log("K: " + btn[4, 1]);
                    }
                }
                if (btn[5, 0] == 1 && btn[5, 1] == 0)
                {
                    if (Input.GetKeyUp(KeyCode.D) || Input.GetKeyUp(KeyCode.J))
                    {
                        btn[5, 1] = 1;
                        Debug.Log("L: " + btn[5, 1]);
                    }
                }
                ///////////////d,j+다른 버튼 키 처음 눌렀을 때 ///////////////
                if (inputForwardRout == null)
                {
                    this.inputForwardRout = StartCoroutine(this.Forward_act());
                }
                //////////////moveforward////////////////////////

            }


            //d>j일때 j
            if ((btn[2, 0] == 1 && pre_move>=0) && (btn[0, 1] == 1 || btn[1, 1] == 1 || btn[4, 1] == 1 || btn[5, 1] == 1))
            {
                if (Input.GetKeyDown(KeyCode.J))
                {
                    btn[3, 1] = 2;
                    btn[2, 1] = 0;
                    Debug.Log("j->" + btn[3, 1]);
                }
            }

            //j<d일때 d
            if ((btn[3, 0] == 1 && pre_move<=0) && (btn[0, 1] == 1 || btn[1, 1] == 1 || btn[4, 1] == 1 || btn[5, 1] == 1))
            {
                if (Input.GetKeyDown(KeyCode.D))
                {
                    btn[2, 1] = 2;
                    btn[3, 1] = 0;
                    Debug.Log("d->" + btn[2, 1]);

                }
            }
            yield return null;
        }

    }

    private IEnumerator Forward_act()
    {
        float o = this.inputLate;
        bool h = false;
        int backleg = 0;
        while (o > 0)
        {

            if (btn[0, 1] == 1)
            {

                if (Input.GetKeyUp(KeyCode.A))
                {
                    h = true;
                    btn[0, 1] = 0;

                }
            }
            if (btn[1, 1] == 1)
            {

                if (Input.GetKeyUp(KeyCode.S))
                {
                    h = true;
                    btn[1, 1] = 0;

                }
            }
            if (btn[4, 1] == 1)
            {

                if (Input.GetKeyUp(KeyCode.K))
                {
                    h = true;
                    btn[4, 1] = 0;

                }
            }
            if (btn[5, 1] == 1)
            {

                if (Input.GetKeyUp(KeyCode.L))
                {
                    h = true;
                    btn[5, 1] = 0;

                }
            }
            int[] back = new int[4] { 0, 1, 4, 5 };

            foreach (int i in back)
            {
                if (btn[i, 0] == 1)
                {
                    backleg++;
                }
            }
            o -= Time.deltaTime;
            yield return null;
        }
        if (h == true && backleg == 0)
        {
            if (pre_move != (btn[2, 1] - btn[3, 1]) && transform.position.y <= 38)
            {

                Debug.Log("forward!!" + pre_move);
                horizontalAxis = 5f;
                transform.position += (transform.forward * verticalAxis + transform.right * horizontalAxis) * Time.deltaTime * speedMovement;
                pre_move = btn[2, 1] - btn[3, 1];


            }
        }
        else if (transform.position.y > 38)
        {
            Debug.Log("Cant move!");
        }
        else
        {
            horizontalAxis = 0f;
            transform.position += (transform.forward * verticalAxis + transform.right * horizontalAxis) * Time.deltaTime * speedMovement;
        }

        this.inputForwardRout = null;

    }



    private IEnumerator FallDown()
    {
        float w = 0.01f;

        int num = 0;

        while (w > 0)
        {

            for (int i = 0; i < 6; i++)
            {
                if (btn[i, 0] == 1)
                {
                    num++;
                    Debug.Log("num:" + num);
                }
            }


            w -= Time.deltaTime;
            yield return null;
        }

        if (transform.position.y > 0 && num < 2)
        {
            Debug.Log("falling down");
            btn[2, 1] = 0;
            btn[3, 1] = 0;
            pre_move = 0;
            float time = 1f;
            while (time > 0)
            {
                ///개미 떨어지는 위치 조절

                horizontalAxis = -0.05f;
                transform.position += (transform.forward * verticalAxis + transform.right * horizontalAxis) * Time.deltaTime * speedMovement;
                time -= Time.deltaTime;
                

            }
            

        }
        else if (num >= 2)  
        {
            horizontalAxis = 0f;
            transform.position += (transform.forward * verticalAxis + transform.right * horizontalAxis) * Time.deltaTime * speedMovement;
        }

        if (transform.position.y < 0)
        {

            transform.position = new Vector3((float)-11.95, 0, (float)5.148);
            btn[2, 1] = 0;
            btn[3, 1] = 0;
            pre_move = 0;

        }

        
        yield return null;
    }

}
