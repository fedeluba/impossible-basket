using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class Chas : MonoBehaviour {

    public Text scoreText;

    private int m_Score = 0;
    private AudioSource m_AudioSource;

    void Awake()
    {
        m_AudioSource = GetComponent<AudioSource>();
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Ball"))
        {
            m_AudioSource.Play();

            float ballVerticalVelocity = other.GetComponent<Rigidbody>().velocity.y;
            if(ballVerticalVelocity < 0f)
            {
                m_Score++;
                scoreText.text = m_Score.ToString();
            }
        }
    }
}
