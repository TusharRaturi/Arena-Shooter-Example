using UnityEngine;

public class MoveCommand : Command
{
    private Transform targetTransform;
    private float speed;
    private Vector3 direction;

    public MoveCommand(Transform targetTransform, float speed, Vector3 direction)
    {
        this.targetTransform = targetTransform;
        this.speed = speed;
        this.direction = direction;
    }

    public override void Execute()
    {
        //targetTransform.position += speed * direction * Time.deltaTime;
    }

    public override void Undo()
    {
        targetTransform.position += speed * -1 * direction * Time.deltaTime;
    }

    public override string ToString()
    {
        return targetTransform + " Moves at speed " + speed + " in direction " + direction;
    }
}
