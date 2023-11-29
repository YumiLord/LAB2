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

        [When(@"I select ""Login as Bank Manager"" option")]
        public void WhenISelectLoginAsBankManagerOption()
        {
            loginPage.ClickLoginAsBankManager();
        }

        [Then(@"I click ""Customers"" to see a list of customers")]
        public void ClickCustomers() {
            loginPage.ClickCustomers();
        }

        [When(@"I search a peson by first name")]
        public void SearchByFirstName()
        {
            loginPage.inputSearchKey("Hermoine");
        }

        [Then(@"I should see a person with this first name")]
        public void checkPesonWithFirstName()
        {
            List<IWebElement> res = loginPage.checkPerson();
            Assert.AreEqual(res[0].Text, "Hermoine","First names don't match");
            Assert.AreEqual(res[1].Text, "Granger", "Last names don't match");
            Assert.AreEqual(res[2].Text, "E859AB", "Postcodes don't match");
            Assert.AreEqual(res[3].Text, "1001 1002 1003", "Account numbers don't match");
        }

        [When(@"I search a peson by last name")]
        public void SearchByLastName()
        {
            loginPage.inputSearchKey("Pot");
        }

        [Then(@"I should see a person with this last name")]
        public void checkPesonWithLastName()
        {
            List<IWebElement> res = loginPage.checkPerson();
            Assert.AreEqual(res[0].Text, "Harry", "First names don't match");
            Assert.AreEqual(res[1].Text, "Potter", "Last names don't match");
            Assert.AreEqual(res[2].Text, "E725JB", "Postcodes don't match");
            Assert.AreEqual(res[3].Text, "1004 1005 1006", "Account numbers don't match");
        }

        [When(@"I search a peson by postcode")]
        public void SearchByPostcode()
        {
            loginPage.inputSearchKey("E55555");
        }

        [Then(@"I should see a person with this postcode")]
        public void checkPesonWithPostcode()
        {
            List<IWebElement> res = loginPage.checkPerson();
            Assert.AreEqual(res[0].Text, "Ron", "First names don't match");
            Assert.AreEqual(res[1].Text, "Weasly", "Last names don't match");
            Assert.AreEqual(res[2].Text, "E55555", "Postcodes don't match");
            Assert.AreEqual(res[3].Text, "1007 1008 1009", "Account numbers don't match");
        }

        [When(@"I search a peson by account number")]
        public void SearchByAccountNumber()
        {
            loginPage.inputSearchKey("1010");
        }

        [Then(@"I should see a person with this account number")]
        public void checkPesonWithAccountNumber()
        {
            List<IWebElement> res = loginPage.checkPerson();
            Assert.AreEqual(res[0].Text, "Albus", "First names don't match");
            Assert.AreEqual(res[1].Text, "Dumbledore", "Last names don't match");
            Assert.AreEqual(res[2].Text, "E55656", "Postcodes don't match");
            Assert.AreEqual(res[3].Text, "1010 1011 1012", "Account numbers don't match");
        }

        [Then(@"I should close Chrome")]
        public void CloseChrome()
        {
            loginPage.CloseDriver();
        }
    }
}
