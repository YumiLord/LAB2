using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using SeleniumExtras.WaitHelpers;
using System.Linq.Expressions;
using System.Threading;

public class LoginPage
{
    private IWebDriver driver;
    private WebDriverWait wait;

    public LoginPage(IWebDriver driver)
    {
        this.driver = driver;
        this.wait = new WebDriverWait(driver, TimeSpan.FromSeconds(20));
    }

    // Метод для відкриття сторінки в браузері
    public void OpenLoginPage(string url)
    {
        driver.Navigate().GoToUrl(url);
    }

    // Метод для вибору опції "Login as Bank Manager"
    public void ClickLoginAsBankManager()
    {
        // Знайдіть елемент кнопки "Bank Manager Login" за допомогою селектора і натисніть на неї
        IWebElement loginButton = wait.Until(ExpectedConditions.ElementToBeClickable(By.XPath($"//button[text()='Bank Manager Login']")));
        loginButton.Click();
    }

    public void ClickCustomers()
    {
        IWebElement customers = wait.Until(ExpectedConditions.ElementToBeClickable(By.XPath($"//button[contains(text(),'Customers')]")));
        customers.Click();
    }

    public void inputSearchKey(string searchKey)
    {
        IWebElement searchInput = wait.Until(ExpectedConditions.ElementToBeClickable(By.ClassName("form-control")));
        searchInput.Clear();
        Thread.Sleep(500);
        searchInput.SendKeys(searchKey);
    }
    public List<IWebElement> checkPerson()
    {
        Thread.Sleep(2000);
        IWebElement person = driver.FindElement(By.TagName("tbody")).FindElement(By.TagName("tr"));
        return person.FindElements(By.TagName("td")).ToList<IWebElement>();
    }

    public void CloseDriver()
    {
        driver.Quit();
    }

}
