using Project1.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Project1.UI.ViewModels
{
    public class UserVM
    {
        public AppUser User { get; set; }
        public List<OverdraftPaymentRecord> Payments { get; set; }
    }
}
