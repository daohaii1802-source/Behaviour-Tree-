    using UnityEngine;
    using System.Collections.Generic;

    public static class Tree
    {
        public static Node_Base BuildTree(BlackBoard bb, Transform bossTransform)
        {
             Node_Base chaseNode = new ChasePlayerNode(bb, bossTransform);
            // Node_Base attackNode = new BossAttackNode(bb);
            // Node_Base patrolNode = new PatrolNode(bb, bossTransform);

            Node_Base root = new Selector(bb, new List<Node_Base>
            {
                new Sequence(bb, new List<Node_Base>
                {
                     chaseNode,
                    // attackNode
                })
            
                // , patrolNode 
            });

            return root;
        }
    }