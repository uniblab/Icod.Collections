// Copyright 2020, Timothy J. Bruce
// This file is licensed under the terms of the GNU LESSER GENERAL PUBLIC LICENSE, version 2.1, February 1999

namespace Icod.Collections.Immutable {

	[System.Serializable]
	[System.Diagnostics.DebuggerDisplay( "Deque = {Count}" )]

	public sealed class Deque<T> : IDeque<T> {

		#region nested classes
		[System.Serializable]
		private abstract class Dequelette {
			public abstract System.Int32 Capacity {
				get;
			}
			public virtual System.Boolean IsFull {
				get {
					return false;
				}
			}
			public abstract T PeekLeft();
			public abstract T PeekRight();
			public abstract Dequelette EnqueueLeft( T value );
			public abstract Dequelette EnqueueRight( T value );
			public abstract Dequelette DequeueLeft();
			public abstract Dequelette DequeueRight();

		}
		[System.Serializable]
		private sealed class One : Dequelette {
			private static readonly System.Int32 theHashCode;
			private readonly T myOne;
			private readonly System.Int32 myHashCode;

			static One() {
				theHashCode = typeof( One ).AssemblyQualifiedName.GetHashCode();
				unchecked {
					theHashCode += typeof( T ).AssemblyQualifiedName.GetHashCode();
				}
			}
			private One() : base() {
				myHashCode = theHashCode;
			}
			internal One( T one ) : this() {
				myOne = one;
				unchecked {
					if ( !System.Object.ReferenceEquals( one, null ) ) {
						myHashCode += one.GetHashCode();
					}
				}
			}
			public sealed override System.Int32 GetHashCode() {
				return myHashCode;
			}

			public override System.Int32 Capacity {
				get {
					return 1;
				}
			}
			public override T PeekLeft() {
				return myOne;
			}
			public override T PeekRight() {
				return myOne;
			}
			public override Dequelette EnqueueLeft( T value ) {
				return new Two( value, myOne );
			}
			public override Dequelette EnqueueRight( T value ) {
				return new Two( myOne, value );
			}
			public override Dequelette DequeueLeft() {
				throw new System.InvalidOperationException( "Not possible." );
			}
			public override Dequelette DequeueRight() {
				throw new System.InvalidOperationException( "Not possible." );
			}
		}
		[System.Serializable]
		private sealed class Two : Dequelette {
			private static readonly System.Int32 theHashCode;
			private readonly T myOne;
			private readonly T myTwo;
			private readonly System.Int32 myHashCode;

			static Two() {
				theHashCode = typeof( Two ).AssemblyQualifiedName.GetHashCode();
				unchecked {
					theHashCode += typeof( T ).AssemblyQualifiedName.GetHashCode();
				}
			}
			private Two() : base() {
				myHashCode = theHashCode;
			}
			internal Two( T one, T two ) : this() {
				myOne = one;
				myTwo = two;
				unchecked {
					if ( !System.Object.ReferenceEquals( one, null ) ) {
						myHashCode += one.GetHashCode();
					}
					if ( !System.Object.ReferenceEquals( two, null ) ) {
						myHashCode += two.GetHashCode();
					}
				}
			}
			public sealed override System.Int32 GetHashCode() {
				return myHashCode;
			}

			public override System.Int32 Capacity {
				get {
					return 2;
				}
			}
			public override T PeekLeft() {
				return myOne;
			}
			public override T PeekRight() {
				return myTwo;
			}
			public override Dequelette EnqueueLeft( T value ) {
				return new Three( value, myOne, myTwo );
			}
			public override Dequelette EnqueueRight( T value ) {
				return new Three( myOne, myTwo, value );
			}
			public override Dequelette DequeueLeft() {
				return new One( myTwo );
			}
			public override Dequelette DequeueRight() {
				return new One( myOne );
			}
		}
		[System.Serializable]
		private sealed class Three : Dequelette {
			private static readonly System.Int32 theHashCode;
			private readonly T myOne;
			private readonly T myTwo;
			private readonly T myThree;
			private readonly System.Int32 myHashCode;

			static Three() {
				theHashCode = typeof( Three ).AssemblyQualifiedName.GetHashCode();
				unchecked {
					theHashCode += typeof( T ).AssemblyQualifiedName.GetHashCode();
				}
			}
			private Three() : base() {
				myHashCode = theHashCode;
			}
			internal Three( T one, T two, T three ) : this() {
				myOne = one;
				myTwo = two;
				myThree = three;
				unchecked {
					if ( !System.Object.ReferenceEquals( one, null ) ) {
						myHashCode += one.GetHashCode();
					}
					if ( !System.Object.ReferenceEquals( two, null ) ) {
						myHashCode += two.GetHashCode();
					}
					if ( !System.Object.ReferenceEquals( three, null ) ) {
						myHashCode += three.GetHashCode();
					}
				}
			}
			public sealed override System.Int32 GetHashCode() {
				return myHashCode;
			}

			public override System.Int32 Capacity {
				get {
					return 3;
				}
			}
			public override T PeekLeft() {
				return myOne;
			}
			public override T PeekRight() {
				return myThree;
			}
			public override Dequelette EnqueueLeft( T value ) {
				return new Four( value, myOne, myTwo, myThree );
			}
			public override Dequelette EnqueueRight( T value ) {
				return new Four( myOne, myTwo, myThree, value );
			}
			public override Dequelette DequeueLeft() {
				return new Two( myTwo, myThree );
			}
			public override Dequelette DequeueRight() {
				return new Two( myOne, myTwo );
			}
		}
		[System.Serializable]
		private sealed class Four : Dequelette {
			private static readonly System.Int32 theHashCode;
			private readonly T myOne;
			private readonly T myTwo;
			private readonly T myThree;
			private readonly T myFour;
			private readonly System.Int32 myHashCode;

			static Four() {
				theHashCode = typeof( Four ).AssemblyQualifiedName.GetHashCode();
				unchecked {
					theHashCode += typeof( T ).AssemblyQualifiedName.GetHashCode();
				}
			}
			private Four() : base() {
				myHashCode = theHashCode;
			}
			internal Four( T one, T two, T three, T four ) : this() {
				myOne = one;
				myTwo = two;
				myThree = three;
				myFour = four;
				unchecked {
					if ( !System.Object.ReferenceEquals( one, null ) ) {
						myHashCode += one.GetHashCode();
					}
					if ( !System.Object.ReferenceEquals( two, null ) ) {
						myHashCode += two.GetHashCode();
					}
					if ( !System.Object.ReferenceEquals( three, null ) ) {
						myHashCode += three.GetHashCode();
					}
					if ( !System.Object.ReferenceEquals( four, null ) ) {
						myHashCode += four.GetHashCode();
					}
				}
			}
			public sealed override System.Int32 GetHashCode() {
				return myHashCode;
			}

			public sealed override System.Boolean IsFull {
				get {
					return true;
				}
			}
			public override System.Int32 Capacity {
				get {
					return 4;
				}
			}
			public override T PeekLeft() {
				return myOne;
			}
			public override T PeekRight() {
				return myFour;
			}
			public override Dequelette EnqueueLeft( T value ) {
				throw new System.InvalidOperationException( "Dequelette is full." );
			}
			public override Dequelette EnqueueRight( T value ) {
				throw new System.InvalidOperationException( "Dequelette is full." );
			}
			public override Dequelette DequeueLeft() {
				return new Three( myTwo, myThree, myFour );
			}
			public override Dequelette DequeueRight() {
				return new Three( myOne, myTwo, myThree );
			}
		}

		[System.Serializable]
		[System.Diagnostics.DebuggerDisplay( "Deque = {Count}" )]
		private sealed class EmptyDeque : IDeque<T> {

			private static readonly System.Int32 theHashCode;
			static EmptyDeque() {
				theHashCode = typeof( EmptyDeque ).AssemblyQualifiedName.GetHashCode();
				unchecked {
					theHashCode += typeof( T ).AssemblyQualifiedName.GetHashCode();
				}
			}
			internal EmptyDeque() {
			}
			public sealed override System.Int32 GetHashCode() {
				return theHashCode;
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

			public T PeekLeft() {
				throw new System.InvalidOperationException( "Cannot deuque from an empty deque." );
			}
			public T PeekRight() {
				throw new System.InvalidOperationException( "Cannot deuque from an empty deque." );
			}
			public IDeque<T> DequeueLeft() {
				throw new System.InvalidOperationException( "Cannot deuque from an empty deque." );
			}
			public IDeque<T> DequeueRight() {
				throw new System.InvalidOperationException( "Cannot deuque from an empty deque." );
			}
			public IDeque<T> EnqueueLeft( T value ) {
				return new SingleDequeue( value );
			}
			public IDeque<T> EnqueueRight( T value ) {
				return new SingleDequeue( value );
			}
		}

		[System.Serializable]
		[System.Diagnostics.DebuggerDisplay( "Deque = {Count}" )]
		private sealed class SingleDequeue : IDeque<T> {
			private static readonly System.Int32 theHashCode;
			private readonly T myValue;
			private readonly System.Int32 myHashCode;

			static SingleDequeue() {
				theHashCode = typeof( SingleDequeue ).AssemblyQualifiedName.GetHashCode();
				unchecked {
					theHashCode += typeof( T ).AssemblyQualifiedName.GetHashCode();
				}
			}
			private SingleDequeue() : base() {
				myHashCode = theHashCode;
			}
			internal SingleDequeue( T value ) : this() {
				myValue = value;
				if ( !System.Object.ReferenceEquals( value, null ) ) {
					unchecked {
						myHashCode += value.GetHashCode();
					}
				}
			}
			public sealed override System.Int32 GetHashCode() {
				return theHashCode;
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
			public T PeekLeft() {
				return myValue;
			}
			public T PeekRight() {
				return myValue;
			}
			public IDeque<T> DequeueLeft() {
				return Deque<T>.Empty;
			}
			public IDeque<T> DequeueRight() {
				return Deque<T>.Empty;
			}
			public IDeque<T> EnqueueLeft( T value ) {
				return new Deque<T>( new One( value ), Deque<Dequelette>.Empty, new One( myValue ), 2 );
			}
			public IDeque<T> EnqueueRight( T value ) {
				return new Deque<T>( new One( myValue ), Deque<Dequelette>.Empty, new One( value ), 2 );
			}

		}
		#endregion nested classes


		#region fields
		private static readonly System.Int32 theHashCode;
		private static readonly IDeque<T> theEmpty;

		private readonly System.Int32 myHashCode;
		private readonly System.Int64 myLongCount;
		private readonly System.Int32 myShortCount;
		private readonly Dequelette myLeft;
		private readonly IDeque<Dequelette> myMiddle;
		private readonly Dequelette myRight;
		#endregion fields


		#region .ctor
		static Deque() {
			theHashCode = typeof( Deque<T> ).AssemblyQualifiedName.GetHashCode();
			unchecked {
				theHashCode += typeof( T ).AssemblyQualifiedName.GetHashCode();
			}
			theEmpty = new EmptyDeque();
		}

		private Deque() : base() {
			myHashCode = theHashCode;
		}
		private Deque( Dequelette left, IDeque<Dequelette> middle, Dequelette right, System.Int64 count ) : this() {
			if ( count <= 0 ) {
				throw new System.ArgumentOutOfRangeException( "count", "count must be positive." );
			} else if ( null == right ) {
				throw new System.ArgumentNullException( "right" );
			} else if ( null == left ) {
				throw new System.ArgumentNullException( "left" );
			}
			myLeft = left;
			myMiddle = middle ?? Deque<Dequelette>.Empty;
			myRight = right;
			myLongCount = count;
			myShortCount = (System.Int32)System.Math.Min( (System.Int64)System.Int32.MaxValue, myLongCount );
			unchecked {
				myHashCode += left.GetHashCode();
				myHashCode += myMiddle.GetHashCode();
				myHashCode += right.GetHashCode();
			}
		}
		#endregion .ctor


		#region properties
		public static IDeque<T> Empty {
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
		#endregion properties


		#region methods
		public sealed override System.Int32 GetHashCode() {
			return myHashCode;
		}

		public T PeekLeft() {
			return myLeft.PeekLeft();
		}
		public T PeekRight() {
			return myRight.PeekRight();
		}
		public IDeque<T> EnqueueLeft( T value ) {
			return ( myLeft.IsFull )
				? new Deque<T>( new One( value ), myMiddle.EnqueueLeft( myLeft ), myRight, myLongCount + 1 )
				: new Deque<T>( myLeft.EnqueueLeft( value ), myMiddle, myRight, myLongCount + 1 )
			;
		}
		public IDeque<T> EnqueueRight( T value ) {
			return ( myRight.IsFull )
				? new Deque<T>( myLeft, myMiddle.EnqueueRight( myRight), new One( value ), myLongCount + 1 )
				: new Deque<T>( myLeft, myMiddle, myRight.EnqueueRight( value ), myLongCount + 1 )
			;
		}
		public IDeque<T> DequeueLeft() {
			return ( 1 < myLeft.Capacity )
				? new Deque<T>( myLeft.DequeueLeft(), myMiddle, myRight, myLongCount - 1 )
				: ( !myMiddle.IsEmpty )
					? new Deque<T>( myMiddle.PeekLeft(), myMiddle.DequeueLeft(), myRight, myLongCount - 1 )
					: ( 1 < myRight.Capacity )
						? new Deque<T>( new One( myRight.PeekLeft() ), myMiddle, myRight.DequeueLeft(), myLongCount - 1 )
						: new SingleDequeue( myRight.PeekLeft() ) as IDeque<T>
			;
		}
		public IDeque<T> DequeueRight() {
			return ( 1 < myRight.Capacity )
				? new Deque<T>( myLeft, myMiddle, myRight.DequeueRight(), myLongCount - 1 )
				: ( !myMiddle.IsEmpty )
					? new Deque<T>( myLeft, myMiddle.DequeueRight(), myMiddle.PeekRight(), myLongCount - 1 )
					: ( 1 < myLeft.Capacity )
						? new Deque<T>( myLeft.DequeueRight(), myMiddle, new One( myLeft.PeekRight() ), myLongCount - 1 )
						: new SingleDequeue( myLeft.PeekRight() ) as IDeque<T>
			;
		}
		#endregion methods

	}

}