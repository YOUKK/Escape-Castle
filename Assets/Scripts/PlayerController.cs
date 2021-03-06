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

	// 상태 변수
	private bool isMove;
	private bool isWalk;
	private bool isRun;

	// 움직임 체크 변수
	private Vector3 lastPos;

	// 필요한 컴포넌트
	private SpriteRenderer thespriterenderer;
	private Animator theanimator;

	void Start()
	{
		thespriterenderer = GetComponent<SpriteRenderer>();
		theanimator = GetComponent<Animator>();

		// 초기화
		currentSpeed = walkSpeed;
	}
	void Update()
	{
		Walk();
		TryRun();
		MoveCheck();
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
		isRun = true;
		currentSpeed = runSpeed;
		theanimator.SetBool("isRun", true);
	}

	// 달리기 취소
	private void RunningCancel()
	{
		isRun = false;
		currentSpeed = walkSpeed;
		theanimator.SetBool("isRun", false);
	}

	// 걷기
	private void Walk()
	{
		if (Input.GetKey(KeyCode.D))
		{
			transform.Translate(transform.right * currentSpeed * Time.deltaTime);
			thespriterenderer.flipX = true;
		}
		if (Input.GetKey(KeyCode.A))
		{
			transform.Translate(transform.right * -1 * currentSpeed * Time.deltaTime);
			thespriterenderer.flipX = false;
		}
		if (Input.GetKey(KeyCode.W))
		{
			transform.Translate(transform.up * currentSpeed * Time.deltaTime);
		}
		if (Input.GetKey(KeyCode.S))
		{
			transform.Translate(transform.up * -1 * currentSpeed * Time.deltaTime);
		}
	}

	// 움직임 체크
	private void MoveCheck()
	{
		if(Vector3.Distance(lastPos, transform.position) >= 0.01f)
		{
			isWalk = true;
			theanimator.SetBool("isWalk", true);
		}
		else
		{
			isWalk = false;
			theanimator.SetBool("isWalk", false);
		}
		lastPos = transform.position;
	}
}
