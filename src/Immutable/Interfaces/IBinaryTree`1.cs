// Copyright 2008, Eric Lippert and shamelessly stolen by Timothy J. Bruce 2020

namespace Icod.Collections.Immutable {

	public interface IBinaryTree<V> : IIsEmpty, IIsLeaf {

		V Value {
			get;
		}
		IBinaryTree<V> Left {
			get;
		}
		IBinaryTree<V> Right {
			get;
		}

	}

}