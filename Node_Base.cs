using System.Collections.Generic;

public enum NodeState { Running, Success, Failure }

public abstract class Node_Base
{
    protected NodeState state;
    public Node_Base parent;
    protected List<Node_Base> children = new List<Node_Base>();

    // Bảng đen (Blackboard) lưu trữ dữ liệu động
    private bool hasStarted = false;
    protected BlackBoard blackBoard;


    //Khởi tạo cho các node lá
    public Node_Base(BlackBoard bb) 
    { 
        this.blackBoard = bb; 
    }

    // Khởi tạo cho Sequence, Selector
    public Node_Base(BlackBoard bb,List<Node_Base> children)
    {
        this.blackBoard = bb;
        foreach (var child in children)
            Attach(child);
    }

    private void Attach(Node_Base node)
    {
        node.parent = this;
        children.Add(node);
    }

    // Hàm đánh giá chính - Quản lý vòng đời 
    public NodeState Evaluate()
    {
        if (!hasStarted)
        {
            OnEnter();
            hasStarted = true;
        }

        state = OnTick();

        if (state != NodeState.Running)
        {
            OnExit();
            hasStarted = false;
        }

        return state;
    }

    // Các hàm vòng đời để class con ghi đè
    protected virtual void OnEnter() { }
    protected abstract NodeState OnTick();
    protected virtual void OnExit() { }
}