using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;


namespace improvedDigitalRain
{
    internal class MatrixColumn
    {
        private Random _random;
        private int _currentRow;
        private int _speed;
        private int _length;
        private int _numRows;
        private char[] _columnChars;

        public MatrixColumn(Random random, int numRows)
        {
            _random = random;
            _numRows = numRows;
            _currentRow = _random.Next(numRows);
            _speed = _random.Next(2, 5); // Random speed for each column
            _length = _random.Next(5, 20); // Random length for the drop
            _columnChars = new char[_numRows];

            // Fill column with random characters
            FillColumn();
        }

        private void FillColumn()
        {
            for (int i = 0; i < _numRows; i++)
            {
                _columnChars[i] = GetRandomChar();
            }
        }

        private char GetRandomChar()
        {
            return "ABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789!@#$%^&*()"[
                _random.Next(36)];
        }

        public void Update()
        {
            _currentRow += _speed;

            if (_currentRow >= _numRows)
            {
                _currentRow = 0;
                _speed = _random.Next(2, 5); // Randomize speed again
                _length = _random.Next(5, 20); // Randomize length again
                FillColumn(); // Refill column with random characters
            }
        }

        public void Draw(SpriteBatch spriteBatch, SpriteFont font, int x, int charSize)
        {
            for (int i = 0; i < _length; i++)
            {
                int row = (_currentRow - i + _numRows) % _numRows;

                // Bright head, dim tail
                Color color = i == 0 ? Color.White : Color.Green;

                spriteBatch.DrawString(
                    font,
                    _columnChars[row].ToString(),
                    new Vector2(x, row * charSize),
                    color);
            }
        }
    }
}
