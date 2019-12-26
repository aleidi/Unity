using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SkillMng
{
    private static SkillMng m_Instance;
    public static SkillMng Instance
    {
        get
        {
            if(null == m_Instance)
            {
                m_Instance = new SkillMng();
            }
            return m_Instance;
        }
    }

    private Dictionary<string, SkillBase> m_Skills = new Dictionary<string, SkillBase>();

    public void AddSkill(SkillBase skill)
    {
        m_Skills[skill.GetName()] = skill;
    }

    public void UseSkill(string name)
    {
        m_Skills[name].UseSkill();
    }

    public SkillBase GetSkill(string name)
    {
        return m_Skills[name];
    }
}
