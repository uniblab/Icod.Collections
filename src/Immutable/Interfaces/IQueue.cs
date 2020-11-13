// Copyright 2008, Eric Lippert
// Copyright 2020, Timothy J. Bruce

namespace Icod.Collections.Immutable {

	public interface IQueue<T> : System.Collections.Generic.IEnumerable<T>, IIsEmpty, ICountable {

		T Peek();

		IQueue<T> Enqueue( T value );
		IQueue<T> Dequeue();

		IQueue<T> Reverse();

		IStack<T> ToStack();

	}

}
