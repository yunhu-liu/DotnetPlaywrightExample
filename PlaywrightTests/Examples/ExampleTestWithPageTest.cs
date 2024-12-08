using System.Text.RegularExpressions;
using Microsoft.Playwright;
using Microsoft.Playwright.NUnit;
using NUnit.Framework;

namespace PlaywrightTests.Examples;

[Parallelizable(ParallelScope.Self)]
[TestFixture]
public class ExampleTestWithPageTest : PageTest
{
    [Test]
    public async Task HasTitle()
    {
        // Navigate to a webpage
        await Page.GotoAsync("https://playwright.dev");

        // Assert the title contains "Playwright"
        await Expect(Page).ToHaveTitleAsync(new Regex("Playwright"));        
    }
    
    [Test]
    public async Task ClickLink()
    {
        // Navigate to a webpage
        await Page.GotoAsync("https://playwright.dev");

        // Click the "Get started" link
        await Page.GetByRole(AriaRole.Link, new() { Name = "Get started" }).ClickAsync();

        // Verify the "Installation" heading is visible
        await Expect(Page.GetByRole(AriaRole.Heading, new() { Name = "Installation" })).ToBeVisibleAsync();
    }
}