// Copyright 2020, Timothy J. Bruce
// This file is licensed under the terms of the GNU LESSER GENERAL PUBLIC LICENSE, version 2.1, February 1999

namespace Icod.Collections {

	[System.Serializable]
	public class Triplet<S, T, U> : Pair<S, T> {

		#region fields
		private static readonly System.Int32 theHashCode;

		private readonly U myThird;
		private readonly System.Int32 myHashCode;
		#endregion fields


		#region .ctor
		static Triplet() {
			theHashCode = typeof( Triplet<S, T, U> ).AssemblyQualifiedName.GetHashCode();
			unchecked {
				theHashCode += typeof( S ).AssemblyQualifiedName.GetHashCode();
				theHashCode += typeof( T ).AssemblyQualifiedName.GetHashCode();
				theHashCode += typeof( U ).AssemblyQualifiedName.GetHashCode();
			}
		}

		public Triplet( S first, T second, U third ) : base( first, second ) {
			myThird = third;
			myHashCode = theHashCode;
			unchecked {
				if ( !System.Object.ReferenceEquals( first, null ) ) {
					myHashCode += first.GetHashCode();
				}
				if ( !System.Object.ReferenceEquals( second, null ) ) {
					myHashCode += second.GetHashCode();
				}
				if ( !System.Object.ReferenceEquals( third, null ) ) {
					myHashCode += third.GetHashCode();
				}
			}
		}
		#endregion .ctor


		#region properties
		public U Third {
			get {
				return myThird;
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