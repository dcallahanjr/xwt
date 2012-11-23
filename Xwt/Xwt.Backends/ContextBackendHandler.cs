// 
// IContextBackendHandler.cs
//  
// Author:
//       Lluis Sanchez <lluis@xamarin.com>
//       Hywel Thomas <hywel.w.thomas@gmail.com>
// 
// Copyright (c) 2011 Xamarin Inc
// 
// Permission is hereby granted, free of charge, to any person obtaining a copy
// of this software and associated documentation files (the "Software"), to deal
// in the Software without restriction, including without limitation the rights
// to use, copy, modify, merge, publish, distribute, sublicense, and/or sell
// copies of the Software, and to permit persons to whom the Software is
// furnished to do so, subject to the following conditions:
// 
// The above copyright notice and this permission notice shall be included in
// all copies or substantial portions of the Software.
// 
// THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND, EXPRESS OR
// IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF MERCHANTABILITY,
// FITNESS FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT. IN NO EVENT SHALL THE
// AUTHORS OR COPYRIGHT HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER
// LIABILITY, WHETHER IN AN ACTION OF CONTRACT, TORT OR OTHERWISE, ARISING FROM,
// OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER DEALINGS IN
// THE SOFTWARE.

using System;
using Xwt.Drawing;

namespace Xwt.Backends
{
	public abstract class ContextBackendHandler: BackendHandler
	{
		public abstract void Save (object backend);

		public abstract void Restore (object backend);

		public abstract void Arc (object backend, double xc, double yc, double radius, double angle1, double angle2);

		public abstract void ArcNegative (object backend, double xc, double yc, double radius, double angle1, double angle2);

		public abstract void Clip (object backend);
		
		public abstract void ClipPreserve(object backend);
		
		public abstract void ResetClip (object backend);
		
		public abstract void ClosePath(object backend);
		
		public abstract void CurveTo (object backend, double x1, double y1, double x2, double y2, double x3, double y3);
		
		public abstract void Fill (object backend);
		
		public abstract void FillPreserve (object backend);
		
		public abstract void LineTo (object backend, double x, double y);
		
		public abstract void MoveTo (object backend, double x, double y);
		
		public abstract void NewPath (object backend);
		
		public abstract void Rectangle (object backend, double x, double y, double width, double height);
		
		public abstract void RelCurveTo (object backend, double dx1, double dy1, double dx2, double dy2, double dx3, double dy3);
		
		public abstract void RelLineTo (object backend, double dx, double dy);
		
		public abstract void RelMoveTo (object backend, double dx, double dy);
		
		public abstract void Stroke (object backend);
		
		public abstract void StrokePreserve (object backend);
		
		public abstract void SetColor (object backend, Xwt.Drawing.Color color);
		
		public abstract void SetLineWidth (object backend, double width);
		
		public abstract void SetLineDash (object backend, double offset, params double[] pattern);
		
		public abstract void SetPattern (object backend, object p);
		
		public abstract void SetFont (object backend, Font font);
		
		public abstract void DrawTextLayout (object backend, TextLayout layout, double x, double y);
		
		public abstract void DrawImage (object backend, object img, double x, double y, double alpha);
		
		public abstract void DrawImage (object backend, object img, double x, double y, double width, double height, double alpha);

		public abstract void DrawImage (object backend, object img, Rectangle srcRect, Rectangle destRect, double alpha);

		public abstract void ResetTransform (object backend);

		public abstract void Rotate (object backend, double angle);
		
		public abstract void Scale (object backend, double scaleX, double scaleY);
		
		public abstract void Translate (object backend, double tx, double ty);

		public abstract void TransformPoint (object backend, ref double x, ref double y);

		public abstract void TransformDistance (object backend, ref double dx, ref double dy);

		public abstract void TransformPoints (object backend, Point[] points);

		public abstract void TransformDistances (object backend, Distance[] vectors);

		/// <summary>
		/// Sets a global alpha to be applied to all drawing operations.
		/// It doesn't affect colors that have already been set.
		/// </summary>
		public abstract void SetGlobalAlpha (object backend, double globalAlpha);
		
		public abstract void Dispose (object backend);
	}
}
