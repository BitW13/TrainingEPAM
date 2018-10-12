using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HW5
{
    class BigNumber
    {
        private int[] _value;
        private bool IsNegative { get; set; }

        public BigNumber(int number) : this(number.ToString())
        { }
        public BigNumber(byte number)
        {
            SetValue(number);
        }
        public BigNumber(long number) : this(number.ToString())
        { }
        public BigNumber(string number)
        {
            SetValue(number);
        }

        private static int[] GetUpdateBigNumber(int[] array, string strNumberOneCell)
        {
            char[] arrayOfStr = strNumberOneCell.ToCharArray();
            char t = arrayOfStr[0];
            arrayOfStr[0] = arrayOfStr[arrayOfStr.Length - 1];
            arrayOfStr[arrayOfStr.Length - 1] = t;
            strNumberOneCell = "";
            for (int i = 0; i < arrayOfStr.Length; i++)
            {
                strNumberOneCell += arrayOfStr[i];
            }
            Array.Resize<int>(ref array, array.Length + 1);
            array[array.Length - 1] = Convert.ToInt32(strNumberOneCell);
            return array;
        }

        public void Subtract(BigNumber bigNumber)
        {
            int[] anotherValue = GetArrayOfValue(bigNumber.GetValueWithoutSign());

            if ((!this.IsNegative && !bigNumber.IsNegative) || (this.IsNegative && bigNumber.IsNegative))
            {                
                _value = AddValue(_value, anotherValue);
            }
            if ((!this.IsNegative && bigNumber.IsNegative) || (this.IsNegative && !bigNumber.IsNegative))
            {
                if (IsFirstValueThanSecondValue(_value, anotherValue))
                {
                    _value = SubtractValue(_value, anotherValue);
                }
                else
                {
                    _value = SubtractValue(anotherValue, _value);
                    IsNegative = !IsNegative;
                }
            }
        }
        private static bool IsFirstValueThanSecondValue(int[] firstValue, int[] secondValue)
        {
            bool isFirstValueThanSecondValue=true;
            if (firstValue.Length > secondValue.Length)
            {
                isFirstValueThanSecondValue = true;
            }
            else if (firstValue.Length < secondValue.Length)
            {
                isFirstValueThanSecondValue = false;
            }
            else
            {
                for(int i=firstValue.Length-1; i>=0; i--)
                {
                    if (firstValue[i] > secondValue[i])
                    {
                        isFirstValueThanSecondValue = true;
                        break;
                    }
                    if (firstValue[i] < secondValue[i])
                    {
                        isFirstValueThanSecondValue = false;
                        break;
                    }
                }
            }
            return isFirstValueThanSecondValue;
        }
        private static int[] SubtractValue(int[] firstValue, int[] secondValue)
        {
            for(int i=firstValue.Length-1; i>=0; i--)
            {
                if (firstValue[i] - secondValue[i] < 0)
                {
                    firstValue[i] = firstValue[i] - secondValue[i] + 1000;
                    firstValue[i + 1] -= 1;
                }
                else
                {
                    firstValue[i] -= secondValue[i];
                }
            }
            return firstValue;
        }
        public static BigNumber Subtract(BigNumber bigNumber1, BigNumber bigNumber2)
        {
            int[] firstValue = GetArrayOfValue(bigNumber1.GetValueWithoutSign());
            int[] secondValue = GetArrayOfValue(bigNumber2.GetValueWithoutSign());
            int[] newValue = null;
            bool isNegative=bigNumber1.IsNegative;
            if ((!bigNumber1.IsNegative && !bigNumber2.IsNegative) || (bigNumber1.IsNegative && bigNumber2.IsNegative))
            {
                if (IsFirstValueThanSecondValue(firstValue, secondValue))
                {
                    newValue = SubtractValue(firstValue, secondValue);
                }
                else
                {
                    newValue = SubtractValue(secondValue, firstValue);
                    isNegative = !isNegative;
                }
                newValue = SubtractValue(firstValue, secondValue);
            }
            if ((!bigNumber1.IsNegative && bigNumber2.IsNegative) || (bigNumber1.IsNegative && !bigNumber2.IsNegative))
            {
                if (IsFirstValueThanSecondValue(firstValue, secondValue))
                {
                    newValue = SubtractValue(firstValue, secondValue);
                }
                else
                {
                    newValue = SubtractValue(secondValue, firstValue);
                    isNegative = !isNegative;
                }
            }
            if ((!bigNumber1.IsNegative && bigNumber2.IsNegative) || (bigNumber1.IsNegative && !bigNumber2.IsNegative))
            {
                newValue = AddValue(firstValue, secondValue);
            }

            return new BigNumber(GetValue(newValue, isNegative));
        }
        public static BigNumber operator -(BigNumber bigNumber1, BigNumber bigNumber2)
        {
            return Subtract(bigNumber1, bigNumber2);
        }

        public void Add(BigNumber bigNumber)
        {
            int[] anotherValue = GetArrayOfValue(bigNumber.GetValueWithoutSign());

            if((!this.IsNegative && !bigNumber.IsNegative) || (this.IsNegative && bigNumber.IsNegative))
            {
                _value = AddValue(_value, anotherValue);
            }
            if((!this.IsNegative && bigNumber.IsNegative) || (this.IsNegative && !this.IsNegative))
            {
                if (IsFirstValueThanSecondValue(_value, anotherValue))
                {
                    _value = SubtractValue(_value, anotherValue);
                }
                else
                {
                    _value = SubtractValue(anotherValue, _value);
                    IsNegative = !IsNegative;
                }
            }
        }
        private static int[] AddValue(int[] firstValue, int[] secondValue)
        {
            int length = 0;
            if (firstValue.Length >= secondValue.Length)
            {
                length = firstValue.Length;
            }
            else
            {
                length = secondValue.Length;
            }
            int[] additionalValues = new int[length+1];
            for (int i = 0; i < length; i++)
            {
                if (i > firstValue.Length - 1)
                {
                    Array.Resize<int>(ref firstValue, firstValue.Length + 1);
                    firstValue[firstValue.Length - 1] = secondValue[i];
                }
                else if (i <= firstValue.Length - 1 && i <= secondValue.Length - 1)
                {
                    if (firstValue[i] + secondValue[i] > 999)
                    {
                        firstValue[i] = firstValue[i] + secondValue[i] - 1000;
                        if (i + 1 > additionalValues.Length - 1)
                        {
                            Array.Resize<int>(ref additionalValues, additionalValues.Length + 1);
                        }
                        additionalValues[i + 1] += 1;
                    }
                    else
                    {
                        firstValue[i] += secondValue[i];
                    }
                }
            }
            for (int i = 0; i < firstValue.Length; i++)
            {
                firstValue[i] += additionalValues[i];
            }
            return firstValue;
        }
        public static BigNumber operator +(BigNumber bigNumber1, BigNumber bigNumber2)
        {
            return Add(bigNumber1, bigNumber2);
        }
        public static BigNumber Add(BigNumber bigNumber1, BigNumber bigNumber2)
        {
            int[] firstValue = GetArrayOfValue(bigNumber1.GetValueWithoutSign());
            int[] secondValue = GetArrayOfValue(bigNumber2.GetValueWithoutSign());
            int[] newValue=null;
            bool isNegative=false;
            if ((!bigNumber1.IsNegative && !bigNumber2.IsNegative) || (bigNumber1.IsNegative && bigNumber2.IsNegative))
            {
                if (bigNumber1.IsNegative)
                {
                    isNegative = true;
                }
                else
                {
                    isNegative = false;
                }
                newValue = AddValue(firstValue, secondValue);
            }
            if ((!bigNumber1.IsNegative && bigNumber2.IsNegative) || (bigNumber1.IsNegative && !bigNumber2.IsNegative))
            {
                if (IsFirstValueThanSecondValue(firstValue, secondValue))
                {
                    firstValue = SubtractValue(firstValue, secondValue);
                }
                else
                {
                    firstValue = SubtractValue(secondValue, firstValue);
                    isNegative = !isNegative;
                }
            }

            return new BigNumber(GetValue(newValue, isNegative));
        }

        public void MultiplyByConst(byte value)
        {
            MultiplyByConst(value.ToString());
        }
        public void MultiplyByConst(int value)
        {
            MultiplyByConst(value.ToString());
        }
        public void MultiplyByConst(long value)
        {
            MultiplyByConst(value.ToString());
        }
        public void MultiplyByConst(string value)
        {
            _value = GetArrayOfValue((Multiply(this, new BigNumber(value))).GetValue());
        }

        private static int[] AddZeroCellsToArray(int[] array, int numberOfCells)
        {
            int[] newArray = new int[array.Length + numberOfCells];
            for(int i=0; i<array.Length; i++)
            {
                newArray[i+numberOfCells] = array[i];
            }
            return newArray;
        }
        private static int[] GetSumMultiplicationResults(List<int[]> multiplicationResults, List<int[]> multiplicationIndexes)
        {
            int[] value = multiplicationResults[0];

            for(int i=1; i<multiplicationResults.Count; i++)
            {
                value = AddValue(value, AddZeroCellsToArray(multiplicationResults[i], multiplicationIndexes[i][0] + multiplicationIndexes[i][1]));
            }
            return value;
        }
        private static int[] MultiplyValue(int[] firstValue, int[] secondValue)
        {
            List<int[]> multiplicationResults = new List<int[]>();
            List<int[]> multiplicationIndexes = new List<int[]>();
            for (int j = 0; j < secondValue.Length; j++)
            {
                for (int i = 0; i < firstValue.Length; i++)
                {
                    multiplicationResults.Add(GetArrayOfValue((firstValue[i] * secondValue[j]).ToString()));
                    multiplicationIndexes.Add(new int[] { i, j });
                }
            }
            return GetSumMultiplicationResults(multiplicationResults, multiplicationIndexes);
        }
        public void Multiply(BigNumber bigNumber)
        {
            if ((this.IsNegative && bigNumber.IsNegative) || (!this.IsNegative && bigNumber.IsNegative))
            {
                IsNegative = !IsNegative;
            }
            _value = MultiplyValue(_value, GetArrayOfValue(bigNumber.GetValueWithoutSign()));
        }
        public static BigNumber Multiply(BigNumber bigNumber1, BigNumber bigNumber2)
        {
            bool isNegative = bigNumber1.IsNegative;
            if ((bigNumber1.IsNegative && bigNumber2.IsNegative) || (!bigNumber1.IsNegative && bigNumber2.IsNegative))
            {
                isNegative = !bigNumber1.IsNegative;
            }
            int[] newValue = MultiplyValue(GetArrayOfValue(bigNumber1.GetValueWithoutSign()), GetArrayOfValue(bigNumber2.GetValueWithoutSign()));
            return new BigNumber(GetValue(newValue, isNegative));
        }
        public static BigNumber operator *(BigNumber bigNumber1, BigNumber bigNumber2)
        {
            return Multiply(bigNumber1, bigNumber2);
        }

        private static int[] GetArrayOfValue(string number)
        {
            bool isNegative;
            if (number[0] != '-')
            {
                isNegative = false;
            }
            else
            {
                isNegative = true;
            }
            int[] value;
            if (number.Length > 3)
            {
                value = new int[0];
                string strNumberOneCell = "";
                int end = 0;
                if (isNegative)
                {
                    end = 1;
                }
                for (int i = number.Length - 1; i >= end; i--)
                {
                    strNumberOneCell += number[i];
                    if (strNumberOneCell.Length == 3 || i == end)
                    {
                        value = GetUpdateBigNumber(value, strNumberOneCell);
                        strNumberOneCell = "";
                    }
                }
            }
            else
            {
                string str = "";
                if (isNegative)
                {                    
                    for (int i = 1; i < number.Length; i++)
                    {
                        str += number[i];
                    }
                }
                else
                {
                    str= number;
                }
                value = new int[]
                {
                    Convert.ToInt32(str)
                };
            }
            return value;
        }

        private static string GetValueWithoutSign(int[] array)
        {
            string strNumber = array[array.Length - 1].ToString();
            for (int i = array.Length - 2; i >= 0; i--)
            {
                if (array[i] == 0)
                {
                    strNumber += "000";
                }
                if (array[i] < 10)
                {
                    strNumber += "00" + array[i].ToString();
                }
                if (array[i] > 9 && array[i] < 100)
                {
                    strNumber += "0" + array[i].ToString();
                }
                if (array[i] > 99)
                {
                    strNumber += array[i].ToString();
                }
            }
            return strNumber;
        }
        private static string GetValue(int[] array, bool isNegative)
        {
            string strNumber = "";
            if (isNegative)
            {
                strNumber += '-';
            }
            strNumber += GetValueWithoutSign(array);
            return strNumber;
        }
        public string GetValue()
        {
            return GetValue(_value, IsNegative);
        }
        public string GetValueWithoutSign()
        {
            return GetValueWithoutSign(_value);
        }
        public void SetValue(string number)
        {
            if (number[0] != '-')
            {
                IsNegative = false;
            }
            else
            {
                IsNegative = true;
            }
            _value = GetArrayOfValue(number);
        } 
        public void SetValue(byte number)
        {
            if (number < 0)
            {
                IsNegative = true;
            }
            else
            {
                IsNegative = false;
            }
            _value = new int[]
            {
                number*(-1)
            };
        }
        public void SetValue(int number)
        {
            SetValue(number.ToString());
        }
        public void SetValue(long number)
        {
            SetValue(number.ToString());
        }
    }
}
