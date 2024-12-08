using System.Text.RegularExpressions;
using Microsoft.Playwright;
using NUnit.Framework;

namespace PlaywrightTests.Examples;

[TestFixture]
public class ExampleTestWithoutPageTest
{
    private IPlaywright _playwright;
    private IBrowser _browser;
    private IBrowserContext _context;
    private IPage _page;

    
    [SetUp]
    public async Task SetUp()
    {
        // Initialize Playwright, Browser, BrowserContext, and Page
        _playwright = await Playwright.CreateAsync();
        _browser = await _playwright.Chromium.LaunchAsync(new BrowserTypeLaunchOptions { Headless = true });
        _context = await _browser.NewContextAsync();
        _page = await _context.NewPageAsync();
    }
    
    [TearDown]
    public async Task TearDown()
    {
        // Clean up resources
        await _page.CloseAsync();
        await _context.CloseAsync();
        await _browser.CloseAsync();
        _playwright.Dispose();
    }
    
    [Test]
    public async Task VerifyPageTitle()
    {
        // Navigate to a page
        await _page.GotoAsync("https://playwright.dev");

        // Use Expect assertions
        await Assertions.Expect(_page).ToHaveTitleAsync(new Regex("Playwright"));
    }
}