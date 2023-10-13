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
        this.wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
    }

    // Метод для відкриття сторінки в браузері
    public void OpenLoginPage(string url)
    {
        driver.Navigate().GoToUrl(url);
    }

    // Метод для вибору опції "Login as User"
    public void ClickLoginAsUser()
    {
        // Знайдіть елемент кнопки "Login as User" за допомогою селектора і натисніть на неї
        IWebElement loginButton = wait.Until(ExpectedConditions.ElementToBeClickable(By.XPath($"//button[text()='Customer Login']")));
        loginButton.Click();
    }
    public void SelectCustomer(string customerName)
    {
        // Знайдіть елемент випадаючого списку за допомогою селектора
        IWebElement customerDropdown = wait.Until(ExpectedConditions.ElementToBeClickable(By.XPath($"//option[text()='---Your Name---']")));
        customerDropdown.Click();

        // Знайдіть і виберіть варіант "Harry Potter" за текстом
        IWebElement customerOption = wait.Until(ExpectedConditions.ElementToBeClickable(By.XPath($"//option[text()='{customerName}']")));
        customerOption.Click();
    }

    public void ClickLogin ()
    {
        IWebElement loginButton = wait.Until(ExpectedConditions.ElementToBeClickable(By.XPath($"//button[text()='Login']")));
        loginButton.Click();
    }

    public bool IsWelcomeTextVisible()
    {
        try
        {
            wait.Until(ExpectedConditions.ElementToBeClickable(By.XPath("//strong[contains(text(),' Welcome ')]")));
            return true;
        }
        catch (NoSuchElementException)
        {
            return false;
        }
    }

    public void OpenWithdrawMenu ()
    {
        IList<IWebElement> buttons = driver.FindElements(By.CssSelector(".btn.btn-lg.tab"));
        wait.Until(ExpectedConditions.ElementToBeClickable(buttons[2]));
        buttons[2].Click();
    }

    public void EnterAmount()
    {
        try
        {
            // Знайдіть елемент поля "Deposit" за допомогою селектора
            IList<IWebElement> amounts = driver.FindElements(By.XPath("//strong[contains(@class, 'ng-binding')]"));

            // Отримайте текстовий вміст цього елемента
            string balanceText = amounts[1].Text;

            // Очистіть текст від непотрібних символів та пробілів
            string balanceValue = balanceText.Replace(", Balance :", "").Trim();

            int balance = Convert.ToInt32(balanceValue);

            if (balance < 1)
            {
                throw new Exception("Balance is less than 1.");
                // Або використати return, якщо хочете завершити цей тест і перейти до наступного
                // return;
            }
            string depositAmount = Convert.ToString(balance/2);


            // Знайдіть елемент поля "amount" за допомогою селектора
            IWebElement amountField = wait.Until(ExpectedConditions.ElementIsVisible(By.XPath("//input[contains(@class, 'form-control')]")));

            // Вставте зчитану суму в поле "amount"
            amountField.Clear(); // Очистити поле перед вставкою нової суми
            amountField.SendKeys(depositAmount);
            Thread.Sleep(1000);
        }
        catch(Exception ex) {
            Console.WriteLine("Test failed: " + ex.Message);
        }
        
    }
    public void ClickWithdraw()
    {
        IWebElement withdrawButton = driver.FindElement(By.CssSelector(".btn.btn-default"));
        wait.Until(ExpectedConditions.ElementToBeClickable(withdrawButton));
        withdrawButton.Click();
        Thread.Sleep(5000);
    }

    public bool IsSucseedTextVisible ()
    {
        try
        {
            wait.Until(ExpectedConditions.ElementToBeClickable(By.XPath("//span[contains(text(),'Transaction successful')]")));
            return true;
        }
        catch (NoSuchElementException)
        {
            return false;
        }
    }

    public bool IsErrorTextVisible()
    {
        try
        {
            wait.Until(ExpectedConditions.ElementToBeClickable(By.XPath("//span[contains(text(),'Transaction Failed. You can not withdraw amount more than the balance.')]")));
            return true;
        }
        catch (NoSuchElementException)
        {
            return false;
        }
    }

    public void EnterMoreAmount()
    {
        try
        {
            // Знайдіть елемент поля "Deposit" за допомогою селектора
            IList<IWebElement> amounts = driver.FindElements(By.XPath("//strong[contains(@class, 'ng-binding')]"));

            // Отримайте текстовий вміст цього елемента
            string balanceText = amounts[1].Text;

            // Очистіть текст від непотрібних символів та пробілів
            string balanceValue = balanceText.Replace(", Balance :", "").Trim();

            int balance = Convert.ToInt32(balanceValue);

            if (balance < 1)
            {
                throw new Exception("Balance is less than 1.");
                // Або використати return, якщо хочете завершити цей тест і перейти до наступного
                // return;
            }
            string depositAmount = Convert.ToString(balance * 2);


            // Знайдіть елемент поля "amount" за допомогою селектора
            IWebElement amountField = wait.Until(ExpectedConditions.ElementIsVisible(By.XPath("//input[contains(@class, 'form-control')]")));

            // Вставте зчитану суму в поле "amount"
            amountField.Clear(); // Очистити поле перед вставкою нової суми
            amountField.SendKeys(depositAmount);
            Thread.Sleep(1000);
        }
        catch (Exception ex)
        {
            Console.WriteLine("Test failed: " + ex.Message);
        }

    }

    public void CloseDriver()
    {
        driver.Quit();
    }

}
