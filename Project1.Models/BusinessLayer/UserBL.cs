using System;
using System.Collections.Generic;
using System.Text;

namespace Project1.Models.BusinessLayer
{
    public class UserBL
    {
        public void OverdraftPayment(AppUser user, decimal amount)
        {
            user.Overdraft -= amount;
        }
    }
}
