using UnityEngine;
using System.Collections;

public class Ball : MonoBehaviour {

    public float m_LaunchForce = 10f;
    public AudioSource m_AudioSource_Bounce, m_AudioSource_Swoosh;

    private Rigidbody m_Rigidbody;
    private Vector3 m_StartingMousePosition;

    void Awake()
    {
        m_Rigidbody = GetComponent<Rigidbody>();
    }

	void OnMouseDown()
    {
        m_StartingMousePosition = new Vector3(Input.mousePosition.x / Screen.width, Input.mousePosition.y / Screen.height, Input.mousePosition.z);
    }

    void OnMouseUp()
    {
        Vector3 actualMousePosition = new Vector3(Input.mousePosition.x / Screen.width, Input.mousePosition.y / Screen.height, Input.mousePosition.z);
        Vector3 direction = (actualMousePosition - m_StartingMousePosition).normalized;
        float distance = Vector3.Distance(actualMousePosition, m_StartingMousePosition);

        m_Rigidbody.AddForce(direction * distance * m_LaunchForce, ForceMode.Impulse);
        m_AudioSource_Swoosh.Play();
    }

    void OnCollisionEnter(Collision other)
    {
        m_AudioSource_Bounce.Play();
    }
}
