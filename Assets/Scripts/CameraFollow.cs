using System;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    [SerializeField] private float smoothSpeed = 0.04f;
    [SerializeField] private float yOffset = 5f;
    [SerializeField] private Transform ball;

	[NonSerialized]
	public Transform target;

	private Vector3 startPosition;

	private void Start()
	{
		startPosition = transform.position;
	}

	public void Init()
	{
		startPosition = transform.position;
		transform.position = GetTargetPosition();
	}

	private void Update()
	{
		transform.position = Vector3.Lerp(transform.position, GetTargetPosition(), smoothSpeed);
	}

	private Vector3 GetTargetPosition()
	{
		Vector3 _targetPosition = new Vector3(startPosition.x, target.position.y + yOffset, startPosition.z);
		return _targetPosition;
	}
}
