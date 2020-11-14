// Copyright 2020, Timothy J. Bruce

namespace Icod.Collections.Immutable {

	[System.Serializable]
	[System.Diagnostics.DebuggerDisplay( "Stack = {Count}" )]
	public sealed class Stack<T> : IStack<T> {

		#region nested classes
		[System.Serializable]
		[System.Diagnostics.DebuggerDisplay( "Stack = {Count}" )]
		private sealed class EmptyStack : IStack<T> {
			private static readonly System.Int32 theHashCode;
			static EmptyStack() {
				theHashCode = typeof( EmptyStack ).AssemblyQualifiedName.GetHashCode();
				unchecked {
					theHashCode += typeof( T ).AssemblyQualifiedName.GetHashCode();
				}
			}
			internal EmptyStack() : base() {
			}
			public System.Boolean IsEmpty {
				get {
					return true;
				}
			}
			public System.Int32 Count {
				get {
					return 0;
				}
			}
			public System.Int64 LongCount {
				get {
					return 0L;
				}
			}
			public T this[ System.Int32 index ] {
				get {
					throw new System.InvalidOperationException( "The stack is empty." );
				}
			}

			public T Peek() {
				throw new System.InvalidOperationException( "The stack is empty." );
			}
			public IStack<T> Pop() {
				throw new System.InvalidOperationException( "The stack is empty." );
			}
			public IStack<T> Push( T value ) {
				return new SingleStack( value );
			}
			public IStack<T> Reverse() {
				return this;
			}
			public IQueue<T> ToQueue() {
				return Queue<T>.Empty;
			}
			public IStack<T> Dup() {
				throw new System.InvalidOperationException( "The stack is empty." );
			}
			public IStack<T> Copy( System.Int32 count ) {
				if ( count < 0 ) {
					throw new System.ArgumentOutOfRangeException( "count", "count parameter may not be negative." );
				} else if ( 0 == count ) {
					return this;
				} else {
					throw new System.ArgumentOutOfRangeException( "count", "count parameter cannot exceed the Count of the stack." );
				}
			}
			public IStack<T> Roll( System.Int32 count, System.Int32 factor ) {
				if ( 0 == factor ) {
					return this;
				} else if ( 0 == count ) {
					return this;
				} else if ( count < 0 ) {
					throw new System.ArgumentOutOfRangeException( "count", "count parameter may not be negative." );
				} else {
					throw new System.ArgumentOutOfRangeException( "count", "count parameter cannot exceed the Count of the stack." );
				}
			}

			public sealed override System.Int32 GetHashCode() {
				return theHashCode;
			}
			public System.Collections.Generic.IEnumerator<T> GetEnumerator() {
				yield break;
			}
			System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() {
				yield break;
			}
		}

		[System.Serializable]
		[System.Diagnostics.DebuggerDisplay( "Stack = {Count}" )]
		private sealed class SingleStack : IStack<T> {
			private static readonly System.Int32 theHashCode;
			private readonly T myValue;
			private readonly System.Int32 myHashCode;
			static SingleStack() {
				theHashCode = typeof( SingleStack ).AssemblyQualifiedName.GetHashCode();
				unchecked {
					theHashCode += typeof( T ).AssemblyQualifiedName.GetHashCode();
				}
			}
			private SingleStack() : base() {
				myHashCode = theHashCode;
			}
			internal SingleStack( T value ) : this() {
				myValue = value;
				if ( !System.Object.ReferenceEquals( value, null ) ) {
					unchecked {
						myHashCode += value.GetHashCode();
					}
				}
			}
			public System.Boolean IsEmpty {
				get {
					return false;
				}
			}
			public System.Int32 Count {
				get {
					return 1;
				}
			}
			public System.Int64 LongCount {
				get {
					return 1L;
				}
			}
			public T this[ System.Int32 index ] {
				get {
					if ( 0 != index ) {
						throw new System.IndexOutOfRangeException();
					} else {
						return myValue;
					}
				}
			}

			public T Peek() {
				return myValue;
			}
			public IStack<T> Pop() {
				return Stack<T>.Empty;
			}
			public IStack<T> Push( T value ) {
				return new Stack<T>( this, value );
			}
			public IStack<T> Reverse() {
				return this;
			}
			public IQueue<T> ToQueue() {
				return Queue<T>.Empty.Enqueue( myValue );
			}

			public sealed override System.Int32 GetHashCode() {
				return myHashCode;
			}

			public IStack<T> Dup() {
				return new Stack<T>( this, myValue );
			}
			public IStack<T> Copy( System.Int32 count )  {
				if ( count < 0 ) {
					throw new System.ArgumentOutOfRangeException( "count", "count parameter may not be negative." );
				} else if ( 0 == count ) {
					return this;
				} else if ( 1 < count ) {
					throw new System.ArgumentOutOfRangeException( "count", "count parameter cannot exceed the Count of the stack." );
				}
				return new Stack<T>( this, myValue );
			}
			public IStack<T> Roll( System.Int32 count, System.Int32 factor ) {
				if ( 0 == factor ) {
					return this;
				} else if ( 0 == count ) {
					return this;
				} else if ( count < 0 ) {
					throw new System.ArgumentOutOfRangeException( "count", "count parameter may not be negative." );
				} else if ( 1 < count ) {
					throw new System.ArgumentOutOfRangeException( "count", "count parameter cannot exceed the Count of the stack." );
				} else {
					return this;
				}
			}

			public System.Collections.Generic.IEnumerator<T> GetEnumerator() {
				yield return myValue;
			}
			System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() {
				yield return myValue;
			}
		}
		#endregion nested classes


		#region fields
		private static readonly System.Int32 theHashCode;
		private static readonly IStack<T> theEmpty;

		private readonly T myValue;
		private readonly IStack<T> myTail;
		private readonly System.Int64 myLongCount;
		private readonly System.Int32 myShortCount;
		private readonly System.Int32 myHashCode;
		#endregion fields


		#region .ctor
		static Stack() {
			theEmpty = new EmptyStack();
			theHashCode = typeof( Stack<T> ).AssemblyQualifiedName.GetHashCode();
			unchecked {
				theHashCode += typeof( T ).AssemblyQualifiedName.GetHashCode();
			}
		}

		private Stack() : base() {
			myHashCode = theHashCode;
		}
		private Stack( IStack<T> tail, T value ) : this() {
			myValue = value;
			myTail = tail ?? Stack<T>.Empty;
			myLongCount = 1L + myTail.LongCount;
			myShortCount = (System.Int32)System.Math.Min( (System.Int64)System.Int32.MaxValue, myLongCount );
			unchecked {
				myHashCode += myTail.GetHashCode();
				if ( !System.Object.ReferenceEquals( value, null ) ) {
					myHashCode += value.GetHashCode();
				}
			}
		}
		#endregion .ctor


		#region properties
		public static IStack<T> Empty {
			get {
				return theEmpty;
			}
		}

		public System.Boolean IsEmpty {
			get {
				return false;
			}
		}
		public System.Int32 Count {
			get {
				return myShortCount;
			}
		}
		public System.Int64 LongCount {
			get {
				return myLongCount;
			}
		}

		public T this[ System.Int32 index ] {
			get {
				if ( ( index < 0 ) || ( myShortCount <= index ) ) {
					throw new System.IndexOutOfRangeException();
				} else if ( 0 == index ) {
					return myValue;
				} else {
					IStack<T> stack = this;
					while ( 0 < index-- ) {
						stack = stack.Pop();
					}
					return stack.Peek();
				}
			}
		}
		#endregion properties


		#region methods
		public T Peek() {
			return myValue;
		}
		public IStack<T> Push( T value ) {
			return new Stack<T>( this, value );
		}
		public IStack<T> Pop() {
			return myTail;
		}

		public System.Collections.Generic.IEnumerator<T> GetEnumerator() {
			IStack<T> probe = this;
			while ( !probe.IsEmpty ) {
				yield return probe.Peek();
				probe = probe.Pop();
			}
		}
		System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() {
			return this.GetEnumerator();
		}

		public IStack<T> Reverse() {
			var output = Stack<T>.Empty;
			IStack<T> probe = this;
			while ( !probe.IsEmpty ) {
				output = output.Push( probe.Peek() );
				probe = probe.Pop();
			}
			return output;
		}

		public IQueue<T> ToQueue() {
			var output = Queue<T>.Empty;
			foreach ( var item in this.Reverse() ) {
				output = output.Enqueue( item );
			}
			return output;
		}

		public IStack<T> Dup() {
			return this.Push( this.Peek() );
		}
		public IStack<T> Copy( System.Int32 count ) {
			if ( count < 0 ) {
				throw new System.ArgumentOutOfRangeException( "count", "count parameter may not be negative." );
			} else if ( 0 == count ) {
				return this;
			} else if ( 1 == count ) {
				return new Stack<T>( this, myValue );
			} else if ( this.Count < count ) {
				throw new System.ArgumentOutOfRangeException( "count", "count parameter cannot exceed the Count of the stack." );
			}
			var buffer = Stack<T>.Empty;
			IStack<T> probe = this;
			while ( !probe.IsEmpty && ( 0 < count-- ) ) {
				buffer = buffer.Push( probe.Peek() );
				probe = probe.Pop();
			}
			IStack<T> output = this;
			foreach ( var t in probe.Reverse() ) {
				output = output.Push( t );
			}
			return output;
		}
		public IStack<T> Roll( System.Int32 count, System.Int32 shift ) {
			if ( 0 == shift ) {
				return this;
			} else if ( 0 == count ) {
				return this;
			} else if ( count < 0 ) {
				throw new System.ArgumentOutOfRangeException( "count", "count parameter may not be negative." );
			} else if ( myShortCount < count ) {
				throw new System.ArgumentOutOfRangeException( "count", "count parameter cannot exceed the Count of the stack." );
			} else if ( ( shift == count ) || ( 0 == ( shift % count ) ) ) {
				return this;
			}

			var buffer = Stack<T>.Empty;
			IStack<T> output = this;
			for ( System.Int32 i = 0; i < count; i++ ) {
				buffer = buffer.Push( output.Peek() );
				output = output.Pop();
			}
			return ( shift < 0 )
				? Roll( buffer, output, count, -shift, 0, ( index, count ) => ( index < count ), index => ++index )
				: Roll( buffer.Reverse(), output, count, shift, count - 1, ( index, count ) => ( 0 <= index ), index => --index )
			;
		}
		#endregion methods


		#region static methods
		private static IStack<T> Roll(
			IStack<T> buffer, IStack<T> tail,
			System.Int32 count, System.Int32 shift,
			System.Int32 start, System.Func<System.Int32, System.Int32, System.Boolean> stop,
			System.Func<System.Int32, System.Int32> next
		) {
			for ( System.Int32 i = start; stop( i, count ); i = next( i ) ) {
				tail = tail.Push( buffer[ ( System.Math.Abs( i + shift ) % count ) ] );
			}
			return tail;
		}
		#endregion static methods

	}

}
