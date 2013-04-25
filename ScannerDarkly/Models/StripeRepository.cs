using System;
using Stripe;

namespace ScannerDarkly.Models
{
    public class StripeRepository
    {
        public StripeCharge ChargeCustomer(string stripeCustomerId, int amount, string description)
        {
            var charge = new StripeChargeCreateOptions();

            // todo - validate

            charge.AmountInCents = amount;
            charge.Currency = "usd";
            charge.Description = description;
            charge.CustomerId = stripeCustomerId;

            try
            {
                var chargeService = new StripeChargeService();
                return chargeService.Create(charge);
            }
            catch (StripeException sex)
            {
                // todo
                throw new Exception(sex.Message);
            }
            catch (Exception ex)
            {
                // todo
                throw ex;
            } 
        }

        public StripeCustomer CreateCustomer(string email, string description)
        {
            return CreateCustomer(email, description, string.Empty, string.Empty, 0);
        }

        public StripeCustomer CreateCustomer(string email, string description, string tokenId, int quantity)
        {
            return CreateCustomer(email, description, tokenId, string.Empty, quantity);
        }

        public StripeCustomer CreateCustomer(string email, string description, string tokenId, string planId, int quantity)
        {
            var customerOptions = new StripeCustomerCreateOptions();

            // todo - validate

            customerOptions.Email = email;
            customerOptions.Description = string.IsNullOrEmpty(description) ? string.Empty : description;

            if (!string.IsNullOrEmpty(tokenId)) customerOptions.TokenId = tokenId;
            if (!string.IsNullOrEmpty(planId)) customerOptions.PlanId = planId;

            try
            {
                var customerService = new StripeCustomerService();
                return customerService.Create(customerOptions);
            }
            catch (StripeException sex)
            {
                // todo
                throw new Exception(sex.Message);
            }
            catch (System.Exception ex)
            {
                // todo
                throw ex;
            }
        }

        //public StripeCharge SubscribeToPlan(string stripeCustomerId, string stripePlanId, int quanity, DateTime start)
        //{
        //    var sub = new StripeSubscription();


        //    // todo - validate

        //    sub.CustomerId = stripeCustomerId;
        //    sub.StripePlan = stripePlanId;
        //    sub.Quantity = quantity;
        //    sub.Start = start;

        //    try
        //    {
        //        var chargeService = new StripeChargeService();
        //        return chargeService.Create(charge);
        //    }
        //    catch (StripeException sex)
        //    {
        //        // todo
        //        throw new Exception(sex.Message);
        //    }
        //    catch (Exception ex)
        //    {
        //        // todo
        //        throw ex;
        //    }
        //}
    }
}
