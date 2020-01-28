using System;
using System.Text;

namespace CodeCrypt
{
    class Vigenere:IDisposable
    {
        #region Variables
        private string key = String.Empty;
        private string text = String.Empty;
        private char[] id = new char[] {'A','B','C', 'D', 'E', 'F' , 'G', 'H', 'I' , 'J', 'K', 'L', 'M', 'N', 'O'
            ,'P','Q','R','S','T','U','V','W','X','Y','Z'};
        private char[,] id2d = new char[,] { {'A','B','C', 'D', 'E', 'F' , 'G', 'H', 'I' , 'J', 'K', 'L', 'M', 'N', 'O'
            ,'P','Q','R','S','T','U','V','W','X','Y','Z'}, {'B','C', 'D', 'E', 'F' , 'G', 'H', 'I' , 'J', 'K', 'L', 'M', 'N', 'O'
            ,'P','Q','R','S','T','U','V','W','X','Y','Z','A'}, {'C', 'D', 'E', 'F' , 'G', 'H', 'I' , 'J', 'K', 'L', 'M', 'N', 'O'
            ,'P','Q','R','S','T','U','V','W','X','Y','Z','A','B'}, { 'D', 'E', 'F' , 'G', 'H', 'I' , 'J', 'K', 'L', 'M', 'N', 'O'
            ,'P','Q','R','S','T','U','V','W','X','Y','Z','A','B','C'}, { 'E', 'F' , 'G', 'H', 'I' , 'J', 'K', 'L', 'M', 'N', 'O'
            ,'P','Q','R','S','T','U','V','W','X','Y','Z','A','B','C', 'D'}, { 'F' , 'G', 'H', 'I' , 'J', 'K', 'L', 'M', 'N', 'O'
            ,'P','Q','R','S','T','U','V','W','X','Y','Z','A','B','C', 'D', 'E'}, {'G', 'H', 'I' , 'J', 'K', 'L', 'M', 'N', 'O'
            ,'P','Q','R','S','T','U','V','W','X','Y','Z','A','B','C', 'D', 'E', 'F'}, {'H', 'I' , 'J', 'K', 'L', 'M', 'N', 'O'
            ,'P','Q','R','S','T','U','V','W','X','Y','Z','A','B','C', 'D', 'E', 'F','G'}, {'I' , 'J', 'K', 'L', 'M', 'N', 'O'
            ,'P','Q','R','S','T','U','V','W','X','Y','Z','A','B','C', 'D', 'E', 'F' , 'G', 'H'}, {'J', 'K', 'L', 'M', 'N', 'O'
            ,'P','Q','R','S','T','U','V','W','X','Y','Z','A','B','C', 'D', 'E', 'F' , 'G', 'H','I'}, {'K', 'L', 'M', 'N', 'O'
            ,'P','Q','R','S','T','U','V','W','X','Y','Z','A','B','C', 'D', 'E', 'F' , 'G', 'H','I' , 'J'}, {'L', 'M', 'N', 'O'
            ,'P','Q','R','S','T','U','V','W','X','Y','Z','A','B','C', 'D', 'E', 'F' , 'G', 'H','I' , 'J', 'K'}, { 'M', 'N', 'O'
            ,'P','Q','R','S','T','U','V','W','X','Y','Z','A','B','C', 'D', 'E', 'F' , 'G', 'H','I' , 'J', 'K', 'L'}, {'N', 'O'
            ,'P','Q','R','S','T','U','V','W','X','Y','Z','A','B','C', 'D', 'E', 'F' , 'G', 'H','I' , 'J', 'K', 'L', 'M'}, {'O'
            ,'P','Q','R','S','T','U','V','W','X','Y','Z','A','B','C', 'D', 'E', 'F' , 'G', 'H','I' , 'J', 'K', 'L', 'M', 'N'}, {'P','Q','R','S','T','U','V',
             'W','X','Y','Z','A','B','C', 'D', 'E', 'F' , 'G', 'H','I' , 'J', 'K', 'L', 'M', 'N', 'O'}, {'Q','R','S','T','U','V','W','X',
             'Y','Z','A','B','C', 'D', 'E', 'F' , 'G', 'H','I' , 'J', 'K', 'L', 'M', 'N', 'O','P'}, {'R','S','T','U','V','W','X',
             'Y','Z','A','B','C', 'D', 'E', 'F' , 'G', 'H','I' , 'J', 'K', 'L', 'M', 'N', 'O','P','Q'}, {'S','T','U','V','W','X',
             'Y','Z','A','B','C', 'D', 'E', 'F' , 'G', 'H','I' , 'J', 'K', 'L', 'M', 'N', 'O','P','Q','R'}, {'T','U','V','W','X',
             'Y','Z','A','B','C', 'D', 'E', 'F' , 'G', 'H','I' , 'J', 'K', 'L', 'M', 'N', 'O','P','Q','R','S'}, {'U','V','W','X',
             'Y','Z','A','B','C', 'D', 'E', 'F' , 'G', 'H','I' , 'J', 'K', 'L', 'M', 'N', 'O','P','Q','R','S','T'}, {'V','W','X',
             'Y','Z','A','B','C', 'D', 'E', 'F' , 'G', 'H','I' , 'J', 'K', 'L', 'M', 'N', 'O','P','Q','R','S','T','U'}, {'W','X',
             'Y','Z','A','B','C', 'D', 'E', 'F' , 'G', 'H','I' , 'J', 'K', 'L', 'M', 'N', 'O','P','Q','R','S','T','U','V'}, {'X',
             'Y','Z','A','B','C', 'D', 'E', 'F' , 'G', 'H','I' , 'J', 'K', 'L', 'M', 'N', 'O','P','Q','R','S','T','U','V','W'}, {'Y','Z','A','B','C', 'D', 'E', 'F' , 'G', 'H','I' 
                , 'J', 'K', 'L', 'M', 'N', 'O','P','Q','R','S','T','U','V','W','X'}, {'Z','A','B','C', 'D', 'E', 'F' , 'G', 'H','I' , 'J'
                , 'K', 'L', 'M', 'N', 'O','P','Q','R','S','T','U','V','W','X','Y'} };
        private char[] FullKey = new char[] { };
        #endregion

        #region Constructor
        public Vigenere(string key,string text)
        {
            this.key = key.ToUpper();
            this.text = text.ToUpper();
            FullKey = this.key.ToCharArray();
        }
        #endregion

        #region Methods

        public string Encrypting()
        {
            //local variables which are needed to operation
            int index = 0;//index of key character
            int maxIndex = FullKey.Length;//count of key characters
            char temp;//temporary variable which are needed to encrypt
            string result = String.Empty;//result of encrypting

            foreach (char c in text)
            {
                if (!Char.IsLetter(c))
                {
                    //If actuall character is a space, add to result
                    result += c;
                }
                else
                {
                    //Else if actuall character is an other character than space 
                    //do encrypting and add to result
                    int keyCharIndex;
                    int textCharIndex = Array.IndexOf(id, c);

                    if (maxIndex == 1)
                    {
                        temp = id2d[textCharIndex,Array.IndexOf(id,FullKey[0])];
                    }
                    else
                    {
                        keyCharIndex = Array.IndexOf(id, FullKey[index % maxIndex]);
                        temp = id2d[textCharIndex,keyCharIndex];
                        index++;
                    }
                    result += temp;
                }
            }

            return result;
        }

        public string Decrypting()
        {
            string output = string.Empty;
            int nonAlphaCharCount = 0;

            for (int i = 0; i < text.Length; ++i)
            {
                if (char.IsLetter(text[i]))
                {
                    char offset = 'A';
                    int keyIndex = (i - nonAlphaCharCount) % key.Length;
                    int k = char.ToUpper(key[keyIndex])- offset;
                    char ch = (char)((Mod(((text[i] - k) - offset), 26)) + offset);
                    output += ch;
                }
                else
                {
                    output += text[i];
                    ++nonAlphaCharCount;
                }
            }

            return output;
        }

        private static int Mod(int a, int b)
        {
            return (a % b + b) % b;
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
