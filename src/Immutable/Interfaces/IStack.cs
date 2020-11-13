// Copyright 2007, Eric Lippert and shamelessly stolen by Timothy J. Bruce 2020
namespace Icod.Collections.Immutable {

	public interface IStack<T> : System.Collections.Generic.IEnumerable<T>, IIsEmpty, ICountable {

		T Peek();
		IStack<T> Push( T value );
		IStack<T> Pop();

		IStack<T> Reverse();

		IQueue<T> ToQueue();

	}

}
