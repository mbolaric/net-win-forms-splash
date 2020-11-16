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
	internal enum WindowStyles : uint
	{
		//WS_OVERLAPPED       = 0x00000000,
		WS_POPUP            = 0x80000000,
		//WS_CHILD            = 0x40000000,
		//WS_MINIMIZE         = 0x20000000,
		WS_VISIBLE          = 0x10000000,
		//WS_DISABLED         = 0x08000000,
		//WS_CLIPSIBLINGS     = 0x04000000,
		//WS_CLIPCHILDREN     = 0x02000000,
		//WS_MAXIMIZE         = 0x01000000,
		//WS_CAPTION          = 0x00C00000,     /* WS_BORDER | WS_DLGFRAME  */
		//WS_BORDER           = 0x00800000,
		//WS_DLGFRAME         = 0x00400000,
		//WS_VSCROLL          = 0x00200000,
		//WS_HSCROLL          = 0x00100000,
		//WS_SYSMENU          = 0x00080000,
		//WS_THICKFRAME       = 0x00040000,
		//WS_GROUP            = 0x00020000,
		//WS_TABSTOP          = 0x00010000,

		//WS_MINIMIZEBOX      = 0x00020000,
		//WS_MAXIMIZEBOX      = 0x00010000,


		//WS_TILED            = WS_OVERLAPPED,
		//WS_ICONIC           = WS_MINIMIZE,
		//WS_SIZEBOX          = WS_THICKFRAME,
		//WS_TILEDWINDOW      = WS_OVERLAPPEDWINDOW,
		//WS_OVERLAPPEDWINDOW = (WS_OVERLAPPED     | 
		//	WS_CAPTION        | 
		//	WS_SYSMENU        | 
		//	WS_THICKFRAME     | 
		//	WS_MINIMIZEBOX    | 
		//	WS_MAXIMIZEBOX),

		//WS_POPUPWINDOW      = (WS_POPUP          | 
		//	WS_BORDER         | 
		//	WS_SYSMENU),
		//WS_CHILDWINDOW         = (WS_CHILD),
	}

	internal enum WindowStylesEx : uint
	{
		WS_EX_DLGMODALFRAME    = 0x00000001,
		WS_EX_NOPARENTNOTIFY   = 0x00000004,
		WS_EX_TOPMOST          = 0x00000008,
		WS_EX_ACCEPTFILES      = 0x00000010,
		WS_EX_TRANSPARENT      = 0x00000020,
		WS_EX_MDICHILD         = 0x00000040,
		WS_EX_TOOLWINDOW       = 0x00000080,
		WS_EX_WINDOWEDGE       = 0x00000100,
		WS_EX_CLIENTEDGE       = 0x00000200,
		WS_EX_CONTEXTHELP      = 0x00000400,
		WS_EX_RIGHT            = 0x00001000,
		WS_EX_LEFT             = 0x00000000,
		WS_EX_RTLREADING       = 0x00002000,
		WS_EX_LTRREADING       = 0x00000000,
		WS_EX_LEFTSCROLLBAR    = 0x00004000,
		WS_EX_RIGHTSCROLLBAR   = 0x00000000,

		WS_EX_CONTROLPARENT    = 0x00010000,
		WS_EX_STATICEDGE       = 0x00020000,
		WS_EX_APPWINDOW        = 0x00040000,


		WS_EX_OVERLAPPEDWINDOW = (WS_EX_WINDOWEDGE | WS_EX_CLIENTEDGE),
		WS_EX_PALETTEWINDOW    = (WS_EX_WINDOWEDGE | WS_EX_TOOLWINDOW | WS_EX_TOPMOST),

		WS_EX_LAYERED          = 0x00080000,

		WS_EX_NOINHERITLAYOUT  = 0x00100000, // Disable inheritence of mirroring by children
		WS_EX_LAYOUTRTL        = 0x00400000, // Right to left mirroring

		WS_EX_COMPOSITED       = 0x02000000,
		WS_EX_NOACTIVATE       = 0x08000000
	}

	internal enum WindowClassStyles : int
	{
		CS_VREDRAW          = 0x0001,
		CS_HREDRAW          = 0x0002,
		CS_DBLCLKS          = 0x0008,
		CS_OWNDC            = 0x0020,
		CS_CLASSDC          = 0x0040,
		CS_PARENTDC         = 0x0080,
		CS_NOCLOSE          = 0x0200,
		CS_SAVEBITS         = 0x0800,
		CS_BYTEALIGNCLIENT  = 0x1000,
		CS_BYTEALIGNWINDOW  = 0x2000,
		CS_GLOBALCLASS      = 0x4000,

		CS_IME              = 0x00010000,
		CS_DROPSHADOW       = 0x00020000
	}

}
