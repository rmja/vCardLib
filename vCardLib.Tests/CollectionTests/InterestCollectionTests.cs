﻿// Created by Bolorunduro Winner-Timothy on  11/22/2016 at 5:33 AM

using System;
using NUnit.Framework;
using vCardLib.Collections;
using vCardLib.Models;

namespace vCardLib.Tests.CollectionTests
{
	[TestFixture]
	public class InterestCollectionTests
	{
		[Test]
		public void InsertAndRemove()
		{
			Assert.DoesNotThrow(delegate
			{
				var interest = new Interest();
				var interestCollection = new InterestCollection();
				interestCollection.Add(interest);
				interest = interestCollection[0];
				interestCollection[0] = interest;
				interestCollection.Remove(interest);
			});
		}

		[Test]
		public void InsertAndRemoveNonExistentIndices()
		{
			var interestCollection = new InterestCollection();
			Assert.Throws<IndexOutOfRangeException>(delegate
			{
				var interest_ = interestCollection[0];
			});
			var interest = new Interest();
			Assert.Throws<IndexOutOfRangeException>(delegate
			{
				interestCollection[0] = interest;
			});
		}
	}
}
