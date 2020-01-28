using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodeCrypt
{
    class CircleCipher:IDisposable
    {
        #region Variables
        private string text = String.Empty;
        private char[] FullKey = new char[] { };
        #endregion

        #region constructor
        public CircleCipher(string key,string text)
        {
            this.text = text;
            FullKey = key.ToCharArray();
        }
        #endregion

        #region Functions
        public string Encrypting()
        {
            //local variables which are needed to operation
            int move = 0;//count of steps to move circle
            int index = 0;//index of key character
            int maxIndex = FullKey.Length;//count of key characters
            int temp;//temporary variable which are needed to encrypt
            string result = String.Empty;//result of encrypting

            foreach(char c in text)
            {
                if (Char.IsWhiteSpace(c))
                {
                    //If actuall character is a space, add to result
                    result += c;
                }
                else
                {
                    //Else if actuall character is an other character than space 
                    //do encrypting and add to result
                    move += (int)FullKey[index%maxIndex];
                    temp = (int)c;
                    temp += move;
                    temp = temp % 256;
                    result += (char)temp;
                    index++;
                }
            }

            return result;
        }

        public string Decrypting()
        {
            //local variables which are needed to operation
            int move = 0;//count of steps to move circle
            int index = 0;//index of key character
            int maxIndex = FullKey.Length;//count of key characters
            int temp;//temporary variable which are needed to decrypt
            string result = String.Empty;//result of decrypting

            foreach (char c in text)
            {
                if (Char.IsWhiteSpace(c))
                {
                    //If actuall character is a space, add to result
                    result += c;
                }
                else
                {
                    //Else if actuall character is an other character than space 
                    //do decrypting and add to result
                    move += (int)FullKey[index % maxIndex];
                    temp = (int)c;
                    temp -= move;
                    if (temp < 0)
                    {
                        temp *= -1;
                        temp = 256 - temp;
                    }
                    
                    result += (char)temp;
                    index++;
                }
            }

            return result;
        }

        #endregion

        #region IDisposable Support
        private bool disposedValue = false; 

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
