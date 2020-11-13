// Copyright 2007, Eric Lippert and shamelessly stolen by Timothy J. Bruce 2020

namespace Icod.Collections.Immutable {

	public interface IQueue<T> : System.Collections.Generic.IEnumerable<T>, IIsEmpty, ICountable {

		T Peek();

		IQueue<T> Enqueue( T value );
		IQueue<T> Dequeue();

		IQueue<T> Reverse();

		IStack<T> ToStack();

	}

}
