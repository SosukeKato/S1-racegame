using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[RequireComponent(typeof(CharacterClamp), typeof(Rigidbody2D))]
public class EnemyAI : MonoBehaviour, Ranking.IDrive
{
    Rigidbody2D _rb;
    [SerializeField]
    int _directinalSpeed;

    float _speedMagnification = 1;
    float _speedUpCoolTime;
    // Start is called before the first frame update
    void Start()
    {
        _rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        //y���̈ړ�����
        _rb.velocity = new Vector2(_rb.velocity.x, _directinalSpeed * _speedMagnification);

#region Raycast���g���ď����̕�������
        //Ray�̔��ˏꏊ
        Vector2 _origin = transform.position;
        //�E��Ray�𔭎�
        Vector2 _right = Vector2.right;
        //Ray�̒���
        float _rightDistance = 5f;
        //�E�ɏo�Ă���Ray���I�u�W�F�N�g�ɏՓ˂����ꍇ�̏���
        if (Physics2D.Raycast(_origin, _right, _rightDistance).collider)
        {
            _speedMagnification = 0.5f;
        }
        else
        {
            _speedMagnification = 1;
        }
        //�O��Ray�𔭎�
        Vector2 _front = Vector2.up;
        //Ray�̒���
        float _frontDistance = 5f;
        //�O�ɏo�Ă���Ray���I�u�W�F�N�g�ɏՓ˂����ꍇ�̏���
        if (Physics2D.Raycast(_origin, _front, _frontDistance).collider)
        {
            _speedUpCoolTime += Time.deltaTime;
            if (_speedUpCoolTime >= 5)
            {
                _speedUpCoolTime = 5;
            }
            if (_speedUpCoolTime == 5)
            {
                _speedMagnification = 2;
                _speedUpCoolTime = 0;
                StartCoroutine("SpeedUpFinish");
            }
        }
        //Ray���V�[���r���[�ɕ`��
        Debug.DrawRay(_origin, _right * _rightDistance, Color.red);
#endregion
        //�X�s�[�h�A�b�v���Ă���3�b��Ɍ��̑��x�ɖ߂鏈��
        IEnumerator SpeedUpFinish()
        {
            yield return new WaitForSeconds(3);
            _speedMagnification = 1;
        }
    }
}
