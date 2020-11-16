/*
*
* Copyright (C) 2004 - BitLaboratory
* All rights reserved. 
*
* Redistribution and use in source and binary forms, with or without modification, 
* are permitted provided that the following conditions are met:
*
* 1. Redistributions of source code must retain the above copyright notice,
*    this list of conditions and the following disclaimer.
* 2. Redistributions in binary form must reproduce the above copyright notice,
*    this list of conditions and the following disclaimer in the documentation
*    and/or other materials provided with the distribution.
* 3. The name of the author may not be used to endorse or promote products
*    derived from this software without specific prior written permission. 
*
* THIS SOFTWARE IS PROVIDED BY THE AUTHOR ``AS IS'' AND ANY EXPRESS OR IMPLIED 
* WARRANTIES, INCLUDING, BUT NOT LIMITED TO, THE IMPLIED WARRANTIES OF 
* MERCHANTABILITY AND FITNESS FOR A PARTICULAR PURPOSE ARE DISCLAIMED. IN NO EVENT 
* SHALL THE AUTHOR BE LIABLE FOR ANY DIRECT, INDIRECT, INCIDENTAL, SPECIAL, 
* EXEMPLARY, OR CONSEQUENTIAL DAMAGES (INCLUDING, BUT NOT LIMITED TO, PROCUREMENT 
* OF SUBSTITUTE GOODS OR SERVICES; LOSS OF USE, DATA, OR PROFITS; OR BUSINESS 
* INTERRUPTION) HOWEVER CAUSED AND ON ANY THEORY OF LIABILITY, WHETHER IN 
* CONTRACT, STRICT LIABILITY, OR TORT (INCLUDING NEGLIGENCE OR OTHERWISE) ARISING 
* IN ANY WAY OUT OF THE USE OF THIS SOFTWARE, EVEN IF ADVISED OF THE POSSIBILITY 
* OF SUCH DAMAGE.
*
* You can find the latest version of this library at https://github.com/mbolaric/net-win-forms-splash
*
*/

using System;
using System.ComponentModel;

namespace BitLaboratory.Windows.Splash
{
	/// <summary>
	/// Class to hold custom data with additional information for drawing Splash Screen
	/// </summary>
	public class RedrawCustomData
	{
		/// <summary>
		/// Represents a Empty Object
		/// </summary>
		public static RedrawCustomData Empty = new RedrawCustomData();
    	private object _redrawData = null;

		internal RedrawCustomData()
		{
		}

		/// <summary>
		/// Initialize class
		/// </summary>
		/// <param name="redrawData">Object with addtional data for drawing</param>
		public RedrawCustomData(object redrawData)
		{
			this._redrawData = redrawData;
		}

		/// <summary>
		/// Gets Object with addtional data for drawing
		/// </summary>
		[Description("Gets Object with addtional data for drawing")]
		public Object RedrawData
		{
			get{ return _redrawData; }
		}
	}
}
