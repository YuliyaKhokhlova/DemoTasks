using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace ComplexKeyCollection
{
    class ComplexKey<TId, TName>
    {
        public TId Id { get; }
        public TName Name { get; }

        public ComplexKey(TId idValue, TName nameValue)
        {
            Id = idValue;
            Name = nameValue;
        }

        public override bool Equals(Object obj)
        {
            if (!(obj is ComplexKey<TId, TName>))
            {
                return base.Equals(obj);
            }

            ComplexKey<TId, TName> key = obj as ComplexKey<TId, TName>;
            return key.Id.Equals(Id) && key.Name.Equals(Name);
        }

        public override int GetHashCode()
        {
            return Id.GetHashCode() + Name.GetHashCode();
        }
    }

    class ComplexKeyCollection<TId, TName, TValue> : IDictionary<ComplexKey<TId, TName>, TValue> 
    {
        private Dictionary<ComplexKey<TId, TName>, TValue> collection;

        public ComplexKeyCollection()
        {
            collection = new Dictionary<ComplexKey<TId, TName>, TValue>();
        }

        public bool ContainsKey(ComplexKey<TId, TName> key)
        {
            return ((IDictionary<ComplexKey<TId, TName>, TValue>)collection).ContainsKey(key);
        }

        public void Add(ComplexKey<TId, TName> key, TValue value)
        {
            collection.Add(key, value);
        }

        public void Add(TId id, TName name, TValue value)
        {
            ComplexKey<TId, TName> key = new ComplexKey<TId, TName>(id, name);
            collection.Add(key, value);
        }

        public bool Remove(ComplexKey<TId, TName> key)
        {
            return ((IDictionary<ComplexKey<TId, TName>, TValue>)collection).Remove(key);
        }

        public bool Remove(TId id, TName name)
        {
            return ((IDictionary<ComplexKey<TId, TName>, TValue>)collection).Remove(new ComplexKey<TId, TName>(id, name));
        }

        public bool TryGetValue(ComplexKey<TId, TName> key, out TValue value)
        {
            return ((IDictionary<ComplexKey<TId, TName>, TValue>)collection).TryGetValue(key, out value);
        }

        public void Add(KeyValuePair<ComplexKey<TId, TName>, TValue> item)
        {
            ((IDictionary<ComplexKey<TId, TName>, TValue>)collection).Add(item);
        }

        public void Clear()
        {
            ((IDictionary<ComplexKey<TId, TName>, TValue>)collection).Clear();
        }

        public bool Contains(KeyValuePair<ComplexKey<TId, TName>, TValue> item)
        {
            return ((IDictionary<ComplexKey<TId, TName>, TValue>)collection).Contains(item);
        }

        public void CopyTo(KeyValuePair<ComplexKey<TId, TName>, TValue>[] array, int arrayIndex)
        {
            ((IDictionary<ComplexKey<TId, TName>, TValue>)collection).CopyTo(array, arrayIndex);
        }

        public bool Remove(KeyValuePair<ComplexKey<TId, TName>, TValue> item)
        {
            return ((IDictionary<ComplexKey<TId, TName>, TValue>)collection).Remove(item);
        }

        public IEnumerator<KeyValuePair<ComplexKey<TId, TName>, TValue>> GetEnumerator()
        {
            return ((IDictionary<ComplexKey<TId, TName>, TValue>)collection).GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return ((IDictionary<ComplexKey<TId, TName>, TValue>)collection).GetEnumerator();
        }

        public ICollection<TValue> Values
        {
            get
            {
                return collection.Values;
            }
        }

        public IEnumerable<TValue> ValuesWithName(TName name)
        {
            return collection.Where(e => e.Key.Name.Equals(name)).Select(e => e.Value);
        }

        public IEnumerable<TValue> ValuesWithId(TId id)
        {
            return collection.Where(e => e.Key.Id.Equals(id)).Select(e => e.Value);
        }

        public ICollection<ComplexKey<TId, TName>> Keys
        {
            get
            {
                return collection.Keys;
            }
        }

        public IEnumerable<TId> IDs
        {
            get
            {
                return collection.Keys.Select(e => e.Id);
            }
        }

        public IEnumerable<TName> Names
        {
            get
            {
                return collection.Keys.Select(e => e.Name);
            }
        }

        public int Count
        {
            get
            {
                return ((IDictionary<ComplexKey<TId, TName>, TValue>)collection).Count;
            }
        }

        public bool IsReadOnly
        {
            get
            {
                return ((IDictionary<ComplexKey<TId, TName>, TValue>)collection).IsReadOnly;
            }
        }

        public TValue this[ComplexKey<TId, TName> key]
        {
            get
            {
                return ((IDictionary<ComplexKey<TId, TName>, TValue>)collection)[key];
            }

            set
            {
                ((IDictionary<ComplexKey<TId, TName>, TValue>)collection)[key] = value;
            }
        }

        public TValue this[TId id, TName name]
        {
            get
            {
                return collection[new ComplexKey<TId, TName>(id, name)];
            }
            set
            {
                collection[new ComplexKey<TId, TName>(id, name)] = value;
            }
        }
    }
}
