// Copyright 2020 Timothy J. Bruce

using System.Linq;

namespace Icod.Collections.Immutable {

	[System.Serializable]
	public sealed class BinaryTree<V> : IBinaryTree<V> {

		#region nested classes
		[System.Serializable]
		private sealed class EmptyBinaryTree : IBinaryTree<V> {
			private static readonly System.Int32 theHashCode;
			static EmptyBinaryTree() {
				theHashCode = typeof( EmptyBinaryTree ).AssemblyQualifiedName.GetHashCode();
				unchecked {
					theHashCode += typeof( V ).AssemblyQualifiedName.GetHashCode();
				}
			}
			internal EmptyBinaryTree() : base() {
			}
			public sealed override System.Int32 GetHashCode() {
				return theHashCode;
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
			public IBinaryTree<V> Left {
				get {
					return this;
				}
			}
			public IBinaryTree<V> Right {
				get {
					return this;
				}
			}
			public System.Collections.Generic.IEnumerable<IBinaryTree<V>> Enumerate() {
				return this.Inorder();
			}
		}
		#endregion nested classes


		#region fields
		private static readonly System.Int32 theHashCode;
		private static readonly IBinaryTree<V> theEmpty;

		private readonly System.Int32 myHashCode;
		private readonly IBinaryTree<V> myLeft;
		private readonly V myValue;
		private readonly IBinaryTree<V> myRight;
		private readonly System.Boolean myIsLeaf;
		#endregion fields


		#region .ctor
		static BinaryTree() {
			theEmpty = new EmptyBinaryTree();
			theHashCode = typeof( BinaryTree<V> ).AssemblyQualifiedName.GetHashCode();
			unchecked {
				theHashCode += typeof( V ).AssemblyQualifiedName.GetHashCode();
			}
		}

		private BinaryTree() : base() {
			myHashCode = theHashCode;
		}
		public BinaryTree( IBinaryTree<V> left, V value, IBinaryTree<V> right ) : this() {
			myLeft = left ?? theEmpty;
			myValue = value;
			myRight = right ?? theEmpty;
			myIsLeaf = myLeft.IsEmpty && myRight.IsEmpty;
			unchecked {
				myHashCode += myLeft.GetHashCode();
				if ( !System.Object.ReferenceEquals( null, value ) ) {
					myHashCode += value.GetHashCode();
				}
				myHashCode += myRight.GetHashCode();
			}
		}
		public BinaryTree( V value ) : this( BinaryTree<V>.Empty, value, BinaryTree<V>.Empty ) {
		}
		#endregion .ctor


		#region properties
		public static IBinaryTree<V> Empty {
			get {
				return theEmpty;
			}
		}

		public System.Boolean IsEmpty {
			get {
				return false;
			}
		}

		public V Value {
			get {
				return myValue;
			}
		}
		public IBinaryTree<V> Left {
			get {
				return myLeft;
			}
		}
		public IBinaryTree<V> Right {
			get {
				return myRight;
			}
		}
		public System.Boolean IsLeaf {
			get {
				return myIsLeaf;
			}
		}
		#endregion properties


		#region methods
		public sealed override System.Int32 GetHashCode() {
			return myHashCode;
		}

		public System.Collections.Generic.IEnumerable<IBinaryTree<V>> Enumerate() {
			return this.Inorder();
		}
		#endregion methods

	}

}