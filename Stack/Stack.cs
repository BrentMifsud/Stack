using System;

namespace Stack
{
    /// <summary>
    /// Stack Object
    /// </summary>
    class Stack
    {
        /// <summary>
        /// The start of the Stack
        /// </summary>
        private ListItem firstItem;
        
        /// <summary>
        /// The number of items in the stack
        /// </summary>
        private int size;

        /// <summary>
        /// Default Constructor
        /// </summary>
        public Stack()
        {
            this.firstItem = null;
            this.size = 0;
        }

        /// <summary>
        /// Returns the empty status of the stack
        /// </summary>
        public bool Empty
        {
            get { return this.size == 0; }
        }

        /// <summary>
        /// Returns the number of items in the stack
        /// </summary>
        public int Size
        {
            get { return this.size; }
        }

        /// <summary>
        /// Inserts object o at the specified index
        /// </summary>
        /// <param name="index"></param>
        /// <param name="o"></param>
        /// <returns>Object added</returns>
        public object Add(int index, object o)
        {
            if(index < 0)
                throw new ArgumentOutOfRangeException("Index: " + index);

            if(index > size)
                index = size; 

            ListItem current = this.firstItem;

            if(this.Empty || index == 0)
            {
                this.firstItem = new ListItem(o, this.firstItem);
            }
            else
            {
                for(int i = 0; i < index - 1; i++)
                    current = current.NextItem;

                current.NextItem = new ListItem(o, current.NextItem);
            }

            size++;

            return o;
        }

        /// <summary>
        /// Removes the object at the specified index from the stack
        /// </summary>
        /// <param name="index"></param>
        /// <returns>Removed Object</returns>
        public object Remove(int index)
        {
            if (index < 0)
                throw new ArgumentOutOfRangeException("Index: " + index);

            if (this.Empty)
                return null;

            if (index >= size)
                index = size - 1;

            ListItem current = this.firstItem;
            object result = null;

            if(index == 0)
            {
                result = current.Data;
                this.firstItem = current.NextItem;
            }
            else
            {
                for (int i = 0; i < index - 1; i++)
                    current = current.NextItem;

                result = current.NextItem.Data;
                current.NextItem = current.NextItem.NextItem;
                size--;
            }

            return result;
        }

        /// <summary>
        /// Removes object o from the stack
        /// </summary>
        /// <param name="o"></param>
        /// <returns>Object that was removed</returns>
        public object Remove(object o)
        {
            ListItem current = this.firstItem;
            object result = null;

            for (int i = 0; i < size; i++)
            {
                if (current.Data.Equals(o) && i == 0)
                {
                    result = current.Data;
                    this.firstItem = current.NextItem;
                    size--;
                    break;
                }
                else if (current.NextItem.Data.Equals(o))
                {
                    result = current.NextItem.Data;
                    current.NextItem = current.NextItem.NextItem;
                    size--;
                    break;
                }
                else
                {
                    current = current.NextItem;
                }
            }
            return result;
        }

        /// <summary>
        /// Add an object to the end of the stack
        /// </summary>
        /// <param name="o"></param>
        /// <returns></returns>
        public object Push(object o)
        {
            return this.Add(size, o);
        }

        /// <summary>
        /// Removes and returns object from the end of the stack
        /// </summary>
        /// <returns> Object removed from list</returns>
        public object Pop()
        {
            object result = null;

            if (this.Empty)
            {
                return result;
            }
            else if(size == 1)
            {
                result = this.firstItem;
                Clear();
                return result;
            }
            else
            {
                ListItem current = this.firstItem;
                for (int i = 0; i < size - 2; i++)
                    current = current.NextItem;

                result = current.NextItem.Data;
                current.NextItem = null;
                size--;
            }
            return result;
        }

        /// <summary>
        /// Clear the stack
        /// </summary>
        public void Clear()
        {
            this.firstItem = null;
            this.size = 0;
        }

        /// <summary>
        /// Return index of the specified object. 
        /// Return -1 if not found.
        /// </summary>
        /// <param name="o"></param>
        /// <returns>Index of object o</returns>
        public int IndexOf(object o)
        {
            ListItem current = this.firstItem;
            for (int i = 0; i < size; i++)
            {
                if(current.Data.Equals(o))
                    return i;

                current = current.NextItem;
            }

            return -1;
        }

        /// <summary>
        /// Returns true if object o exists in Stack
        /// </summary>
        /// <param name="o"></param>
        /// <returns></returns>
        public bool Contains(object o)
        {
            return this.IndexOf(o) != -1;     
        }

        /// <summary>
        /// Returns the object at the specified index
        /// </summary>
        /// <param name="index"></param>
        /// <returns>object</returns>
        public object Get(int index)
        {
            if(index < 0)
                throw new ArgumentOutOfRangeException("Index: " + index);

            if (this.Empty)
                return null;

            if (index >= this.size)
                index = this.size - 1;

            ListItem current = this.firstItem;

            for (int i = 0; i < index; i++)
                current = current.NextItem;

            return current.Data;
        }

        /// <summary>
        /// Indexer for Stack. Allows array-like access to the stack.
        /// </summary>
        /// <param name="index"></param>
        /// <returns></returns>
        public object this[int index]
        {
            get { return this.Get(index); }
            set
            {
                ListItem current = this.firstItem;
                for(int i = 0; i < size; i++)
                {
                    if(i == index)
                    {
                        current.Data = value;
                        break;
                    }

                    current = current.NextItem;
                }
            }
        }
    }
}
