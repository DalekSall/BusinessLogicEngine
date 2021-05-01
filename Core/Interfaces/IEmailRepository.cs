using Core.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Core.Interfaces
{
    public interface IEmailRepository
    {
        public Task<bool> SendActivationMail(Order order);
        public Task<bool> SendUpgradeMail(Order order);
    }
}
