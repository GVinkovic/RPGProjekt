using Mirror;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using UnityEngine;

public abstract class BuffSkill : BonusSkill
{
    public LevelBasedFloat buffTime = new LevelBasedFloat { baseValue = 60 };
    public BuffSkillEffect effect;

    // helper function to spawn the skill effect on someone
    // (used by all the buff implementations and to load them after saving)
    public void SpawnEffect(Entity caster, Entity spawnTarget)
    {
        if (effect != null)
        {
            GameObject go = Instantiate(effect.gameObject, spawnTarget.transform.position, Quaternion.identity);
            go.GetComponent<BuffSkillEffect>().caster = caster;
            go.GetComponent<BuffSkillEffect>().target = spawnTarget;
            go.GetComponent<BuffSkillEffect>().buffName = name;
            NetworkServer.Spawn(go);
        }
    }

    // tooltip
    public override string ToolTip(int skillLevel, bool showRequirements = false)
    {
        StringBuilder tip = new StringBuilder(base.ToolTip(skillLevel, showRequirements));
        tip.Replace("{BUFFTIME}", Utils.PrettySeconds(buffTime.Get(skillLevel)));
        return tip.ToString();
    }
}
