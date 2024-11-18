using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Edge;
using System;

namespace KoiFarmShop.Tests
{
	public class LoginRegisterTests : IDisposable
	{
		private EdgeDriver driver;

		[SetUp]
		public void Setup()
		{
			driver = new EdgeDriver();
			driver.Manage().Window.Maximize();
		}

		#region Test Đăng Nhập

		[Test]
		public void Test_Login_EmptyFields()
		{
			driver.Navigate().GoToUrl("https://localhost:7197/Accounts/Login");

			var emailField = driver.FindElement(By.Name("Email"));
			var passwordField = driver.FindElement(By.Name("Password"));

			emailField.Clear();
			passwordField.Clear();

			var loginButton = driver.FindElement(By.Id("loginbtn"));
			loginButton.Click();

			var errorMessage = driver.FindElement(By.CssSelector(".error-message"));
			Assert.AreEqual("Please fill out this field.", errorMessage.Text); // Kỳ vọng thông báo lỗi khi để trống trường
		}

		[Test]
		public void Test_Login_InvalidCredentials()
		{
			driver.Navigate().GoToUrl("https://localhost:7197/Accounts/Login");

			var emailField = driver.FindElement(By.Name("Email"));
			var passwordField = driver.FindElement(By.Name("Mật khẩu"));

			emailField.Clear();
			passwordField.Clear();

			emailField.SendKeys("wronguser@example.com");
			passwordField.SendKeys("wrongpassword");

			var loginButton = driver.FindElement(By.Id("loginbtn"));
			loginButton.Click();

			var greetingMessage = driver.FindElement(By.CssSelector("span"));
			Assert.AreEqual("Xin chào, khách hàng!", greetingMessage.Text); // Kiểm tra thông báo khi đăng nhập sai
		}

		[Test]
		public void Test_Login_Success()
		{
			driver.Navigate().GoToUrl("https://localhost:7197/Accounts/Login");

			var emailField = driver.FindElement(By.Name("Email"));
			var passwordField = driver.FindElement(By.Name("Mật khẩu"));

			emailField.Clear();
			passwordField.Clear();

			emailField.SendKeys("thaitran1233@gmail.com"); // Nhập thông tin đúng
			passwordField.SendKeys("thaitran1233");

			var loginButton = driver.FindElement(By.Id("loginbtn"));
			loginButton.Click();

			var greetingMessage = driver.FindElement(By.CssSelector("span"));
			Assert.AreEqual("Xin chào, nhunghtt4504@ut.edu.vn!", greetingMessage.Text); // Kiểm tra tên người dùng sau khi đăng nhập thành công
		}

		#endregion

		#region Test Đăng Ký

		[Test]
		public void Test_Register_Success()
		{
			driver.Navigate().GoToUrl("https://localhost:7197/Accounts/Register");

			var usernameField = driver.FindElement(By.Name("Input.UserName"));
			var fullNameField = driver.FindElement(By.Name("Input.FullName"));
			var emailField = driver.FindElement(By.Name("Input.Email"));
			var phoneField = driver.FindElement(By.Name("Input.Phone"));
			var passwordField = driver.FindElement(By.Name("Input.Password"));

			usernameField.Clear();
			fullNameField.Clear();
			emailField.Clear();
			phoneField.Clear();
			passwordField.Clear();

			usernameField.SendKeys("newuser");
			fullNameField.SendKeys("New User");
			emailField.SendKeys("newuser@example.com");
			phoneField.SendKeys("1234567890");
			passwordField.SendKeys("newpassword");

			var registerButton = driver.FindElement(By.Id("registerbtn"));
			registerButton.Click();

			var pageTitle = driver.Title;
			Assert.AreEqual("Trang chủ", pageTitle); // Kiểm tra tiêu đề trang sau khi đăng ký thành công
		}

		[Test]
		public void Test_Register_DuplicateEmail()
		{
			driver.Navigate().GoToUrl("https://localhost:7197/Accounts/Register");

			var emailField = driver.FindElement(By.Name("Input.Email"));
			var passwordField = driver.FindElement(By.Name("Input.Password"));
			var confirmPasswordField = driver.FindElement(By.Name("Input.ConfirmPassword"));
			var fullNameField = driver.FindElement(By.Name("Input.FullName"));
			var phoneField = driver.FindElement(By.Name("Input.Phone"));
			var addressField = driver.FindElement(By.Name("Input.Address"));

			emailField.Clear();
			passwordField.Clear();
			confirmPasswordField.Clear();
			fullNameField.Clear();
			phoneField.Clear();
			addressField.Clear();

			emailField.SendKeys("existinguser@example.com"); // Email đã tồn tại trong hệ thống
			passwordField.SendKeys("newpassword");
			confirmPasswordField.SendKeys("newpassword");
			fullNameField.SendKeys("New User");
			phoneField.SendKeys("1234567890");
			addressField.SendKeys("Some address");

			var registerButton = driver.FindElement(By.Id("registerbtn"));
			registerButton.Click();

			var errorMessage = driver.FindElement(By.CssSelector(".error-message"));
			Assert.AreEqual("Email đã tồn tại.", errorMessage.Text); // Kiểm tra thông báo khi email đã tồn tại
		}

		#endregion

		[TearDown]
		public void Teardown()
		{
			Dispose();
		}

		public void Dispose()
		{
			driver?.Dispose();
		}
	}
}
