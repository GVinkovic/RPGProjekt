using System.Text;
using UnityEngine;

[CreateAssetMenu(menuName="Item/Potion", order=999)]
public class PotionItem : UsableItem
{
    [Header("Potion")]
    public int usageHealth;
    public int usageMana;
    public int usageExperience;
    public int usagePetHealth; // to heal pet

    // usage
    public override void Use(Player player, int inventoryIndex)
    {
        // always call base function too
        base.Use(player, inventoryIndex);

        // increase health/mana/etc.
        player.health += usageHealth;
        player.mana += usageMana;
        player.experience += usageExperience;
       

        // decrease amount
        ItemSlot slot = player.inventory[inventoryIndex];
        slot.DecreaseAmount(1);
        player.inventory[inventoryIndex] = slot;
    }

    // tooltip
    public override string ToolTip()
    {
        StringBuilder tip = new StringBuilder(base.ToolTip());
        tip.Replace("{USAGEHEALTH}", usageHealth.ToString());
        tip.Replace("{USAGEMANA}", usageMana.ToString());
        tip.Replace("{USAGEEXPERIENCE}", usageExperience.ToString());
        return tip.ToString();
    }
}
