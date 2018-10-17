using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task8
{
    class TextSeparation
    {
        private readonly string _text;
        private readonly string[] _words;
        private string[] _splitWords;

        private static readonly char[] _vomels = { 'а', 'А', 'у', 'У', 'о', 'О', 'ы', 'ы', 'и', 'И', 'э', 'Э', 'я', 'Я', 'ю', 'Ю', 'ё', 'Ё', 'е', 'Е' };

        public TextSeparation(string text)
        {
            _text = text;
            _words = _text.Split(' ');
        }
        public void SplitWords()
        {
            _splitWords = new string[_words.Length];
            for(int i=0; i<_words.Length; i++)
            {
                Console.WriteLine(_words[i]);
                int numberOfSyllables = 0;
                foreach(char letter in _words[i])
                {
                    if (_vomels.Contains(letter))
                    {
                        numberOfSyllables++;
                    }
                }
                Console.WriteLine("numberOfSyllables: "+numberOfSyllables);
                Console.ReadKey();
                if (numberOfSyllables != 1)
                {
                    int startIndex = 0;
                    for(int j=0; j<numberOfSyllables; j++)
                    {                        
                        string splitWord = _words[i][startIndex].ToString();
                        if (_vomels.Contains(_words[i][startIndex]))
                        {
                            if (j != numberOfSyllables - 1)
                            {
                                if (!_vomels.Contains(_words[i][startIndex + 2]))
                                {
                                    splitWord += _words[i][startIndex+1].ToString();
                                    startIndex = startIndex + 2;
                                }
                                else
                                {
                                    startIndex++;
                                }
                                
                            }
                            else
                            {
                                int k = startIndex+1;
                                while (k < _words[i].Length)
                                {
                                    splitWord += _words[i][k];
                                    k++;
                                }
                                startIndex = k;
                            }
                        }
                        else
                        {
                            int k = startIndex+1;
                            while (k < _words[i].Length)
                            {
                                splitWord += _words[i][k];
                                k++;
                                if (j != numberOfSyllables - 1)
                                {
                                    if (k + 1 < _words[i].Length)
                                    {
                                        if (_words[i][k + 1] == 'ь')
                                        {
                                            splitWord += _words[i][k];
                                            splitWord += _words[i][k + 1];
                                            startIndex = k + 2;
                                            break;
                                        }
                                    }                                    
                                    if (_vomels.Contains(_words[i][k - 1]))
                                    {
                                        startIndex = k;
                                        break;
                                    }
                                }
                                
                            }
                        }
                        
                        if (j != numberOfSyllables - 1)
                        {
                            splitWord += '-';
                        }
                        _splitWords[i] += splitWord;
                    }                    
                }
                else
                {
                    _splitWords[i] = _words[i];
                }
                Console.WriteLine(_splitWords[i]);
            }
        }
        public string[] GetSplitWords()
        {
            return _splitWords;
        }
    }
}
