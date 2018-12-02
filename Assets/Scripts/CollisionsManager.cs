using System.Collections.Generic;
using UnityEngine;

public class CollisionsManager {

    private static List<IGameCollision> Collisions;

    static CollisionsManager() {
        Collisions = new List<IGameCollision>
        {
            new PlayerEnemyCollision(),
            new PlayerFinalTargetCollision(),
        };
    }

    public static void ResolveCollision(GameObject collider1, GameObject collider2, Collision2D collision)
    {
        IGameCollision gameColl = Collisions.Find(item => (collider1.CompareTag(item.Collider1Tag)) && (collider2.CompareTag(item.Collider2Tag)));

        if (gameColl != null)
            gameColl.Resolve(collider1, collider2, collision);
        else
            Debug.Log(string.Format("Collision not configured: '{0}' - '{1}'.", collider1.tag, collider2.tag));
    }
    public static void ResolveCollision(GameObject collider1, GameObject collider2, Collider2D collider)
    {
        IGameCollision gameColl = Collisions.Find(item => (collider1.CompareTag(item.Collider1Tag)) && (collider2.CompareTag(item.Collider2Tag)));

        if (gameColl != null)
            gameColl.Resolve(collider1, collider2, collider);
        else
            Debug.Log(string.Format("Collision not configured: '{0}' - '{1}'.", collider1.tag, collider2.tag));

    }
}
