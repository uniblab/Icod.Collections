// Copyright 2008, Eric Lippert
// Copyright 2020, Timothy J. Bruce

namespace Icod.Collections.Immutable {

	public interface IMap<K, V> where K : System.IComparable<K> {

		System.Collections.Generic.IEnumerable<K> Keys {
			get;
		}
		System.Collections.Generic.IEnumerable<V> Values {
			get;
		}
		System.Collections.Generic.IEnumerable<System.Collections.Generic.KeyValuePair<K, V>> Pairs {
			get;
		}

		System.Boolean Contains( K key );
		V Lookup( K key );
		IMap<K, V> Add( K key, V value );
		IMap<K, V> Remove( K key );

	}

}