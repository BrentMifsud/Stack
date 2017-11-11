namespace Stack
{
    /// <summary>
    /// An item in the stack
    /// </summary>
    public class ListItem
    {
        private object data;
        private ListItem nextItem;

        /// <summary>
        /// Constructor for a ListItem
        /// </summary>
        /// <param name="data"></param>
        /// <param name="nextItem"></param>
        public ListItem(object data, ListItem nextItem)
        {
            this.data = data;
            this.nextItem = nextItem;
        }

        /// <summary>
        /// Property for ListItem Data
        /// </summary>
        public object Data
        {
            get { return this.data; }
            set { this.data = value; }
        }

        /// <summary>
        /// Property for Next ListItem Object
        /// </summary>
        public ListItem NextItem
        {
            get { return this.nextItem; }
            set { this.nextItem = value; }
        }
    }
}
