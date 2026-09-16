using System.Collections.Generic;

public class Selector : Node_Base
{
    public Selector(BlackBoard bb, List<Node_Base> children) : base(bb,children) { }

    protected override NodeState OnTick()
    {
        foreach (Node_Base node in children)
        {
            switch (node.Evaluate())
            {
                case NodeState.Failure:
                    continue; // Nút này hỏng -> Bỏ qua, thử nhánh con tiếp theo

                case NodeState.Success:
                    return NodeState.Success; // Chỉ cần 1 nhánh thành công -> Dừng và báo thành công

                case NodeState.Running:
                    return NodeState.Running; // Nhánh này đang bận -> Cây phải chờ
            }
        }

        // Thử hết mọi cách đều hỏng -> Báo thất bại
        return NodeState.Failure;
    }
}