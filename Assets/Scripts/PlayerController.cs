using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    // 스피드 조정 변수
    [SerializeField]
    private float walkSpeed;
    [SerializeField]
    private float runSpeed;
    private float currentSpeed;

    // 필요한 컴포넌트
    private Rigidbody2D myRigid;

    void Start()
    {
        myRigid = GetComponent<Rigidbody2D>();

        // 초기화
        currentSpeed = walkSpeed;
    }
    void Update()
    {
        Move();
        TryRun();
    }

    // 달리기 시도
    private void TryRun()
	{
		if (Input.GetKey(KeyCode.LeftShift))
		{
            Running();
		}
		if (Input.GetKeyUp(KeyCode.LeftShift))
		{
            RunningCancel();
		}
	}

    // 달리기
    private void Running()
	{
        currentSpeed = runSpeed;
	}

    // 달리기 취소
    private void RunningCancel()
	{
        currentSpeed = walkSpeed;
	}

    // 움직임 실행, 기본 상태는 walk
    private void Move()
    {
        float horizontalInput = Input.GetAxis("Horizontal");
        float verticalInput = Input.GetAxis("Vertical");

        Vector3 moveHorizontal = transform.right * horizontalInput;
        Vector3 moveVertical = transform.up * verticalInput;

        Vector3 velocity = (moveHorizontal + moveVertical).normalized * currentSpeed;

        myRigid.MovePosition(transform.position + velocity * Time.deltaTime);
        // transform.Translate(velocity * Time.deltaTime); 만약 Rigidbody2D 안 쓰면 이걸로 움직일 수 있음
    }
}
