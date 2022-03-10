using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lab4.Models
{
    public class RomanNumber : ICloneable, IComparable
    {
        public ushort _number;
        private static int[] values = new int[] { 1000, 900, 500, 400, 100, 90, 50, 40, 10, 9, 5, 4, 1 };
        public static string[] basic_roman_numerals = new string[] { "M", "CM", "D", "CD", "C", "XC", "L", "XL", "X", "IX", "V", "IV", "I" };

        public RomanNumber(ushort n)
        {
            if (n <= 0) throw new RomanNumberException("!Число < 0 или = 0!");
            else this._number = n;
        }

        public static RomanNumber operator +(RomanNumber? n1, RomanNumber? n2)
        {
            int num = n1._number + n2._number;

            if (num == 0) throw new RomanNumberException("!Не удалось сложить числа, так как сумма = 0. Перепроверьте числа!");
            else if (num < 0) throw new RomanNumberException("!Не удалось сложить числа, так как сумма < 0. Перепроверьте числа!");
            else if (num > 3999) throw new RomanNumberException("!Не удалось сложить числа, так как сумма > 3999. Перепроверьте числа!");
            else return new RomanNumber((ushort)num);

        }

        public static RomanNumber operator -(RomanNumber? n1, RomanNumber? n2)
        {
            int num = n1._number - n2._number;
            if (num == 0) throw new RomanNumberException("!Разность чисел = 0!");
            else if (num < 0) throw new RomanNumberException("!Разность чисел < 0!");
            else
            {
                RomanNumber result = new((ushort)num);
                return result;
            }
        }

        public static RomanNumber operator *(RomanNumber? n1, RomanNumber? n2)
        {
            int num = n1._number * n2._number;
            if (num == 0) throw new RomanNumberException("!Произведение = 0. Перепроверьте числа!");
            else if (num < 0) throw new RomanNumberException("!Произведение < 0. Перепроверьте числа!");
            else if (num > 3999) throw new RomanNumberException("!Произведение > 3999. Перепроверьте числа!");
            if (num == 0) throw new RomanNumberException("!Произведение = 0. Перепроверьте числа!");
            else
            {
                RomanNumber result = new((ushort)num);
                return result;
            }
        }

        public static RomanNumber operator /(RomanNumber? n1, RomanNumber? n2)
        {

            if (n2._number == 0) throw new RomanNumberException($"{n1} !На 0 делить нельзя!");
            else
            {
                int num = n1._number / n2._number;
                if (num == 0) throw new RomanNumberException("!Частное не может = 0!");
                else
                {
                    RomanNumber result = new((ushort)num);
                    return result;                    
                }
            }
        }

        public static implicit operator int(RomanNumber v)
        {
            throw new NotImplementedException();
        }

        public override string ToString()
        {
            int tmp = _number;
            StringBuilder result = new StringBuilder();
            for (int i = 0; i < 13; i++)
            {
                while (tmp >= values[i])
                {
                    tmp -= (ushort)values[i];
                    result.Append(basic_roman_numerals[i]);
                }
            }
            if (result.ToString() == "")
                throw new RomanNumberException("Преобразование чисел в римские цифры невозможно");
            else
                return result.ToString();

        }

        public object Clone()
        {
            return new RomanNumber(_number);
        }

        public int CompareTo(object obj)
        {
            if (obj is RomanNumber basic_roman_numerals)
                return _number.CompareTo(basic_roman_numerals._number);
            else
                throw new RomanNumberException("!Это не Римская цифра!");
        }

    }

}

