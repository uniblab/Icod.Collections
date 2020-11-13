// Copyright 2008, Eric Lippert and shamelessly stolen by Timothy J. Bruce 2020

namespace Icod.Collections.Immutable {

	public interface IDeque<T> : IIsEmpty, ICountable {

		T PeekLeft();
		T PeekRight();
		IDeque<T> DequeueLeft();
		IDeque<T> DequeueRight();
		IDeque<T> EnqueueLeft( T value );
		IDeque<T> EnqueueRight( T value );

	}

}