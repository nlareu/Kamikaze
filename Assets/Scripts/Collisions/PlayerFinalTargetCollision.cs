using UnityEngine;

public class PlayerFinalTargetCollision : GameCollision
{
    public PlayerFinalTargetCollision() : base(Tags.PLAYER, Tags.FINAL_TARGET) { }

    public override void Resolve(GameObject collider1, GameObject collider2, Collision2D collision)
    {
        PlayerController av = collider1.GetComponent<PlayerController>();

        av.Kill();

        Object.Destroy(collider2);
    }
    public override void Resolve(GameObject collider1, GameObject collider2, Collider2D collider)
    {
        PlayerController av = collider1.GetComponent<PlayerController>();

        av.Kill();

        Object.Destroy(collider2);
    }
}