using System.Collections.Generic;

public class Sequence : Node_Base
{
    public Sequence(BlackBoard bb,List<Node_Base> children) : base(bb,children) { }

    protected override NodeState OnTick()
    {
        foreach (Node_Base node in children)
        {
            // Bắt buộc gọi Evaluate() của nút con để kích hoạt vòng đời của nó
            switch (node.Evaluate())
            {
                case NodeState.Failure:
                    return NodeState.Failure; // Một nút hỏng -> Toàn bộ chuỗi hỏng

                case NodeState.Success:
                    continue; // Nút này xong, cho phép đi tiếp sang nút con tiếp theo

                case NodeState.Running:
                    return NodeState.Running; // Nút này đang bận -> Bắt chuỗi dừng lại chờ
            }
        }

        // Nếu duyệt qua hết mà không bị chặn lại -> Chuỗi thành công
        return NodeState.Success;
    }
}