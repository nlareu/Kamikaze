using UnityEngine;

public class AvatarMortalObjectCollision : GameCollision
{
    public AvatarMortalObjectCollision(string mortalObjectColliderTag) : base(Tags.PLAYER, mortalObjectColliderTag) { }

    public override void Resolve(GameObject collider1, GameObject collider2, Collision2D collision)
    {
        PlayerController av = collider1.GetComponent<PlayerController>();

        av.Kill();
    }
    public override void Resolve(GameObject collider1, GameObject collider2, Collider2D collider)
    {
        PlayerController av = collider1.GetComponent<PlayerController>();

        av.Kill();
    }
}