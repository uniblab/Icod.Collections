// Copyright 2008, Eric Lippert and shamelessly stolen by Timothy J. Bruce 2020

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

		System.Int32 Height {
			get;
		}

		new IBinarySearchTree<K, V> Add( K key, V value );
		new IBinarySearchTree<K, V> Remove( K key );

		IBinarySearchTree<K, V> Search( K key );

	}

}