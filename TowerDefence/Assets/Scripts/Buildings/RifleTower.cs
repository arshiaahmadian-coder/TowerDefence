using UnityEngine;

public class RifleTower : BaseBuilding
{
    public override void ProcessEveryFrame()
    {
        base.ProcessEveryFrame();

        if (target == null)
        {
            // find target
            target = EnemySpawner.instance.FindTarget(transform, data.attackRange);
        } else
        {
            // attack the target
            
        }
    }
}
