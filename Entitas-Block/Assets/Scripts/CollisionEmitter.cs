using Entitas.Unity;
using UnityEngine;
using Entitas;

public class CollisionEmitter : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        var link = gameObject.GetEntityLink();
        var targetLink = collision.gameObject.GetEntityLink();

        Contexts contexts = Contexts.sharedInstance;
        contexts.game.CreateEntity()
            .AddCollision((GameEntity)link.entity, (GameEntity)targetLink.entity);
    }
    void OnCollisionEnter2D(Collision2D collision)
    {    
        var link = gameObject.GetEntityLink();
        var targetLink = collision.gameObject.GetEntityLink();

        Contexts contexts = Contexts.sharedInstance;
        contexts.game.CreateEntity()
            .AddCollision((GameEntity)link.entity, (GameEntity)targetLink.entity);
    }
}
