using Backend.BO.Commons;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Backend.BLL.Validations
{
    public class UserValidation
    {
        public static void ValidationUserRequest(User user)
        {
            if (string.IsNullOrEmpty(user.Email))
                throw new ArgumentException("Email is empty!");
            if (string.IsNullOrEmpty(user.FirstName))
                throw new ArgumentException("First name is empty!");
            if (string.IsNullOrEmpty(user.Password))
                throw new ArgumentException("Password is empty!");
            if (string.IsNullOrEmpty(user.Role))
                throw new ArgumentException("Last name is empty!");
        }
    }
}
