using UnityEngine;
using DG.Tweening;
using System.Collections;

public delegate void EventHandlerBall(Ball sender);

[RequireComponent(typeof(Rigidbody))]
public class Ball : MonoBehaviour
{
	[SerializeField] private float bounceForce = 100f;
	[SerializeField] private Vector3 endScaleAnimCollision;
	[SerializeField] private float durationAnimCollision;
	[SerializeField] private Ease curveAnimCollision;

	private Vector3 startScale;
	private Rigidbody rb;
	public event EventHandlerBall collide;
	
	private void Start()
	{
		rb = GetComponent<Rigidbody>();
		startScale = transform.lossyScale;
	}

	private void OnCollisionEnter(Collision collision)
	{
		StartCoroutine(StopOnCollide());
		collide?.Invoke(this);
	}

	private IEnumerator StopOnCollide()
	{
		transform.DOScale(endScaleAnimCollision, durationAnimCollision).SetEase(curveAnimCollision).OnComplete(ResetScale);
		//rb.linearVelocity = Vector3.zero;

		Vector3 velocity = Vector3.up * bounceForce * Time.deltaTime;
		rb.linearVelocity = velocity;

		yield return null;
	}

	private void ResetScale()
	{
		transform.DOScale(startScale, durationAnimCollision).SetEase(curveAnimCollision);
	}
}
