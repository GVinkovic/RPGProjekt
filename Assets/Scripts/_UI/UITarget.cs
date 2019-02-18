// Note: this script has to be on an always-active UI parent, so that we can
// always find it from other code. (GameObject.Find doesn't find inactive ones)
using UnityEngine;
using UnityEngine.UI;
using Mirror;

public partial class UITarget : MonoBehaviour
{
    public GameObject panel;
    public Slider healthSlider;
    public Text nameText;


    void Update()
    {
        Player player = Utils.ClientLocalPlayer();
        if (!player) return;

        // show nextTarget > target
        // => feels best in situations where we select another target while
        //    casting a skill on the existing target.
        // => '.target' doesn't change while casting, but the UI gives the
        //    illusion that we already targeted something else
        // => this is also great for skills that change the target while casting,
        //    e.g. a buff that is cast on 'self' even though we target an 'npc.
        //    this way the player doesn't see the target switching.
       
        Entity target = player.nextTarget ?? player.target;
        if (target != null && target != player)
        {
            float distance = Utils.ClosestDistance(player.collider, target.collider);

            // name and health
            panel.SetActive(true);
            healthSlider.value = target.HealthPercent();
            nameText.text = target.name;

        }
        else panel.SetActive(false); // hide
    }
}
