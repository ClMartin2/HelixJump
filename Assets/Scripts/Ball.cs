using UnityEngine;

public delegate void EventHandlerBall(Ball sender);

[RequireComponent(typeof(Rigidbody))]
public class Ball : MonoBehaviour
{
	[SerializeField] private float bounceForce = 100f;

	private Rigidbody rb;
	public event EventHandlerBall collide;
	
	private void Start()
	{
		rb = GetComponent<Rigidbody>();
	}

	private void OnCollisionEnter(Collision collision)
	{
		Vector3 velocity = Vector3.up * bounceForce * Time.deltaTime;
		rb.linearVelocity = velocity;

		collide?.Invoke(this);
	}
}
