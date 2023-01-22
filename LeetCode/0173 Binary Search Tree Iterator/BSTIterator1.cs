namespace LeetCode._0173_Binary_Search_Tree_Iterator;

/// <summary>
/// https://leetcode.com/submissions/detail/882132892/
/// </summary>
public class BSTIterator1 : IBSTIterator
{
    private readonly TreeNode? _root;
    private IBSTIterator? _innerIterator;
    private ProcessedState _processedState = ProcessedState.None;

    public BSTIterator1(TreeNode? root)
    {
        _root = root;
    }

    public int Next()
    {
        if (!HasNext())
        {
            throw new InvalidOperationException();
        }

        if (_innerIterator != null)
        {
            return _innerIterator.Next();
        }

        _processedState = ProcessedState.Middle;
        return _root!.val;
    }

    public bool HasNext()
    {
        if (_root == null)
        {
            return false;
        }

        while (true)
        {
            if (_innerIterator?.HasNext() == true)
            {
                return true;
            }

            _innerIterator = null;

            switch (_processedState)
            {
                case ProcessedState.None:
                    _innerIterator = new BSTIterator1(_root.left);
                    _processedState = ProcessedState.Left;
                    break;
                case ProcessedState.Left:
                    return true;
                case ProcessedState.Middle:
                    _innerIterator = new BSTIterator1(_root.right);
                    _processedState = ProcessedState.Right;
                    break;
                case ProcessedState.Right:
                    return false;
                default:
                    throw new ArgumentOutOfRangeException();
            }
        }
    }

    private enum ProcessedState
    {
        None,
        Left,
        Middle,
        Right
    }
}
