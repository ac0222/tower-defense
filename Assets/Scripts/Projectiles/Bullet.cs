using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public float bulletDamage = 2.0f;
    private List<GameObject> effects;

    // Start is called before the first frame update
    void Start()
    {
        effects = new List<GameObject>();
        GameObject instantDamagePrefab = Resources.Load("Prefabs/Effects/InstantDamageEffect") as GameObject;
        instantDamagePrefab.GetComponent<InstantDamageEffect>().Damage = bulletDamage;
        effects.Add(instantDamagePrefab);   
    }

    // Update is called once per frame
    void Update()
    {
        if (transform.position.magnitude > 30)
        {
            Destroy(gameObject);
        }
    }

    void OnTriggerEnter2D(Collider2D collider)
    {
        MinionController mc = collider.gameObject.GetComponent<MinionController>();
        if (mc != null) 
        {
            foreach(GameObject effect in effects)
            {
                GameObject effectOnMinion = Instantiate(effect, mc.transform.position, Quaternion.identity);
                effectOnMinion.transform.SetParent(mc.gameObject.transform);
                IEffect ec = effectOnMinion.GetComponent<IEffect>();
                ec.TargetMinion = mc;
                ec.CopyEffect(effect.GetComponent<IEffect>());
                ec.Invoke();
            }
            Destroy(gameObject);
        }
    }
}
