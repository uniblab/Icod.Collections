﻿// Copyright 2020 Timothy J. Bruce
// This file is licensed under the terms of the GNU LESSER GENERAL PUBLIC LICENSE, version 2.1, February 1999

using System.Linq;

namespace Icod.Collections.Immutable {

	public static class BinaryTreeHelper {

		public static System.Collections.Generic.IEnumerable<IBinaryTree<V>> PreOrder<V>( this IBinaryTree<V> tree ) {
			if ( ( null == tree ) || tree.IsEmpty ) {
				yield break;
			} else if ( tree.IsLeaf ) {
				yield return tree;
				yield break;
			}

			var stack = Stack<IBinaryTree<V>>.Empty.Push( tree );
			IBinaryTree<V> current;
			IBinaryTree<V> probe;
			while ( !stack.IsEmpty ) {
				current = stack.Peek();
				stack = stack.Pop();
				probe = current.Right;
				if ( !probe.IsEmpty ) {
					stack = stack.Push( probe );
				}
				probe = current.Left;
				if ( !probe.IsEmpty ) {
					stack = stack.Push( probe );
				}
				yield return current;
			}
		}
		public static System.Collections.Generic.IEnumerable<IBinaryTree<V>> Inorder<V>( this IBinaryTree<V> tree ) {
			if ( ( null == tree ) || tree.IsEmpty ) {
				yield break;
			} else if ( tree.IsLeaf ) {
				yield return tree;
				yield break;
			}

			var stack = Stack<IBinaryTree<V>>.Empty;
			for ( var current = tree; !stack.IsEmpty || !current.IsEmpty; current = current.Right ) {
				while ( !current.IsEmpty ) {
					stack = stack.Push( current );
					current = current.Left;
				}
				current = stack.Peek();
				stack = stack.Pop();
				yield return current;
			}
		}
		public static System.Collections.Generic.IEnumerable<IBinaryTree<V>> ReverseInorder<V>( this IBinaryTree<V> tree ) {
			if ( ( null == tree ) || tree.IsEmpty ) {
				yield break;
			} else if ( tree.IsLeaf ) {
				yield return tree;
				yield break;
			}

			var stack = Stack<IBinaryTree<V>>.Empty;
			for ( var current = tree; !stack.IsEmpty || !current.IsEmpty; current = current.Left ) {
				while ( !current.IsEmpty ) {
					stack = stack.Push( current );
					current = current.Right;
				}
				current = stack.Peek();
				stack = stack.Pop();
				yield return current;
			}
		}
		public static System.Collections.Generic.IEnumerable<IBinaryTree<V>> Reverse<V>( this IBinaryTree<V> tree ) {
			return tree.ReverseInorder<V>();
		}
		public static System.Collections.Generic.IEnumerable<IBinaryTree<V>> PostOrder<V>( this IBinaryTree<V> tree ) {
			if ( ( null == tree ) || tree.IsEmpty ) {
				yield break;
			} else if ( tree.IsLeaf ) {
				yield return tree;
				yield break;
			}

			var stack = Stack<IBinaryTree<V>>.Empty.Push( tree );
			var visited = Stack<IBinaryTree<V>>.Empty;
			IBinaryTree<V> current;
			IBinaryTree<V> left;
			IBinaryTree<V> right;
			while ( !stack.IsEmpty ) {
				current = stack.Peek();
				if ( ( !visited.IsEmpty ) && ( visited.Peek() == current ) ) {
					stack = stack.Pop();
					visited = visited.Pop();
					yield return current;
				} else if ( !current.IsLeaf ) {
					visited = visited.Push( current );
					right = current.Right;
					if ( !right.IsEmpty ) {
						stack = stack.Push( right );
					}
					left = current.Left;
					if ( !left.IsEmpty ) {
						stack = stack.Push( left );
					}
				} else {
					stack = stack.Pop();
					yield return current;
				}
			}
		}
		public static System.Collections.Generic.IEnumerable<IBinaryTree<V>> LevelOrder<V>( this IBinaryTree<V> tree ) {
			if ( ( null == tree ) || tree.IsEmpty ) {
				yield break;
			} else if ( tree.IsLeaf ) {
				yield return tree;
				yield break;
			}

			var hold = Queue<IBinaryTree<V>>.Empty.Enqueue( tree );
			IBinaryTree<V> current;
			IBinaryTree<V> probe;
			while ( !hold.IsEmpty ) {
				current = hold.Peek();
				hold = hold.Dequeue();
				probe = current.Left;
				if ( !probe.IsEmpty ) {
					hold = hold.Enqueue( probe );
				}
				probe = current.Right;
				if ( !probe.IsEmpty ) {
					hold = hold.Enqueue( probe );
				}
				yield return current;
			}
		}


		public static System.Collections.Generic.IEnumerable<IBinarySearchTree<K, V>> PreOrder<K, V>( this IBinarySearchTree<K, V> tree ) where K : System.IComparable<K> {
			if ( ( null == tree ) || tree.IsEmpty ) {
				yield break;
			} else if ( tree.IsLeaf ) {
				yield return tree;
				yield break;
			}

			var stack = Stack<IBinarySearchTree<K, V>>.Empty.Push( tree );
			IBinarySearchTree<K, V> current;
			IBinarySearchTree<K, V> probe;
			while ( !stack.IsEmpty ) {
				current = stack.Peek();
				stack = stack.Pop();
				probe = current.Right;
				if ( !probe.IsEmpty ) {
					stack = stack.Push( probe );
				}
				probe = current.Left;
				if ( !probe.IsEmpty ) {
					stack = stack.Push( probe );
				}
				yield return current;
			}
		}
		public static System.Collections.Generic.IEnumerable<IBinarySearchTree<K, V>> Inorder<K, V>( this IBinarySearchTree<K, V> tree ) where K : System.IComparable<K> {
			if ( ( null == tree ) || tree.IsEmpty ) {
				yield break;
			} else if ( tree.IsLeaf ) {
				yield return tree;
				yield break;
			}

			var stack = Stack<IBinarySearchTree<K, V>>.Empty;
			for ( var current = tree; !stack.IsEmpty || !current.IsEmpty; current = current.Right ) {
				while ( !current.IsEmpty ) {
					stack = stack.Push( current );
					current = current.Left;
				}
				current = stack.Peek();
				stack = stack.Pop();
				yield return current;
			}
		}
		public static System.Collections.Generic.IEnumerable<IBinarySearchTree<K, V>> ReverseInorder<K, V>( this IBinarySearchTree<K, V> tree ) where K : System.IComparable<K> {
			if ( ( null == tree ) || tree.IsEmpty ) {
				yield break;
			} else if ( tree.IsLeaf ) {
				yield return tree;
				yield break;
			}

			var stack = Stack<IBinarySearchTree<K, V>>.Empty;
			for ( var current = tree; !stack.IsEmpty || !current.IsEmpty; current = current.Left ) {
				while ( !current.IsEmpty ) {
					stack = stack.Push( current );
					current = current.Right;
				}
				current = stack.Peek();
				stack = stack.Pop();
				yield return current;
			}
		}
		public static System.Collections.Generic.IEnumerable<IBinarySearchTree<K, V>> Reverse<K, V>( this IBinarySearchTree<K, V> tree ) where K : System.IComparable<K> {
			return tree.ReverseInorder<K, V>();
		}
		public static System.Collections.Generic.IEnumerable<IBinarySearchTree<K, V>> PostOrder<K, V>( this IBinarySearchTree<K, V> tree ) where K : System.IComparable<K> {
			if ( ( null == tree ) || tree.IsEmpty ) {
				yield break;
			} else if ( tree.IsLeaf ) {
				yield return tree;
				yield break;
			}

			var stack = Stack<IBinarySearchTree<K, V>>.Empty.Push( tree );
			var visited = Stack<IBinarySearchTree<K, V>>.Empty;
			IBinarySearchTree<K, V> current;
			IBinarySearchTree<K, V> left;
			IBinarySearchTree<K, V> right;
			while ( !stack.IsEmpty ) {
				current = stack.Peek();
				if ( ( !visited.IsEmpty ) && ( visited.Peek() == current ) ) {
					stack = stack.Pop();
					visited = visited.Pop();
					yield return current;
				} else if ( !current.IsLeaf ) {
					visited = visited.Push( current );
					right = current.Right;
					if ( !right.IsEmpty ) {
						stack = stack.Push( right );
					}
					left = current.Left;
					if ( !left.IsEmpty ) {
						stack = stack.Push( left );
					}
				} else {
					stack = stack.Pop();
					yield return current;
				}
			}
		}
		public static System.Collections.Generic.IEnumerable<IBinarySearchTree<K, V>> LevelOrder<K, V>( this IBinarySearchTree<K, V> tree ) where K : System.IComparable<K> {
			if ( ( null == tree ) || tree.IsEmpty ) {
				yield break;
			} else if ( tree.IsLeaf ) {
				yield return tree;
				yield break;
			}

			var hold = Queue<IBinarySearchTree<K, V>>.Empty.Enqueue( tree );
			IBinarySearchTree<K, V> current;
			IBinarySearchTree<K, V> probe;
			while ( !hold.IsEmpty ) {
				current = hold.Peek();
				hold = hold.Dequeue();
				probe = current.Left;
				if ( !probe.IsEmpty ) {
					hold = hold.Enqueue( probe );
				}
				probe = current.Right;
				if ( !probe.IsEmpty ) {
					hold = hold.Enqueue( probe );
				}
				yield return current;
			}
		}

	}

}