public class MinStack
{
    private Stack<int> stack;
    private Stack<int> minStack;

    /** initialize your data structure here. */
    public MinStack()
    {
        stack = new Stack<int>();
        minStack = new Stack<int>();
    }

    public void Push(int x)
    {
        stack.Push(x);
        if (minStack.Count == 0 || x <= minStack.Peek())
        {
            minStack.Push(x);
        }
    }

    public void Pop()
    {
        if (stack.Count > 0)
        {
            int popped = stack.Pop();
            if (popped == minStack.Peek())
            {
                minStack.Pop();
            }
        }
    }

    public int Top()
    {
        if (stack.Count > 0)
        {
            return stack.Peek();
        }
        throw new InvalidOperationException("Stack is empty");
    }

    public int GetMin()
    {
        if (minStack.Count > 0)
        {
            return minStack.Peek();
        }
        throw new InvalidOperationException("Stack is empty");
    }
}