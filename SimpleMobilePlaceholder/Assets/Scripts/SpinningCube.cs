using UnityEngine;
using System.Collections;

public class SpinningCube : MonoBehaviour 
{
	public float m_Speed = 20f;

	private Vector3 m_RotationDirection = Vector3.up;

	public void ToggleRotationDirection()
	{
		Debug.Log ("Toggling rotation new direction");

		if (m_RotationDirection == Vector3.up) 
		{
			m_RotationDirection = Vector3.down;
            m_Speed = m_Speed+20;
		}
		else 
		{
			m_RotationDirection = Vector3.up;
            m_Speed = m_Speed + 20;
        }
	}

	void Update() 
	{
		transform.Rotate(m_RotationDirection * Time.deltaTime * m_Speed);
	}
}
