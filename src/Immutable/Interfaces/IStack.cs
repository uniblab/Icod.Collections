// Copyright 2008, Eric Lippert
// Copyright 2020, Timothy J. Bruce

namespace Icod.Collections.Immutable {

	public interface IStack<T> : System.Collections.Generic.IEnumerable<T>, IIsEmpty, ICountable {

		T Peek();
		IStack<T> Push( T value );
		IStack<T> Pop();

		IStack<T> Reverse();

		IQueue<T> ToQueue();

	}

}
