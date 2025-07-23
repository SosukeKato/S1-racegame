using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class PlayerMove : MonoBehaviour
{
    Rigidbody2D _rb;
    [SerializeField]
    int _DirectinalSpeed;
    [SerializeField]
    int _PlayerSpeed;
    float x;
    // Start is called before the first frame update
    void Start()
    {
        _rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        //x���̈ړ�����
        x = Input.GetAxisRaw("Horizontal");
        Vector2 velocity = new Vector2(x, _DirectinalSpeed).normalized;
        _rb.velocity = velocity * _PlayerSpeed;
        //y���̈ړ�����
        _rb.velocity = new Vector2(_rb.velocity.x, _DirectinalSpeed);
    }
}
