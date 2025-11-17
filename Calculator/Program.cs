using System.Text.RegularExpressions;
using static System.Net.Mime.MediaTypeNames;

namespace Calculator
{
    internal class Program
    {
        static void Main(string[] args)
        {
            char[] signs = ['+', '-', '*', '/', '%', 'V'];
            double[] numbersDouble = new double[2];
            double answer = 0;
            Regex regex = new Regex(@"^[+\-*/%V0-9]+$");
            bool boolWhile = true;
            Console.WriteLine(Math.Sqrt(16));
            while (boolWhile)
            {
                Console.WriteLine("Выберите действие: 1 - ввод выражения, 2 - выход");
                string answerStart = Console.ReadLine();
                switch (answerStart)
                {
                    case "1":
                        Console.WriteLine("Введите математическое выражение с двумя или одним числом. Поддерживает знаки +,-,/,*,%,V (где V корень от числа):");
                        string expression = Console.ReadLine();
                        MatchCollection matches = regex.Matches(expression);
                        if (matches.Count > 0)
                        {
                            try
                            {
                                SplittingString(numbersDouble, expression);
                                for (int i = 0; i < expression.Length; i++)
                                {
                                    for (int j = 0; j < signs.Length; j++)
                                    {
                                        if (expression[i] == signs[j])
                                        {
                                            switch (signs[j])
                                            {
                                                case '+':
                                                    for (int n = 0; n < numbersDouble.Length; n++)
                                                    {
                                                        answer += numbersDouble[n];
                                                    }
                                                    Console.WriteLine("Ответ: " + answer);
                                                    break;
                                                case '-':
                                                    answer = numbersDouble[0] - numbersDouble[1];            
                                                    Console.WriteLine("Ответ: " + answer);
                                                    break;
                                                case '*':
                                                    answer = numbersDouble[0] * numbersDouble[1];
                                                    Console.WriteLine("Ответ: " + answer);
                                                    break;
                                                case '/':
                                                    answer = numbersDouble[0] / numbersDouble[1];               
                                                    Console.WriteLine("Ответ: " + answer);
                                                    break;
                                                case '%':
                                                    answer = numbersDouble[0] % numbersDouble[1];              
                                                    Console.WriteLine("Ответ: " + answer);
                                                    break;
                                                case 'V':
                                                    answer = Math.Sqrt(numbersDouble[0]);
                                                    Console.WriteLine("Ответ: " + answer);
                                                    break;

                                            }
                                        }
                                    }
                                }
                            }
                            catch (Exception ex)
                            {
                                Console.WriteLine(ex.ToString());
                            }
                        }
                        else
                        {
                            Console.WriteLine("Некоректный ввод");
                        }
                        break;
                    case "2":
                        boolWhile = false;
                        break;
                    default: Console.WriteLine("Некорректный ввод.");
                        break;
                }
            }  
        }

        private static void SplittingString(double[] numbersDouble, string expression)
        {
            char sqrt = 'V';
            string[] numbersString = expression.Split('+', '-', '/', '*', '%');
            for (int i = 0; i < numbersString.Length; i++)
            {

                if (expression[i] == sqrt)
                {
                    
                    numbersDouble[i] = Convert.ToDouble(numbersString[i].Trim('V'));
                    break;
                }
                else
                {
                    
                    for (int j = 0; j < numbersString.Length; j++)
                    {
                        numbersDouble[j] = Convert.ToDouble(numbersString[j]);
                        break;
                    }
                }

            }
        }
    }
}
