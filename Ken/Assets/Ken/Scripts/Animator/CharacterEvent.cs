using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterEvent : MonoBehaviour
{
    public delegate void Attack();
    public event Attack EventAttack;
    public delegate void Counter();
    public event Counter EventCounter;
    public delegate void PerfectGuard();
    public event PerfectGuard EventPerfectGuard;
    public delegate void Skill(string name);
    public event Skill EventSkill;

    private Animator m_Anim;
    private AudioSource m_Audio;
    private AudioClip m_NowAudioClip;
    private Dictionary<string, AudioClip> m_AudioClips = new Dictionary<string, AudioClip>();
    private Character m_Character;

    void Start()
    {
        m_Anim = transform.GetComponent<Animator>();
        m_Audio = transform.GetComponent<AudioSource>();
    }
    
    public void SetCharacter(Character character)
    {
        m_Character = character;
    }

    public void SetAnimtorSpeed(float value)
    {
        m_Anim.speed = value;
    }

    public void OnAttack()
    {
        EventAttack.Invoke();
    }

    void OnCounter()
    {
        EventCounter.Invoke();
    }

    void SetPerfectGuard()
    {
        EventPerfectGuard.Invoke();
    }

    void OnSkill(string name)
    {
        EventSkill.Invoke(name);
    }

    void PlayAudioClip(string name)
    {
        m_AudioClips.TryGetValue(name, out m_NowAudioClip);
        if (null == m_NowAudioClip)
        {
            m_NowAudioClip = Resources.Load<AudioClip>("Audios/SE/" + name);
            m_AudioClips[name] = m_NowAudioClip;
        }

        m_Audio.clip = m_NowAudioClip;
        m_Audio.Play();
    }

    public Character GetCharacter()
    {
        return m_Character;
    }

}
