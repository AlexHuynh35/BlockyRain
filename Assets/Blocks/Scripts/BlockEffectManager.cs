using UnityEngine;

public class BlockEffectManager : MonoBehaviour
{
    public BlockEffect effect;
    
    void Start()
    {

    }

    void Update()
    {

    }
    
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other != null && effect != null && other.tag == "Player")
        {
            effect.ApplyEffect(other.gameObject);
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other != null && effect != null && other.tag == "Player")
        {
            effect.RemoveEffect(other.gameObject);
        }
    }
}
