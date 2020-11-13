// Copyright 2020 Timothy J. Bruce

using System.Linq;

namespace Icod.Collections.Immutable {

	[System.Serializable]
	public sealed class AvlTree<K, V> : IBinarySearchTree<K, V> where K : System.IComparable<K> {

		#region nested classes
		[System.Serializable]
		private sealed class EmptyAvlTree : IBinarySearchTree<K, V> {
			private static readonly System.Int32 theHashCode;
			static EmptyAvlTree() {
				theHashCode = typeof( EmptyAvlTree ).AssemblyQualifiedName.GetHashCode();
				unchecked {
					theHashCode += typeof( V ).AssemblyQualifiedName.GetHashCode();
				}
			}
			internal EmptyAvlTree() : base() {
			}
			public sealed override System.Int32 GetHashCode() {
				return theHashCode;
			}

			public System.Collections.Generic.IEnumerable<K> Keys {
				get {
					yield break;
				}
			}
			public System.Collections.Generic.IEnumerable<V> Values {
				get {
					yield break;
				}
			}
			public System.Collections.Generic.IEnumerable<System.Collections.Generic.KeyValuePair<K, V>> Pairs {
				get {
					yield break;
				}
			}
			public System.Boolean Contains( K key ) {
				return false;
			}
			public V Lookup( K key ) {
				throw new System.InvalidOperationException( "Tree is empty.", new System.Collections.Generic.KeyNotFoundException() );
			}
			IMap<K, V> IMap<K, V>.Add( K key, V value ) {
				return this.Add( key, value );
			}
			IMap<K, V> IMap<K, V>.Remove( K key ) {
				return this.Remove( key );
			}

			public System.Boolean IsEmpty {
				get {
					return true;
				}
			}
			public System.Boolean IsLeaf {
				get {
					return false;
				}
			}

			public V Value {
				get {
					throw new System.InvalidOperationException( "Tree is empty." );
				}
			}
			IBinaryTree<V> IBinaryTree<V>.Left {
				get {
					return this;
				}
			}
			IBinaryTree<V> IBinaryTree<V>.Right {
				get {
					return this;
				}
			}

			public K Key {
				get {
					throw new System.InvalidOperationException( "Tree is empty." );
				}
			}
			public IBinarySearchTree<K, V> Left {
				get {
					return this;
				}
			}
			public IBinarySearchTree<K, V> Right {
				get {
					return this;
				}
			}
			public System.Int32 Height {
				get {
					return 0;
				}
			}

			public IBinarySearchTree<K, V> Search( K key ) {
				return this;
			}

			public IBinarySearchTree<K, V> Add( K key, V value ) {
				return new AvlTree<K, V>( key, value );
			}
			public IBinarySearchTree<K, V> Remove( K key ) {
				throw new System.InvalidOperationException( "Tree is empty." );
			}
		}
		#endregion nested classes


		#region fields
		private static readonly System.Int32 theHashCode;
		private static readonly IBinarySearchTree<K, V> theEmpty;

		private readonly System.Int32 myHashCode;
		private readonly IBinarySearchTree<K, V> myLeft;
		private readonly K myKey;
		private readonly V myValue;
		private readonly IBinarySearchTree<K, V> myRight;
		private readonly System.Boolean myIsLeaf;
		private readonly System.Int32 myHeight;
		#endregion fields


		#region .ctor
		static AvlTree() {
			theEmpty = new EmptyAvlTree();
			theHashCode = typeof( AvlTree<K, V> ).AssemblyQualifiedName.GetHashCode();
			unchecked {
				theHashCode += typeof( K ).AssemblyQualifiedName.GetHashCode();
				theHashCode += typeof( V ).AssemblyQualifiedName.GetHashCode();
			}
		}

		private AvlTree() : base() {
			myHashCode = theHashCode;
		}
		private AvlTree( IBinarySearchTree<K, V> left, K key, V value, IBinarySearchTree<K, V> right ) : this() {
			myLeft = left;
			myKey = key;
			myValue = value;
			myRight = right;
			myIsLeaf = myLeft.IsEmpty && myRight.IsEmpty;
			unchecked {
				if ( !System.Object.ReferenceEquals( null, left ) ) {
					myHashCode += left.GetHashCode();
				}
				if ( !System.Object.ReferenceEquals( null, key ) ) {
					myHashCode += key.GetHashCode();
				}
				if ( !System.Object.ReferenceEquals( null, value ) ) {
					myHashCode += value.GetHashCode();
				}
				if ( !System.Object.ReferenceEquals( null, right ) ) {
					myHashCode += right.GetHashCode();
				}
			}
			myHeight = 1 + System.Math.Max( myLeft.Height, myRight.Height );
		}
		private AvlTree( K key, V value ) : this( AvlTree<K, V>.Empty, key, value, AvlTree<K, V>.Empty ) {
		}
		#endregion .ctor


		#region properties
		public static IBinarySearchTree<K, V> Empty {
			get {
				return theEmpty;
			}
		}

		public System.Collections.Generic.IEnumerable<K> Keys {
			get {
				return this.Inorder<K, V>().Select(
					x => x.Key
				);
			}
		}
		public System.Collections.Generic.IEnumerable<V> Values {
			get {
				return this.Inorder<K, V>().Select(
					x => x.Value
				);
			}
		}
		public System.Collections.Generic.IEnumerable<System.Collections.Generic.KeyValuePair<K, V>> Pairs {
			get {
				return this.Inorder<K, V>().Select(
					x => new System.Collections.Generic.KeyValuePair<K, V>( x.Key, x.Value )
				);
			}
		}

		public System.Boolean IsEmpty {
			get {
				return false;
			}
		}
		public System.Boolean IsLeaf {
			get {
				return myIsLeaf;
			}
		}

		public V Value {
			get {
				return myValue;
			}
		}

		IBinaryTree<V> IBinaryTree<V>.Left {
			get {
				return this.Left;
			}
		}
		IBinaryTree<V> IBinaryTree<V>.Right {
			get {
				return this.Right;
			}
		}

		public K Key {
			get {
				return myKey;
			}
		}
		public IBinarySearchTree<K, V> Left {
			get {
				return myLeft;
			}
		}
		public IBinarySearchTree<K, V> Right {
			get {
				return myRight;
			}
		}
		public System.Int32 Height {
			get {
				return myHeight;
			}
		}
		#endregion properties


		#region methods
		public System.Boolean Contains( K key ) {
			return !this.Search( key ).IsEmpty;
		}
		IMap<K, V> IMap<K, V>.Add( K key, V value ) {
			return this.Add( key, value );
		}
		IMap<K, V> IMap<K, V>.Remove( K key ) {
			return this.Remove( key );
		}
		public V Lookup( K key ) {
			var tree = this.Search( key );
			return ( tree.IsEmpty )
				? throw new System.Collections.Generic.KeyNotFoundException()
				: tree.Value
			;
		}

		public IBinarySearchTree<K, V> Add( K key, V value ) {
			IBinarySearchTree<K, V> current = this;
			var c = key.CompareTo( current.Key );
			var stack = Stack<Pair<IBinarySearchTree<K, V>, System.Int32>>.Empty.Push( new Pair<IBinarySearchTree<K, V>, System.Int32>( current, c ) );
			while ( ( 0 != c ) && !current.IsEmpty ) {
				if ( 0 < c ) {
					current = current.Right;
				} else {
					current = current.Left;
				}
				if ( !current.IsEmpty ) {
					c = key.CompareTo( current.Key );
					stack = stack.Push( new Pair<IBinarySearchTree<K, V>, System.Int32>( current, c ) );
				}
			}
			if ( 0 == c ) {
				throw new System.ArgumentException( "A node with the same key already exists in the tree.", "key" );
			}
			var add = new AvlTree<K, V>( key, value );
			if ( 0 < c ) {
				current = new AvlTree<K, V>( current.Left, current.Key, current.Value, add );
			} else {
				current = new AvlTree<K, V>( add, current.Key, current.Value, current.Right );
			}
			stack = stack.Pop().Push( new Pair<IBinarySearchTree<K, V>, System.Int32>( current, c ) );
			return this.RebuildFromStackFrame( stack );
		}
		public IBinarySearchTree<K, V> Remove( K key ) {
			IBinarySearchTree<K, V> current = this;
			var c = key.CompareTo( current.Key );
			var stack = Stack<Pair<IBinarySearchTree<K, V>, System.Int32>>.Empty.Push( new Pair<IBinarySearchTree<K, V>, System.Int32>( current, c ) );
			while ( ( 0 != c ) && !current.IsEmpty ) {
				if ( 0 < c ) {
					current = current.Right;
				} else {
					current = current.Left;
				}
				if ( !current.IsEmpty ) {
					c = key.CompareTo( current.Key );
					stack = stack.Push( new Pair<IBinarySearchTree<K, V>, System.Int32>( current, c ) );
				}
			}
			if ( current.IsEmpty ) {
				return this;
			}
			stack = RemoveNodeFromStackFrame( stack );
			return this.RebuildFromStackFrame( stack );
		}
		private IStack<Pair<IBinarySearchTree<K, V>, System.Int32>> RemoveNodeFromStackFrame( IStack<Pair<IBinarySearchTree<K, V>, System.Int32>> stack ) {
			var frame = stack.Peek();
			var current = frame.First;
			if ( current.IsLeaf ) {
				stack = stack.Pop().Push( new Pair<IBinarySearchTree<K, V>, System.Int32>( AvlTree<K, V>.Empty, frame.Second ) );
			} else if ( current.Right.IsEmpty ) {
				stack = stack.Pop().Push( new Pair<IBinarySearchTree<K, V>, System.Int32>( current.Left, frame.Second ) );
			} else if ( current.Left.IsEmpty ) {
				stack = stack.Pop().Push( new Pair<IBinarySearchTree<K, V>, System.Int32>( current.Right, frame.Second ) );
			} else {
				if ( !current.Left.Right.IsEmpty ) {
					stack = stack.Pop().Push( new Pair<IBinarySearchTree<K, V>, System.Int32>(
						new AvlTree<K, V>( current.Left.Left, current.Left.Key, current.Left.Value, current.Right ),
						frame.Second
					) );
				} else if ( !current.Right.Left.IsEmpty ) {
					stack = stack.Pop().Push( new Pair<IBinarySearchTree<K, V>, System.Int32>(
						new AvlTree<K, V>( current.Left, current.Right.Key, current.Right.Value, current.Right.Right ),
						frame.Second
					) );
				} else {
					var right = current.Right;
					while ( !right.Left.IsEmpty ) {
						right = RotateRight( right );
						right = new AvlTree<K, V>( right.Left, right.Key, right.Value, BalanceTree( right.Right ) );
					}
					stack = stack.Pop().Push( new Pair<IBinarySearchTree<K, V>, System.Int32>( right, frame.Second ) );
				}
			}
			return stack;
		}
		private IBinarySearchTree<K, V> RebuildFromStackFrame( IStack<Pair<IBinarySearchTree<K, V>, System.Int32>> stack ) {
			Pair<IBinarySearchTree<K, V>, System.Int32> child;
			Pair<IBinarySearchTree<K, V>, System.Int32> parent;
			IBinarySearchTree<K, V> probe;
			IBinarySearchTree<K, V> result;
			System.Int32 c;
			while ( 1 < stack.Count ) {
				child = stack.Peek();
				stack = stack.Pop();
				parent = stack.Peek();
				stack = stack.Pop();
				probe = parent.First;
				c = parent.Second;
				if ( 0 < c ) {
					result = new AvlTree<K, V>( probe.Left, probe.Key, probe.Value, child.First );
				} else {
					result = new AvlTree<K, V>( child.First, probe.Key, probe.Value, probe.Right );
				}
				stack = stack.Push( new Pair<IBinarySearchTree<K, V>, System.Int32>( BalanceTree( result ), c ) );
			}
			return stack.Peek().First;
		}

		public IBinarySearchTree<K, V> Search( K key ) {
			IBinarySearchTree<K, V> current = this;
			var c = key.CompareTo( current.Key );
			while ( ( 0 != c ) && !current.IsEmpty ) {
				if ( 0 < c ) {
					current = current.Right;
				} else {
					current = current.Left;
				}
				if ( !current.IsEmpty ) {
					c = key.CompareTo( current.Key );
				}
			}
			return current;
		}
		#endregion methods


		#region static methods
		private static IBinarySearchTree<K, V> RotateLeft( IBinarySearchTree<K, V> tree ) {
			var right = tree.Right;
			if ( right.IsEmpty ) {
				return tree;
			}
			return new AvlTree<K, V>(
				new AvlTree<K, V>( tree.Left, tree.Key, tree.Value, right.Left ),
				right.Key, right.Value,
				right.Right
			);
		}
		private static IBinarySearchTree<K, V> RotateRight( IBinarySearchTree<K, V> tree ) {
			var left = tree.Left;
			if ( left.IsEmpty ) {
				return tree;
			}
			return new AvlTree<K, V>(
				left.Left,
				left.Key, left.Value,
				new AvlTree<K, V>( left.Right, tree.Key, tree.Value, tree.Right )
			);
		}
		private static IBinarySearchTree<K, V> RotateLeftLeft( IBinarySearchTree<K, V> tree ) {
			var right = tree.Right;
			if ( right.IsEmpty ) {
				return tree;
			}
			return RotateLeft( new AvlTree<K, V>(
				tree.Left,
				tree.Key, tree.Value,
				RotateRight( right )
			) );
		}
		private static IBinarySearchTree<K, V> RotateRightRight( IBinarySearchTree<K, V> tree ) {
			var left = tree.Left;
			if ( left.IsEmpty ) {
				return tree;
			}
			return RotateRight( new AvlTree<K, V>(
				RotateLeft( left ),
				tree.Key, tree.Value,
				tree.Right
			) );
		}


		public static System.Int32 GetBalanceFactor( IBinarySearchTree<K, V> tree ) {
			return tree.IsEmpty
				? 0
				: tree.Right.Height - tree.Left.Height
			;
		}
		public static System.Boolean IsRightHeavy( IBinarySearchTree<K, V> tree ) {
			return 2 <= GetBalanceFactor( tree );
		}
		public static System.Boolean IsLeftHeavy( IBinarySearchTree<K, V> tree ) {
			return GetBalanceFactor( tree ) <= -2;
		}

		private static IBinarySearchTree<K, V> BalanceTree( IBinarySearchTree<K, V> tree ) {
			IBinarySearchTree<K, V> output = tree;
			if ( IsRightHeavy( tree ) ) {
				if ( IsLeftHeavy( tree.Right ) ) {
					output = RotateLeftLeft( tree );
				} else {
					output = RotateLeft( tree );
				}
			} else if ( IsLeftHeavy( tree ) ) {
				if ( IsRightHeavy( tree.Left ) ) {
					output = RotateRightRight( tree );
				} else {
					output = RotateRight( tree );
				}
			}
			return output;
		}
		#endregion static methods

	}

}