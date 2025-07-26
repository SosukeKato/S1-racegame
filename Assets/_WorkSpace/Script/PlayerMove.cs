using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class PlayerMove : MonoBehaviour
{
    Rigidbody2D _rb;
    [SerializeField]
    int _directinalSpeed;
    [SerializeField]
    int _playerSpeed;
    [SerializeField]
    float x;

    float _speedMagnification = 1;
    public bool _characterBack;
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
        Vector2 velocity = new Vector2(x, _directinalSpeed).normalized;
        _rb.velocity = velocity * _playerSpeed;
        //y²‚ÌˆÚ“®ˆ—
        _rb.velocity = new Vector2(_rb.velocity.x, _directinalSpeed * _speedMagnification);
        //Œ¸‘¬‚Ìˆ—
        if (Input.GetKeyDown(KeyCode.S))
        {
            _speedMagnification = 0.5f;
        }
        if (Input.GetKeyUp(KeyCode.S))
        {
            _speedMagnification = 1;
        }
        //‰Á‘¬‚Ìˆ—
        if (Input.GetKeyDown(KeyCode.Space))
        {
            _speedMagnification = 2;
        }
    }
}
