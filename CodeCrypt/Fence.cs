using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace CodeCrypt
{
    class Fence:IDisposable
    {
        #region Variables
        private int key = 0;
        #endregion
        #region Constructor
        public Fence(int key)
        {
            this.key = key;
        }
        #endregion
        #region Methods
        public string Encrypting(string text)
        {
            
            var lines = new List<StringBuilder>();

            for (int i = 0; i < key; i++)
                lines.Add(new StringBuilder());

            int currentLine = 0;
            int direction = 1;

            for (int i = 0; i < text.Length; i++)
            {
                lines[currentLine].Append(text[i]);

                if (currentLine == 0)
                    direction = 1;
                else if (currentLine == key - 1)
                    direction = -1;

                currentLine += direction;
            }

            StringBuilder result = new StringBuilder();

            for (int i = 0; i < key; i++)
                result.Append(lines[i].ToString());

            return result.ToString();
        }

        public string Decrypting(string text)
        {
            var lines = new List<StringBuilder>();

            for (int i = 0; i < key; i++)
                lines.Add(new StringBuilder());
            
            //Checking length of lines. Without that we can decrypt our text
            int[] linesLenght = Enumerable.Repeat(0, key).ToArray();

            int currentLine = 0;
            int direction = 1;

            for (int i = 0; i < text.Length; i++)
            {
                linesLenght[currentLine]++;

                if (currentLine == 0)
                    direction = 1;
                else if (currentLine == key - 1)
                    direction = -1;

                currentLine += direction;
            }


            int currentChar = 0;

            for (int line = 0; line < key; line++)
            {
                for (int c = 0; c < linesLenght[line]; c++)
                {
                    lines[line].Append(text[currentChar]);
                    currentChar++;
                }
            }

            StringBuilder result = new StringBuilder();

            currentLine = 0;
            direction = 1;

            int[] currentReadLine = Enumerable.Repeat(0, key).ToArray();

            for (int i = 0; i < text.Length; i++)
            {

                result.Append(lines[currentLine][currentReadLine[currentLine]]);
                currentReadLine[currentLine]++;

                if (currentLine == 0)
                    direction = 1;
                else if (currentLine == key - 1)
                    direction = -1;

                currentLine += direction;
            }

            return result.ToString();

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
