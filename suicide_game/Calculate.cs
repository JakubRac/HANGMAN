using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace suicide_game
{
    internal class Calculate
    {
        string password;
        public Calculate(string password)
        {
            this.password = password;
        }

        public string HashPass()
        {
            string hashPass="";
            for(int i = 0;i<password.Length;i++){
                hashPass += "*";
            }
            return hashPass;
        }

        public bool CheckChar(char c, StringBuilder hashPass_builder,Label Text)
        {
            bool find = false;
            for (int i = 0; i < password.Length; i++)
            {
                if (password[i] == c)
                {
                    hashPass_builder[i] = c;
                    find = true;
                }
            }
            Text.Text = hashPass_builder.ToString();
            return find;
        }

        

    }
}
