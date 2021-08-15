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

	void Start()
	{
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

	private void Move()
	{
		if (Input.GetKey(KeyCode.D))
		{
			transform.Translate(transform.right * currentSpeed * Time.deltaTime);
		}
		if (Input.GetKey(KeyCode.A))
		{
			transform.Translate(transform.right * -1 * currentSpeed * Time.deltaTime);
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
}
