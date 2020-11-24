// Copyright 2008, Eric Lippert
// Copyright 2020, Timothy J. Bruce
// This file is licensed under the terms of the GNU LESSER GENERAL PUBLIC LICENSE, version 2.1, February 1999

namespace Icod.Collections.Immutable {

	public interface IQueue<T> : System.Collections.Generic.IEnumerable<T>, IIsEmpty, ICountable {

		T Peek();

		IQueue<T> Enqueue( T value );
		IQueue<T> Dequeue();

		IQueue<T> Reverse();

		IStack<T> ToStack();

	}

}
