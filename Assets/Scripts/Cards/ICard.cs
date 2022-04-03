namespace Cards
{
    public interface ICard
    {
        int Value { get; }
        CardDecorator Decorator { get; }
        void StartDrag();
        void EndDrag();
    }
}