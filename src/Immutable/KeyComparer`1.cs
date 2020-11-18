// Copyright 2020 Timothy J. Bruce
// This file is licensed under the terms of the GNU LESSER GENERAL PUBLIC LICENSE, version 2.1, February 1999

using System.Linq;

namespace Icod.Collections.Immutable {

	public static class KeyComparer {

		public static System.Int32 CompareKeys<K>( this K key, K other ) where K : System.IComparable<K> {
			return ( System.Object.ReferenceEquals( null, key ) )
				? ( System.Object.ReferenceEquals( null, other ) )
					? 0
					: -other.CompareTo( key )
				: key.CompareTo( other )
			;
		}

	}

}