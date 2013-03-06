// 
// ImageViewBackend.cs
//  
// Author:
//       Lluis Sanchez <lluis@xamarin.com>
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
using Xwt.Backends;

using Xwt.Drawing;

namespace Xwt.GtkBackend
{
	public class ImageViewBackend: WidgetBackend, IImageViewBackend
	{
		public override void Initialize ()
		{
			Widget = new Gtk.Image ();
			Widget.Show ();
		}
		
		protected new Gtk.Image Widget {
			get { return (Gtk.Image)base.Widget; }
			set { base.Widget = value; }
		}
		
		public void SetImage (Image image)
		{
			if (image == null) {
				Widget.Pixbuf = null;
				return;
			}

			Gdk.Pixbuf pbuf = Toolkit.GetBackend (image) as Gdk.Pixbuf;
			if (pbuf == null)
				pbuf = Toolkit.GetBackend (image.ToBitmap ()) as Gdk.Pixbuf;
			if (pbuf == null)
				throw new ArgumentException ("image is not of the expected type", "image");

			if (image.HasFixedSize && (pbuf.Width != (int)image.Size.Width || pbuf.Height != (int)image.Size.Height))
				pbuf = pbuf.ScaleSimple ((int)image.Size.Width, (int)image.Size.Height, Gdk.InterpType.Bilinear);

			Widget.Pixbuf = pbuf;
		}
	}
}

