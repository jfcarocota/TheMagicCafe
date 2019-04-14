using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{

    [SerializeField]
    float moveSpeed;
    Animator anim;
    [SerializeField]
    Transform plateTrans;
    [SerializeField]
    GameObject currentPlate;

    void Start()
    {
        anim = GetComponent<Animator>();
    }

    void Update()
    {
        transform.Translate(Vector3.forward * Axis.magnitude * moveSpeed * Time.deltaTime);
        if(Axis != Vector3.zero)
        {
            transform.rotation = Quaternion.LookRotation(Axis);
        }
    }

    private void LateUpdate()
    {
        anim.SetFloat("Axis", Mathf.Abs(Axis.magnitude));
    }

    public Vector3 Axis{ get => new Vector3(Input.GetAxis("Horizontal"), 0f, Input.GetAxis("Vertical")); }
    public Animator Anim { get => anim; }
    public Transform PlateTrans { get => plateTrans; }
    public GameObject CurrentPlate { get => currentPlate; set => currentPlate = value; }
}

