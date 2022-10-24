using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlendEyes : MonoBehaviour
{
    [SerializeField] private Animator m_eyesAnim;
    // Start is called before the first frame update
    
    public void PressHeart()
    {
        m_eyesAnim.SetBool("Heart",true);
        m_eyesAnim.SetBool("Excited", false);
        m_eyesAnim.SetBool("Angry", false);
        m_eyesAnim.SetBool("Dead", false);
    }
    public void PressExcited()
    {
        m_eyesAnim.SetBool("Heart", false);
        m_eyesAnim.SetBool("Excited", true);
        m_eyesAnim.SetBool("Angry", false);
        m_eyesAnim.SetBool("Dead", false);
    }
    public void PressAngry()
    {
        m_eyesAnim.SetBool("Heart", false);
        m_eyesAnim.SetBool("Excited", false);
        m_eyesAnim.SetBool("Angry", true);
        m_eyesAnim.SetBool("Dead", false);
    }
    public void PressDead()
    {
        m_eyesAnim.SetBool("Heart", false);
        m_eyesAnim.SetBool("Excited", false);
        m_eyesAnim.SetBool("Angry", false);
        m_eyesAnim.SetBool("Dead", true);
    }
}
