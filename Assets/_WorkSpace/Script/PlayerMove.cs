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
        //x���̈ړ�����
        x = Input.GetAxisRaw("Horizontal");
        Vector2 velocity = new Vector2(x, _directinalSpeed).normalized;
        _rb.velocity = velocity * _playerSpeed;
        //y���̈ړ�����
        _rb.velocity = new Vector2(_rb.velocity.x, _directinalSpeed * _speedMagnification);
        //�����̏���
        if (Input.GetKeyDown(KeyCode.S))
        {
            _speedMagnification = 0.5f;
        }
        if (Input.GetKeyUp(KeyCode.S))
        {
            _speedMagnification = 1;
        }
        //�����̏���
        if (Input.GetKeyDown(KeyCode.Space))
        {
            _speedMagnification = 2;
        }
        #region Raycast��Player�̑O����NPC�����邩�ǂ������ׂ鏈��
        //Ray�̔��ˏꏊ
        Vector2 origin = transform.position;
        //Ray�̔��˕���
        Vector2 direction = Vector2.up;
        //Ray�̒���
        float distance = 5f;
        //Ray���I�u�W�F�N�g�ɏՓ˂����ꍇ�̏���
        if (Physics2D.Raycast(origin, direction, distance).collider)
        {
            _characterBack = true;
        }
        else
        {
            _characterBack = false;
        }
        //Ray���V�[���r���[�ɕ`��
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
