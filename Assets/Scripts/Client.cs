using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Client : MonoBehaviour
{
    Animator anim;
    Transform target;

    float timer = 0f;
    [SerializeField]
    float MaxTime = 5f;

    [SerializeField]
    float moveSpeed = 2f;
    IEnumerator<WaitForSeconds> move;

    public enum state { MOVING, WAITING, EATING}
    state currentState;

    string clientName = "";

    public string ClientName { get => clientName; set => clientName = value; }

    private void Awake()
    {
        anim = GetComponent<Animator>();
    }

    private void Start()
    {
        move = Move(0.01f);
        StartCoroutine(move);
    }

    IEnumerator<WaitForSeconds> Move(float t)
    {
        while(timer < MaxTime)
        {
            timer += Time.deltaTime;
            transform.Translate(Vector3.forward * Time.deltaTime * moveSpeed);
            if (!target)
            {
                target = Gamemanager.instance.selectTable().transform;
            }
            else
            {
                transform.LookAt(target);
                if (Vector3.Distance(transform.position, target.position) <= 0.5f)
                {
                    anim.SetBool("eating", true);
                    currentState = state.WAITING;
                    StopCoroutine(move);
                }
            }
            yield return new WaitForSeconds(t);
        }
    }

    private void OnTriggerStay(Collider other)
    {
        if(other.tag == "Player" && Input.GetButtonDown("Submit"))
        {
            switch (currentState)
            {
                case state.WAITING:
                    Gamemanager.instance.Orders.Add(clientName);
                    break;
                case state.EATING:
                    break;
                case state.MOVING:
                    break;
            }
        }
    }
}
