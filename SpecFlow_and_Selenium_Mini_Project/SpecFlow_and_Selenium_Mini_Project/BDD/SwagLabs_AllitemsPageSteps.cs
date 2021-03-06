﻿using NUnit.Framework;
using System;
using TechTalk.SpecFlow;

namespace SpecFlow_and_Selenium_Mini_Project
{
    [Binding]
    public class SwagLabs_AllitemsPageSteps
    {
        public SwagLabs_Website SwagLabs_Website { get; } = new SwagLabs_Website();

        [Given(@"I am on the AllitemsPage")]
        public void GivenIAmOnTheAllitemsPage()
        {
            SwagLabs_Website.SwagLabs_SigninPage.VisitSignInPage();
            SwagLabs_Website.SwagLabs_SigninPage.EnterUsername("standard_user");
            SwagLabs_Website.SwagLabs_SigninPage.EnterPassword("secret_sauce");
            SwagLabs_Website.SwagLabs_SigninPage.ClickSignIn();
        }

        [Given(@"I add item to basket")]
        public void GivenIAddItemToBasket()
        {
            SwagLabs_Website.SwagLabs_AllitemsPage.ClickAddFirstItemToBasket();
        }
        
        [When(@"I click the basket")]
        public void WhenIClickTheBasket()
        {
            SwagLabs_Website.SwagLabs_AllitemsPage.ClickBasket();
        }
        
        [Then(@"I should see the item ""(.*)"" in basket")]
        public void ThenIShouldSeeTheItemInBasket(string itemName)
        {
            Assert.That(SwagLabs_Website.SwagLabs_CheckoutPage.ReturnIteminBasketname(), Does.Contain(itemName));
        }

        [Given(@"Logout then back in")]
        public void GivenLogoutThenBackIn()
        {
            SwagLabs_Website.SwagLabs_AllitemsPage.ClickMenu();
            SwagLabs_Website.SwagLabs_AllitemsPage.ClickLogout();
            SwagLabs_Website.SwagLabs_SigninPage.EnterUsername("standard_user");
            SwagLabs_Website.SwagLabs_SigninPage.EnterPassword("secret_sauce");
            SwagLabs_Website.SwagLabs_SigninPage.ClickSignIn();
        }

        [Given(@"I click the basket")]
        public void GivenIClickTheBasket()
        {
            SwagLabs_Website.SwagLabs_AllitemsPage.ClickBasket();
        }

        [When(@"I remove from basket")]
        public void WhenIRemoveFromBasket()
        {
            SwagLabs_Website.SwagLabs_CheckoutPage.ClickRemoveItem();
        }

        [Then(@"I shouldn't see the item ""(.*)"" in basket")]
        public void ThenIShouldnTSeeTheItemInBasket(string itemName)
        {
            Assert.That(SwagLabs_Website.SwagLabs_CheckoutPage.ReturnIteminBasketname(), Does.Not.Contain(itemName));
        }


        [AfterScenario]
        public void DisposeWebDriver()
        {
            SwagLabs_Website.SeleniumDriver.Quit();
            SwagLabs_Website.SeleniumDriver.Dispose();
        }
    }
}
