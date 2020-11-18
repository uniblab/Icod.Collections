// Copyright 2008, Eric Lippert
// Copyright 2020, Timothy J. Bruce
// This file is licensed under the terms of the GNU LESSER GENERAL PUBLIC LICENSE, version 2.1, February 1999

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