using UnityEngine;
using System.Collections;

public class Play : MonoBehaviour {

    public Animator m_WorldCanvasAnimator;
    public GameObject m_Panel;

    private Animator m_CameraCanvasAnimator;
    private bool m_FirstTime = false;

    void Awake()
    {
        m_CameraCanvasAnimator = GetComponent<Animator>();
        m_FirstTime = PlayerPrefs.GetInt("FirstTime", 1) == 1 ? true : false;
    }

    public void PlayFunction()
    {
        m_CameraCanvasAnimator.SetBool("Play", true);
        StartCoroutine(PlayTutorial());
    }

    IEnumerator PlayTutorial()
    {
        yield return new WaitForSeconds(0.5f);
        m_WorldCanvasAnimator.SetBool("Play", true);

        PlayerPrefs.SetInt("FirstTime", 0);
    }

    public void OnTouchPanel()
    {
        Destroy(m_Panel);
        m_WorldCanvasAnimator.SetBool("Play", false);
    }
}
