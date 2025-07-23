using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class PlayerMove : MonoBehaviour
{
    [SerializeField]
    int _DirectinalSpeed;
    [SerializeField]
    int _PlayerSpeed;
    Rigidbody2D _rb;
    float x;
    // Start is called before the first frame update
    void Start()
    {
        _rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        //x²‚ÌˆÚ“®ˆ—
        x = Input.GetAxisRaw("Horizontal");
        //y²‚ÌˆÚ“®ˆ—
        _rb.velocity = new Vector2(_rb.velocity.x * _PlayerSpeed, _DirectinalSpeed);
    }
}
