using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using UnityEngine.UI;



public class CharacterAction : MonoBehaviour
{
    public int count;
    private Animator anim;
    public GameObject hook;
    public GameObject pointer;
    private GameObject myHook;
    public GameObject brush;
    public bool isTargeting;
    public float speed;
    public bool hasShot;
    public bool isBrush;
    public bool isDead;
    public int hp;
    public int playerNumber;
    public float energy;
    public float maxEnergy;
    public bool hasHook;
    public int Index;
    public RaycastHit[] hitInfo;
    public LayerMask layer;
    public GameObject Layer1;
    public CubeManager[] children;
    public GameObject Layer2;
    public CubeManager[] children2;
    public bool p1Hook;
    public bool p2Hook;
    CharacterController p1;
    CharacterController2 p2;
    public Player player;
    public Slider hpSlider;
    public Slider energySlider;
    public Transform hookBornPos;
    private float shotTime;
    public float shotCD;
    private void Start()
    {

        shotTime = 0;
        anim = GetComponent<Animator>();
        Layer1 = GameObject.FindWithTag("Layer1");
        children = Layer1.GetComponentsInChildren<CubeManager>();
        Layer2 = GameObject.FindWithTag("Layer2");
        children2 = Layer2.GetComponentsInChildren<CubeManager>();
    }
    // Start is called before the first frame update

    private void Update()
    {
        hpSlider.value = player.hp;
        energySlider.value = energy;
        if(energy == 0)
        {
            speed = 1.6f;
        }
        else
        {
            speed = 2.2f;
        }
    }
    public void AttackAnim()
    {
        anim.SetBool("isAttack", true);
    }
    public void ResetAttack()
    {
        anim.SetBool("isAttack", false);
    }
    public void Targeting()
    {
        if (!isBrush)
        {
            return;
        }
        pointer.SetActive(true);
        //Vector3 end = new Vector3 (0, 45, 0);
        //Tweener t = pointer.transform.DORotate(end, 0.5f);
        //t.SetLoops(5,LoopType.Yoyo);
        //t.Play();
        //实例化一个摇摆的动画
    }
    public void CancelTargeting()
    {
        pointer.SetActive(false);
        hasShot = false;
    }

    public void AttackAct(int index)
    {
        if (Time.time - shotTime < shotCD)
        {
            return;
        }


        shotTime = Time.time;
        myHook = Instantiate(hook, null);
        //Vector3 dir = Quaternion.Euler(pointer.transform.rotation.eulerAngles) * pointer.transform.forward;
        Vector3 dirNew = Quaternion.Euler(hookBornPos.transform.localRotation.eulerAngles) * hookBornPos.transform.forward;
        Vector3 bornPos = new Vector3(hookBornPos.position.x, hookBornPos.position.y + 1.5f, hookBornPos.position.z);
        myHook.transform.position = bornPos + dirNew * 1.0f;
        myHook.transform.forward = dirNew;
        if (index == 1)
        {
            myHook.tag = "Player1Hook";
        }
        else
        {
            myHook.tag = "Player2Hook";
        }
        pointer.SetActive(false);
        //扔出hook
        //GameObject go = Instantiate(hook);
        hasShot = true;

    }

    public void Brush()
    {
        if (!isBrush)
        {
            brush.SetActive(true);
            isBrush = true;
        }
        else
        {
            isBrush = false;
            brush.SetActive(false);
            energy = maxEnergy;
            SetCubeToDefault();
        }
    }

    //public void Hurt()
    //{
    //    anim.Play("GetHit");
    //}

    public void MoveAct(Vector3 input)
    {
        input = input.normalized;
        if (input.magnitude > 0.1f)
        {
            transform.forward = input;
        }
        transform.position += input * speed * Time.deltaTime;
    }


    public void MoveAnim(float h, float v)
    {
        anim.SetFloat("VelocityX", v);
        anim.SetFloat("VelocityZ", h);
    }



    public void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Hook"))
        {

            anim.SetBool("isHurt", true);//播放受击动画
        }

        CubeManager cube = other.GetComponent<CubeManager>();



        if (isBrush)
        {
            if (other.CompareTag("TrueLayer"))
            {
                CubeManager fakeCube = FindFakeLayer(other, cube).GetComponent<CubeManager>();
                if (cube.belong == CubeManager.Belong.Default)
                {
                    if (fakeCube.state == CubeManager.State.Default || (playerNumber == 1 && fakeCube.state == CubeManager.State.FakeP2) || (playerNumber == 2 && fakeCube.state == CubeManager.State.FakeP1))
                    {
                        if (energy > 0)
                        {
                            energy -= 1;
                            ChangeCubeState(cube, fakeCube);
                        }
                    }
                }
                else if (cube.belong == CubeManager.Belong.Player1 && fakeCube.state == CubeManager.State.FakeP2 && playerNumber == 1)
                {
                    if (energy > 0)
                    {
                        ChangeCubeState(cube, fakeCube);
                    }
                }
                else if (cube.belong == CubeManager.Belong.Player2 && fakeCube.state == CubeManager.State.FakeP1 && playerNumber == 2)
                {
                    if (energy > 0)
                    {
                        ChangeCubeState(cube, fakeCube);
                    }
                }  
                else if (cube.belong == CubeManager.Belong.Player2  && playerNumber == 2)
                {
                    if (energy > 0)
                    {
                        ChangeCubeState(cube, fakeCube);
                    }
                } 
                else if (cube.belong == CubeManager.Belong.Player1  && playerNumber == 1)
                {
                    if (energy > 0)
                    {
                        ChangeCubeState(cube, fakeCube);
                    }
                }
                else if (cube.belong == CubeManager.Belong.Player1 && playerNumber ==2)
                {
                    if (energy > 0)
                    {
                        energy -= 1;
                        ChangeCubeState(cube, fakeCube);
                    }
                }
                else if (cube.belong == CubeManager.Belong.Player2 && playerNumber == 1)
                {
                    if (energy > 0)
                    {
                        energy -= 1;
                        ChangeCubeState(cube, fakeCube);
                    }
                }
            }
        }






    }

    private void ChangeCubeState(CubeManager cube, CubeManager fakeCube)
    {
        if (playerNumber == 1)
        {
            fakeCube.state = CubeManager.State.FakeP1;
            cube.state = CubeManager.State.FakeP1;
        }
        if (playerNumber == 2)
        {
            fakeCube.state = CubeManager.State.FakeP2;
            cube.state = CubeManager.State.FakeP2;
        }
    }

    private void SetCubeToDefault()
    {
        foreach (CubeManager cube in children )
        {
            if (cube.state == CubeManager.State.FakeP1 && playerNumber == 1)
            {
                cube.state = CubeManager.State.Default;
            }
        }

        foreach (CubeManager cube in children2)
        {

            if (cube.state == CubeManager.State.FakeP1 && playerNumber == 1 )
            {
                cube.state = CubeManager.State.Default;
            }
        }
        
        foreach (CubeManager cube in children )
        {
            if (cube.state == CubeManager.State.FakeP2 && playerNumber == 2)
            {
                cube.state = CubeManager.State.Default;
            }
        }

        foreach (CubeManager cube in children2)
        {

            if (cube.state == CubeManager.State.FakeP2 && playerNumber == 2 )
            {
                cube.state = CubeManager.State.Default;
            }
        }
    }

    private Collider FindFakeLayer(Collider other, CubeManager cube)
    {
        Vector3 x = new Vector3(other.transform.position.x, other.transform.position.y, other.transform.position.z);
        hitInfo = Physics.RaycastAll(new Ray(x, Vector3.up), 10, layer);
        //Debug.DrawRay(x, Vector3.up, Color.red, 10);
        foreach (var hit in hitInfo)
        {
            
            CubeManager fake = hit.collider.gameObject.GetComponent<CubeManager>();
            if (cube.row == fake.row && cube.col == fake.col)
            {
                //hit.collider.GetComponent<MeshRenderer>().material.color = Color.yellow;
                return hit.collider;
            }
        }

        return null;
    }

    public void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Hook"))
        {
            anim.SetBool("isHurt", false);
        }
    }
    public void ResetHurt()
    {
        anim.SetBool("isHurt", false);
    }

    public void Die()
    {
        anim.Play("Die01");
        isDead = true;
    }

    public void DieIdle()
    {
        anim.SetBool("isDie", false);
    }

}
