// Copyright 2008, Eric Lippert
// Copyright 2020, Timothy J. Bruce
// This file is licensed under the terms of the GNU LESSER GENERAL PUBLIC LICENSE, version 2.1, February 1999

namespace Icod.Collections.Immutable {

	public interface IBinarySearchTree<K, V> : IBinaryTree<V>, IMap<K, V> where K : System.IComparable<K> {

		K Key {
			get;
		}

		new IBinarySearchTree<K, V> Left {
			get;
		}
		new IBinarySearchTree<K, V> Right {
			get;
		}
		IBinarySearchTree<K, V> Max {
			get;
		}
		IBinarySearchTree<K, V> Min {
			get;
		}

		System.Int32 Height {
			get;
		}

		new IBinarySearchTree<K, V> Add( K key, V value );
		new IBinarySearchTree<K, V> Remove( K key );

		IBinarySearchTree<K, V> Search( K key );

		new System.Collections.Generic.IEnumerable<IBinarySearchTree<K, V>> Enumerate();

	}

}