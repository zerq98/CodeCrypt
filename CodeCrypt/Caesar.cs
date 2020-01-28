using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodeCrypt
{
    class Caesar: IDisposable
    {
        private int code = 0;

        public Caesar(int i)
        {
            code = i;
        }

        public string Encrypting(String txt)
        {
            char[] alpha = new char[26] {'A','B','C', 'D', 'E', 'F' , 'G', 'H', 'I' , 'J', 'K', 'L', 'M', 'N', 'O'
            ,'P','Q','R','S','T','U','V','W','X','Y','Z'};
            string temp = String.Empty;

            foreach(char c in txt)
            {
                char d = '\0';

                if (Char.IsDigit(c))
                {
                    int t = Int32.Parse(c.ToString());
                    t += code;
                    if (t >= 10)
                    {
                        t -= 10;
                    }

                    temp += t;
                }
                else if (!Char.IsLetterOrDigit(c))
                {
                    d = c;
                    temp += d;
                }
                else
                {
                    bool upper = Char.IsUpper(c);
                    int id = Array.IndexOf(alpha, Char.ToUpper(c));
                    id += code;
                    d = alpha[id % 26];

                    if (!upper) d=Char.ToLower(d);

                    temp += d;
                }

                
            }
            return temp;
        }

        public string Decrypting(String txt)
        {
            char[] alpha = new char[26] {'Z','Y','X','W', 'V', 'U', 'T' ,'S', 'R', 'Q' , 'P', 'O', 'N' , 'M', 'L', 'K'
            ,'J','I','H','G','F','E','D','C','B','A'};
            string temp = String.Empty;

            foreach (char c in txt)
            {
                char d = '\0';

                if (Char.IsDigit(c))
                {
                    int t = Int32.Parse(c.ToString());
                    t -= code;
                    if (t < 0)
                    {
                        t += 10;
                    }

                    temp += t;
                }
                else if (!Char.IsLetterOrDigit(c))
                {
                    d = c;
                    temp += d;
                }
                else
                {
                    bool upper = Char.IsUpper(c);
                    int id = Array.IndexOf(alpha, Char.ToUpper(c));
                    id += code;
                    d = alpha[id % 26];

                    if (!upper) d = Char.ToLower(d);

                    temp += d;
                }


            }
            return temp;
        }

        #region IDisposable Support
        private bool disposedValue = false; // To detect redundant calls

        protected virtual void Dispose(bool disposing)
        {
            if (!disposedValue)
            {
                if (disposing)
                {
                  
                }

                disposedValue = true;
            }
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
        #endregion
    }
}
