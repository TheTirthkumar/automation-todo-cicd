using Microsoft.Playwright;
using NUnit.Framework;
using System.Threading.Tasks;
 
namespace example
{
    public class example_login
    {
        private const string BaseUrl = "https://www.saucedemo.com/v1/index.html";
        private const string username = "standard_user";
        private const string Password = "secret_sauce";
 
        public static async Task<IPage> LoginAsync(IPage page)
        {
            // Navigate to the login page
            await page.GotoAsync(BaseUrl);
            await Task.Delay(500);
 
            // Enter email
            await page.WaitForSelectorAsync("input[placeholder='Username']");
            await page.FillAsync("input[placeholder='Username']", username);
            await Task.Delay(1000);
 
            // Enter password
            await page.WaitForSelectorAsync("input[placeholder='Password']");
            await page.FillAsync("input[placeholder='Password']", Password);
            await Task.Delay(1000);
 
            // Submit the login form
            await page.ClickAsync("input[type='submit']");
            await Task.Delay(2000);
 
            return page;
        }
 
        [Test]
        public async Task Test_example()
        {
            // Initialize Playwright
            using var playwright = await Playwright.CreateAsync();
           
            // Launch browser
            await using var browser = await playwright.Chromium.LaunchAsync(new BrowserTypeLaunchOptions
            {
                Headless = true,
                
            });
 
            var context = await browser.NewContextAsync(new() { ViewportSize = ViewportSize.NoViewport });
            var page = await context.NewPageAsync();
 
            try
            {
                // Perform login
                page = await LoginAsync(page);
            }
            finally
            {
                // Clean up
                await context.CloseAsync();
                await browser.CloseAsync();
            }
        }
    }
}
