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

namespace BitLaboratory.Win32Api.Windows
{
	[Flags]
	internal enum ClassStylesFlags 
	{
		CS_VREDRAW          = 0x0001,
		CS_HREDRAW          = 0x0002,
		//CS_KEYCVTWINDOW     = 0x0004,
		//CS_DBLCLKS          = 0x0008,
		//CS_OWNDC            = 0x0020,
		//CS_CLASSDC          = 0x0040,
		//CS_PARENTDC         = 0x0080,
		//CS_NOKEYCVT         = 0x0100,
		//CS_NOCLOSE          = 0x0200,
		//CS_SAVEBITS         = 0x0800,
		//CS_BYTEALIGNCLIENT  = 0x1000,
		//CS_BYTEALIGNWINDOW  = 0x2000,
		//CS_GLOBALCLASS      = 0x4000,
		//CS_IME              = 0x00010000
	} 
}
