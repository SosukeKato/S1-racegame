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

    float _time = 0;
    float _speedMagnification = 1;
    bool _characterBack;
    // Start is called before the first frame update
    void Start()
    {
        _rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        //x軸の移動処理
        x = Input.GetAxisRaw("Horizontal");
        Vector2 velocity = new Vector2(x, _directinalSpeed).normalized;
        _rb.velocity = velocity * _playerSpeed;
        //y軸の移動処理
        _rb.velocity = new Vector2(_rb.velocity.x, _directinalSpeed * _speedMagnification);
        //減速の処理
        if (Input.GetKeyDown(KeyCode.S))
        {
            _speedMagnification = 0.5f;
        }
        if (Input.GetKeyUp(KeyCode.S))
        {
            _speedMagnification = 1;
        }
        //加速の処理
        if (Input.GetKeyDown(KeyCode.Space))
        {
            _speedMagnification = 2;
        }
        #region RaycastでPlayerの前方にNPCがいるかどうか調べる処理
        //Rayの発射場所
        Vector2 origin = transform.position;
        //Rayの発射方向
        Vector2 direction = Vector2.up;
        //Rayの長さ
        float distance = 5f;
        //Rayがオブジェクトに衝突した場合の処理
        if (Physics2D.Raycast(origin, direction, distance).collider)
        {
            _characterBack = true;
        }
        else
        {
            _characterBack = false;
        }
        //Rayをシーンビューに描画
        Debug.DrawRay(origin, direction * distance, Color.red);
        #endregion
        if (_characterBack)
        {
            _time += Time.deltaTime;
            if(_time >= 5)
            {
                _time = 5;
            }
        }
    }
}
