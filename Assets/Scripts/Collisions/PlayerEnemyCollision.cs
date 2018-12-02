using UnityEngine;

public class PlayerEnemyCollision : GameCollision
{
    public PlayerEnemyCollision() : base(Tags.PLAYER, Tags.ENEMY) { }

    public override void Resolve(GameObject collider1, GameObject collider2, Collision2D collision)
    {
        PlayerController av = collider1.GetComponent<PlayerController>();

        av.EnemyHit();

        Object.Destroy(collider2);
    }
    public override void Resolve(GameObject collider1, GameObject collider2, Collider2D collider)
    {
        PlayerController av = collider1.GetComponent<PlayerController>();

        av.EnemyHit();

        Object.Destroy(collider2);
    }
}