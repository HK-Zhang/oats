/*
 * Description:This file is used to implement general type of ArrayList and contains a class ArrayList<T>..
 * Author: Zhang HeKe
 * Create Date:2007-5-28
 */

using System;
using System.Collections.Generic;
using System.Text;
using System.Collections;

namespace FastStructure.LAF.GenericType
{
    /// <summary>
    /// Description:This class is used to implement general type of ArrayList
    /// Author:Steven
    /// Create Date:2007-5-28
    /// </summary>
    public class ArrayList<T> : ICollection<T>, IList<T>
    {
        ArrayList Items = new ArrayList();
        #region ICollection<T> Members
        /// <summary>
        /// add a object of T to the collection of T
        /// </summary>
        /// <param name="item">a instance of T</param>
        public void Add(T item)
        {
            Items.Add(item);
        }

        /// <summary>
        /// Remove all items from the collection of T
        /// </summary>
        public void Clear()
        {
            Items.Clear();
        }

        /// <summary>
        /// Does contain item of T
        /// </summary>
        /// <param name="item">a instance of T</param>
        /// <returns>result</returns>
        public bool Contains(T item)
        {
            return Items.Contains(item);
        }

        /// <summary>
        /// copy array of T 
        /// </summary>
        /// <param name="array">array</param>
        /// <param name="arrayIndex">start index of array</param>
        public void CopyTo(T[] array, int arrayIndex)
        {
            Items.CopyTo(array, arrayIndex);
        }

        /// <summary>
        /// get the count of T collection
        /// </summary>
        public int Count
        {
            get
            {
                return Items.Count;
            }
        }

        /// <summary>
        /// get the value of property IsReadOnly
        /// </summary>
        public bool IsReadOnly
        {
            get
            {
                return Items.IsReadOnly;
            }
        }

        /// <summary>
        /// remove a item from the collection of T
        /// </summary>
        /// <param name="item">the object of T</param>
        /// <returns>the result of remove</returns>
        public bool Remove(T item)
        {
            Items.Remove(item);
            return true;
        }
        #endregion

        #region IEnumerable<T> Members
        /// <summary>
        /// get the enumerator of T
        /// </summary>
        /// <returns>the enumerator of T</returns>
        public IEnumerator<T> GetEnumerator()
        {
            foreach (object Obj in Items)
            {
                yield return (T)Obj;
            }
        }

        #endregion

        #region IEnumerable Members
        /// <summary>
        /// get the enumerator
        /// </summary>
        /// <returns>the enumerator</returns>
        IEnumerator IEnumerable.GetEnumerator()
        {
            return Items.GetEnumerator();
        }
        #endregion

        #region IList<T> Members
        /// <summary>
        /// get the item index of T
        /// </summary>
        /// <param name="item">a object of T</param>
        /// <returns>the index of T</returns>
        public int IndexOf(T item)
        {

            return Items.IndexOf(item);
        }

        /// <summary>
        /// insert the item into T collection
        /// </summary>
        /// <param name="index">the position of inserting</param>
        /// <param name="item">a object of T</param>
        public void Insert(int index, T item)
        {
            if (index <= Items.Count)
            {
                Items.Insert(index, item);
            }
        }

        /// <summary>
        /// remove a object from collection by index
        /// </summary>
        /// <param name="index">position of collection</param>
        public void RemoveAt(int index)
        {
            if (index < Items.Count)
            {
                Items.RemoveAt(index);
            }
        }

        /// <summary>
        /// get or set the property this
        /// </summary>
        /// <param name="index">the position of collection</param>
        /// <returns>the type of collection</returns>
        public T this[int index]
        {
            get
            {
                if (index >= Items.Count)
                {
                    return default(T);
                }
                return (T)Items[index];
            }
            set
            {
                Items[index] = value;
            }
        }
        #endregion
    } 
}
