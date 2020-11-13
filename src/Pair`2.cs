// Copyright 2020, Timothy J. Bruce

namespace Icod.Collections {

	[System.Serializable]
	public class Pair<S, T> {

		#region fields
		private static readonly System.Int32 theHashCode;

		private readonly S myFirst;
		private readonly T mySecond;
		private readonly System.Int32 myHashCode;
		#endregion fields


		#region .ctor
		static Pair() {
			theHashCode = typeof( Pair<S, T> ).AssemblyQualifiedName.GetHashCode();
			unchecked {
				theHashCode += typeof( S ).AssemblyQualifiedName.GetHashCode();
				theHashCode += typeof( T ).AssemblyQualifiedName.GetHashCode();
			}
		}

		public Pair( S first, T second ) {
			myFirst = first;
			mySecond = second;
			myHashCode = theHashCode;
			unchecked {
				if ( !System.Object.ReferenceEquals( first, null ) ) {
					myHashCode += first.GetHashCode();
				}
				if ( !System.Object.ReferenceEquals( second, null ) ) {
					myHashCode += second.GetHashCode();
				}
			}
		}
		#endregion .ctor


		#region properties
		public S First {
			get {
				return myFirst;
			}
		}
		public T Second {
			get {
				return mySecond;
			}
		}
		#endregion properties


		#region methods
		public override System.Int32 GetHashCode() {
			return myHashCode;
		}
		#endregion methods


	}

}