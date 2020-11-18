// Copyright 2008, Eric Lippert
// Copyright 2020, Timothy J. Bruce
// This file is licensed under the terms of the GNU LESSER GENERAL PUBLIC LICENSE, version 2.1, February 1999

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

		System.Collections.Generic.IEnumerable<IBinaryTree<V>> Enumerate();

	}

}