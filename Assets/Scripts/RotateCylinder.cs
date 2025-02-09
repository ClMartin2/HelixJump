using UnityEngine;

public class RotateCylinder : MonoBehaviour
{
    [SerializeField] private float rotateSpeed = 10f;
    [SerializeField] private float maxLength = 10f;
    [SerializeField] private Camera currentCamera;

    private Quaternion currenRotation = Quaternion.identity;
    private Vector3 lastMousePosition = Vector3.zero;

    void Start()
    {
        currenRotation = transform.rotation;
        lastMousePosition = GetMouseWorldMousePosition();
	}

    private Vector3 GetMouseWorldMousePosition()
    {
		Vector3 currentScreenMousePosition = Input.mousePosition;
		currentScreenMousePosition.z = currentCamera.transform.position.z - transform.position.z;
		Vector3 currentWorldMousePosition = currentCamera.ScreenToWorldPoint(currentScreenMousePosition);

        return currentWorldMousePosition;
	}
    
    void Update()
    {
        if(Input.GetMouseButtonDown(0))
			lastMousePosition = GetMouseWorldMousePosition();

		if (Input.GetMouseButton(0))
        {
			Vector3 directionMouse = GetMouseWorldMousePosition() - lastMousePosition;
			directionMouse = Vector3.ClampMagnitude(directionMouse, maxLength);
			float directionRotate = Vector3.Dot(Vector3.right, directionMouse.normalized);

			transform.rotation = currenRotation * Quaternion.AngleAxis(rotateSpeed * Time.deltaTime * directionRotate * directionMouse.magnitude, Vector3.up);
			currenRotation = transform.rotation;

			lastMousePosition = GetMouseWorldMousePosition();
		}
    }
}
