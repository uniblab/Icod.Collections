// Copyright 2008, Eric Lippert
// Copyright 2020, Timothy J. Bruce
// This file is licensed under the terms of the GNU LESSER GENERAL PUBLIC LICENSE, version 2.1, February 1999

namespace Icod.Collections.Immutable {

	public interface IStack<T> : System.Collections.Generic.IEnumerable<T>, IIsEmpty, ICountable {

		T this[ System.Int32 index ] {
			get;
		}

		T Peek();
		IStack<T> Push( T value );
		IStack<T> Pop();

		IStack<T> Reverse();

		IQueue<T> ToQueue();


		IStack<T> Dup();
		IStack<T> Copy( System.Int32 count );
		IStack<T> Roll( System.Int32 count, System.Int32 shift );

	}

}
