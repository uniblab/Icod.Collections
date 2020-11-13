// Copyright 2008, Eric Lippert and shamelessly stolen by Timothy J. Bruce 2020

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