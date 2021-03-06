﻿using NUnit.Framework;
using vCardLib.Models;

namespace vCardLib.Tests.ModelTests
{
	[TestFixture]
	public class PhotoTests
	{
		[Test]
		public void WhenPictureIsNull()
		{
			var photo = new Photo();
			photo.Type = PhotoType.URL;
			photo.Encoding = PhotoEncoding.GIF;
			photo.PhotoURL = "http://google.com/test.gif";
			photo.Picture = null;

			Assert.AreEqual("", photo.ToBase64String());
		}

		[Test]
		public void WhenPictureIsNotNull()
		{
			var request = System.Net.WebRequest.Create("https://jpeg.org/images/jpeg-logo-plain.png");
            var response = request.GetResponse();
            var responseStream = response.GetResponseStream();

            var photo = new Photo();
			photo.Type = PhotoType.Image;
			photo.Encoding = PhotoEncoding.JPEG;
			photo.Picture = new System.Drawing.Bitmap(responseStream);

			Assert.DoesNotThrow(delegate { photo.ToBase64String(); });
			Assert.Greater(photo.ToBase64String().Length, 0);
		}
	}
}
