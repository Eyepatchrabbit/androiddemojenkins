using System;
using System.IO;
using System.Linq;
using NUnit.Framework;
using Xamarin.UITest;
using Xamarin.UITest.Android;
using Xamarin.UITest.Queries;

namespace CreditCardValidator.Droid.UITests
{
	[TestFixture]
	public class Tests
	{
		AndroidApp app;

		//Arrange
		Func<AppQuery, AppQuery> invoerveldcardnummer = e => e.Id("creditCardNumberText");
		Func<AppQuery, AppQuery> validatieknop = e => e.Id("validateButton");

		Func<AppQuery, AppQuery> errormessageappears = e => e.Id("errorMessagesText");

		Func<AppQuery, AppQuery> textistoshortmessage = e => e.Text("Credit card number is too short.");
		Func<AppQuery, AppQuery> textistolongmessage = e => e.Text("Credit card number is too long.");
		Func<AppQuery, AppQuery> textiscorrectlengthmessage = e => e.Id("validationSuccessMessage");
		Func<AppQuery, AppQuery> nonumbertext = e => e.Text("This is not a credit card number.");

		string shortnumber = "123456";
		string longnumber = "4328776556677776668";
		string numbercorrectlength = "1234567890123456";


		[SetUp]
		public void beforeEachTest()
		{
			app = ConfigureApp.Android.StartApp();
		}

		/*
		[Test]
		public void repl()
		{
			app.Repl();
		}
		*/

		/*
		[Test]
		public void failingTest()
		{
			app.WaitForElement(invoerveldcardnummer);
			app.Screenshot("After starting application");
			app.EnterText(invoerveldcardnummer, longnumber);

			app.WaitForElement(e => e.Text(longnumber), "number not in textfield");
			app.Screenshot("number entered");
			app.Tap(e => e.Text("NOT present"));

			app.WaitForElement(errormessageappears, "no error message");
			app.Screenshot("After doing the validation");
			var toshort = app.Query(textistolongmessage).SingleOrDefault();
			Assert.IsNotNull(toshort);

		}
        */

		[Test]
		public void numberToShort()
		{
			app.WaitForElement(invoerveldcardnummer);
			app.Screenshot("After starting application");
			app.EnterText(invoerveldcardnummer, shortnumber);

			app.WaitForElement(e => e.Text(shortnumber), "number not in textfield");
			app.Screenshot("number entred");
			app.Tap(validatieknop);

			app.WaitForElement(errormessageappears, "no error message");
			app.Screenshot("After doing the validation");
			var toshort = app.Query(textistoshortmessage).SingleOrDefault();
			Assert.IsNotNull(toshort);
		}


		[Test]
		public void numberToLong()
		{
			app.WaitForElement(invoerveldcardnummer);
			app.Screenshot("After starting application");
			app.EnterText(invoerveldcardnummer, longnumber);

			app.WaitForElement(e => e.Text(longnumber), "number not in textfield");
			app.Screenshot("number entered");
			app.Tap(validatieknop);

			app.WaitForElement(errormessageappears, "no error message");
			app.Screenshot("After doing the validation");
			var toshort = app.Query(textistolongmessage).SingleOrDefault();
			Assert.IsNotNull(toshort);

		}

		[Test]
		public void numberCorrectLength()
		{
			app.WaitForElement(invoerveldcardnummer);
			app.Screenshot("After starting application");
			app.EnterText(invoerveldcardnummer, numbercorrectlength);

			app.WaitForElement(e => e.Text(numbercorrectlength), "number not in textfield");
			app.Screenshot("number entred");
			app.Tap(validatieknop);

			app.WaitForElement(textiscorrectlengthmessage, "Didn't get the message that the number is valid");
			app.Screenshot("After doing the validation");
			var toshort = app.Query(textiscorrectlengthmessage).SingleOrDefault();
			Assert.IsNotNull(toshort);
		}

		[Test]
		public void nunumber()
		{
			app.WaitForElement(invoerveldcardnummer);
			app.Screenshot("After starting application");
			app.Tap(validatieknop);

			app.WaitForElement(errormessageappears, "no error message");
			app.Screenshot("After doing the validation");
			var toshort = app.Query(nonumbertext).SingleOrDefault();
			Assert.IsNotNull(toshort);
		}
	}
}

