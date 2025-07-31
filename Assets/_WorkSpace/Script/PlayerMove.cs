using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class PlayerMove : MonoBehaviour, Ranking.IDrive
{
    Rigidbody2D _rb;
    [SerializeField]
    int _directinalSpeed;
    [SerializeField]
    int _playerSpeed;
    [SerializeField]
    float x;

    float _speedUpCoolTime = 0;
    float _speedMagnification = 1;

    // Start is called before the first frame update
    void Start()
    {
        _rb = GetComponent<Rigidbody2D>();

        FindAnyObjectByType<Ranking>()?.AddDriver(this);
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
        if (Input.GetKeyDown(KeyCode.Space) && _speedUpCoolTime == 5)
        {
            _speedMagnification = 2;
            _speedUpCoolTime = 0;
            StartCoroutine("SpeedUpFinish");
        }
        #region RaycastでPlayerの前方にNPCがいるかどうか調べる処理
        //Rayの発射場所
        Vector2 _origin = transform.position;
        //Rayの発射方向
        Vector2 _front = Vector2.up;
        //Rayの長さ
        float _frontDistance = 5f;
        //(PlayerがNPCの背後にいる時)Rayがオブジェクトに衝突した場合の処理
        if (Physics2D.Raycast(_origin, _front, _frontDistance).collider)
        {
            _speedUpCoolTime += Time.deltaTime;
            if (_speedUpCoolTime >= 5)
            {
                _speedUpCoolTime = 5;
            }
        }
        //Rayをシーンビューに描画
        Debug.DrawRay(_origin, _front * _frontDistance, Color.red);
        #endregion
        //スピードアップしてから3秒後に元の速度に戻る処理
        IEnumerator SpeedUpFinish()
        {
            yield return new WaitForSeconds(3);
            _speedMagnification = 1;
        }
    }
}
