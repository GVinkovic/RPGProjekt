using UnityEngine;


[RequireComponent(typeof(SphereCollider))] //aggro area trigger
public class AggroArea : MonoBehaviour {

    public Entity owner; //set in inspector

    private void OnTriggerEnter(Collider co)
    {
        Entity entity = co.GetComponentInParent<Entity>();
        if (entity) owner.OnAggro(entity);
    }

    void OnTriggerStay(Collider co)
    {
        Entity entity = co.GetComponentInParent<Entity>();
        if (entity) owner.OnAggro(entity);
    }
}
