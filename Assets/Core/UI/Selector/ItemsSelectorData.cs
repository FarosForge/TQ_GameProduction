using UI.Data;

namespace UI
{
    public class ItemsSelectorData : ISendData
    {
        public SlotChanger selector;
        public SelectorDataType type;

        public ItemsSelectorData(SlotChanger selector, SelectorDataType type)
        {
            this.selector = selector;
            this.type = type;
        }
    }

    public enum SelectorDataType
    {
        Resource,
        Items,
        All
    }
}