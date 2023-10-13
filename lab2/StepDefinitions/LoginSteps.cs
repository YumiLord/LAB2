using System;
using TechTalk.SpecFlow;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome; 
using OpenQA.Selenium.Support.UI;
using NUnit.Framework;

namespace YourProjectNamespace
{
    [Binding]
    public class LoginSteps
    {
        private IWebDriver driver;
        private LoginPage loginPage;

        public LoginSteps()
        {
            // Ініціалізуємо драйвер у конструкторі
            driver = new ChromeDriver(); // Ви можете вибрати інший драйвер за потребою
            loginPage = new LoginPage(driver);
        }

        [Given(@"I am on the banking website")]
        public void GivenIAmOnTheBankingWebsite()
        {
            loginPage.OpenLoginPage("https://www.globalsqa.com/angularJs-protractor/BankingProject"); // Замініть URL на реальний URL вашого веб-сайту
        }

        [When(@"I select ""Login as User"" option")]
        public void WhenISelectLoginAsUserOption()
        {
            loginPage.ClickLoginAsUser();
        }

        [When(@"I select ""Hermoine Granger"" as a customer")]

        public void WhenISelectHarryPotter() {
            loginPage.SelectCustomer("Hermoine Granger");
        }

        [When(@"I click Login button")]

        public void WhenIClickLoginButton()
        {
            loginPage.ClickLogin();
        }

        [Then(@"I should be on the bank's home page")]
        public void ThenIShouldSeeTheMainDivBlock()
        {
            bool isMainDivVisible = loginPage.IsWelcomeTextVisible();
            Assert.IsTrue(isMainDivVisible, "The 'mainBox' block is not visible.");
        }

        [When(@"I click the Withdrawl button")]

        public void WhenIClickWithdraw()
        {
            loginPage.OpenWithdrawMenu();
        }

        [When(@"I enter the withdrawal amount as full sum / 2")]
        public void EnterAmount()
        {
            loginPage.EnterAmount();
        }

        [When(@"I click the ""Confirm Withdrawal"" button")]
        public void ConfirmWithdraw()
        {
            loginPage.ClickWithdraw();
        }

        [Then(@"I should see a success message")]
        public void ThenIShouldSeeASucseedMessage()
        {
            loginPage.IsSucseedTextVisible();
        }

        [When(@"I enter the withdrawal amount as full sum x 2")]

        public void EnterMoreAmount()
        {
            loginPage.EnterMoreAmount();
        }

        [When(@"I click the ""Confirm Withdrawal"" button again")]

        public void ClickWithdrawAgain()
        {
            loginPage.ClickWithdraw();
        }

        [Then(@"I should see an error message")]
        public void ThenIShoulSeeAnError()
        {
            loginPage.IsErrorTextVisible();
        }

        [Then(@"I should close Chrome")]
        public void CloseChrome()
        {
            loginPage.CloseDriver();
        }
    }
}
