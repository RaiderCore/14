using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows;
using System.Windows.Controls;

namespace WpfApp14
{
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }


        private void Task1Button_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                string binary = task1Input.Text.Trim();
                if (!IsBinary(binary))
                {
                    task1Result.Text = "Ошибка: введите двоичное число (только 0 и 1)";
                    return;
                }

                int decimalNumber = Convert.ToInt32(binary, 2);
                task1Result.Text = $"Десятичное число: {decimalNumber}";
            }
            catch (Exception ex)
            {
                task1Result.Text = $"Ошибка: {ex.Message}";
            }
        }


        private void Task2Button_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                string binary = task2Input.Text.Trim();
                if (!IsBinary(binary))
                {
                    task2Result.Text = "Ошибка: введите двоичное число (только 0 и 1)";
                    return;
                }

                int decimalNumber = Convert.ToInt32(binary, 2);
                string octal = Convert.ToString(decimalNumber, 8);
                task2Result.Text = $"Восьмеричное число: {octal}";
            }
            catch (Exception ex)
            {
                task2Result.Text = $"Ошибка: {ex.Message}";
            }
        }


        private void Task3Button_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                string binary = task3Input.Text.Trim();
                if (!IsBinary(binary))
                {
                    task3Result.Text = "Ошибка: введите двоичное число (только 0 и 1)";
                    return;
                }

                int decimalNumber = Convert.ToInt32(binary, 2);
                string hex = Convert.ToString(decimalNumber, 16).ToUpper();
                task3Result.Text = $"Шестнадцатеричное число: {hex}";
            }
            catch (Exception ex)
            {
                task3Result.Text = $"Ошибка: {ex.Message}";
            }
        }


        private void Task4Button_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                string binary = task4Input.Text.Trim();
                if (!IsBinaryFraction(binary))
                {
                    task4Result.Text = "Ошибка: введите дробное двоичное число (например, 101.101)";
                    return;
                }

                string[] parts = binary.Split('.');
                int integerPart = Convert.ToInt32(parts[0], 2);

                double fractionalPart = 0;
                for (int i = 0; i < parts[1].Length; i++)
                {
                    if (parts[1][i] == '1')
                    {
                        fractionalPart += Math.Pow(2, -(i + 1));
                    }
                }

                double result = integerPart + fractionalPart;
                task4Result.Text = $"Десятичное число: {result}";
            }
            catch (Exception ex)
            {
                task4Result.Text = $"Ошибка: {ex.Message}";
            }
        }


        private void Task5Button_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                string binary = task5Input.Text.Trim();
                if (!IsBinaryFraction(binary))
                {
                    task5Result.Text = "Ошибка: введите дробное двоичное число (например, 101.101)";
                    return;
                }


                string[] parts = binary.Split('.');
                int integerPart = Convert.ToInt32(parts[0], 2);

                double fractionalPart = 0;
                for (int i = 0; i < parts[1].Length; i++)
                {
                    if (parts[1][i] == '1')
                    {
                        fractionalPart += Math.Pow(2, -(i + 1));
                    }
                }

                double decimalNumber = integerPart + fractionalPart;


                string octalInteger = Convert.ToString(integerPart, 8);


                double tempFraction = fractionalPart;
                string octalFraction = "";
                for (int i = 0; i < 5; i++)
                {
                    tempFraction *= 8;
                    int digit = (int)tempFraction;
                    octalFraction += digit;
                    tempFraction -= digit;
                    if (tempFraction == 0) break;
                }

                string result = octalInteger;
                if (octalFraction.Length > 0)
                {
                    result += "." + octalFraction;
                }

                task5Result.Text = $"Восьмеричное число: {result}";
            }
            catch (Exception ex)
            {
                task5Result.Text = $"Ошибка: {ex.Message}";
            }
        }


        private void Task6Button_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                string binary = task6Input.Text.Trim();
                if (!IsBinaryFraction(binary))
                {
                    task6Result.Text = "Ошибка: введите дробное двоичное число (например, 101.101)";
                    return;
                }


                string[] parts = binary.Split('.');
                int integerPart = Convert.ToInt32(parts[0], 2);

                double fractionalPart = 0;
                for (int i = 0; i < parts[1].Length; i++)
                {
                    if (parts[1][i] == '1')
                    {
                        fractionalPart += Math.Pow(2, -(i + 1));
                    }
                }

                double decimalNumber = integerPart + fractionalPart;


                string hexInteger = Convert.ToString(integerPart, 16).ToUpper();


                double tempFraction = fractionalPart;
                string hexFraction = "";
                for (int i = 0; i < 5; i++)
                {
                    tempFraction *= 16;
                    int digit = (int)tempFraction;
                    hexFraction += digit.ToString("X");
                    tempFraction -= digit;
                    if (tempFraction == 0) break;
                }

                string result = hexInteger;
                if (hexFraction.Length > 0)
                {
                    result += "." + hexFraction;
                }

                task6Result.Text = $"Шестнадцатеричное число: {result}";
            }
            catch (Exception ex)
            {
                task6Result.Text = $"Ошибка: {ex.Message}";
            }
        }


        private void Task7Button_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                string input = task7Input.Text.Trim();
                string[] numbers = input.Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);

                if (numbers.Length != 15)
                {
                    task7Result.Text = "Ошибка: нужно ввести ровно 15 двузначных чисел";
                    return;
                }

                List<int> result = new List<int>();
                foreach (string num in numbers)
                {
                    if (num.Length != 2 || !int.TryParse(num, out int n))
                    {
                        task7Result.Text = "Ошибка: все числа должны быть двузначными";
                        return;
                    }

                    char[] digits = num.ToCharArray();
                    Array.Reverse(digits);
                    string reversed = new string(digits);
                    result.Add(int.Parse(reversed));
                }

                task7Result.Text = "Результат: " + string.Join(" ", result);
            }
            catch (Exception ex)
            {
                task7Result.Text = $"Ошибка: {ex.Message}";
            }
        }


        private void Task8Button_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                string input = task8Input.Text.Trim();
                string[] numbers = input.Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);

                if (numbers.Length != 9)
                {
                    task8Result.Text = "Ошибка: нужно ввести ровно 9 восьмеричных чисел";
                    return;
                }

                List<int> result = new List<int>();
                foreach (string num in numbers)
                {
                    if (!IsOctal(num))
                    {
                        task8Result.Text = "Ошибка: все числа должны быть двузначными восьмеричными";
                        return;
                    }

                    int decimalNumber = Convert.ToInt32(num, 8);
                    result.Add(decimalNumber);
                }

                task8Result.Text = "Десятичные числа: " + string.Join(" ", result);
            }
            catch (Exception ex)
            {
                task8Result.Text = $"Ошибка: {ex.Message}";
            }
        }


        private void Task9Button_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                string input = task9Input.Text.Trim();
                string[] numbers = input.Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);

                if (numbers.Length != 7)
                {
                    task9Result.Text = "Ошибка: нужно ввести ровно 7 двузначных чисел";
                    return;
                }

                List<int> result = new List<int>();
                foreach (string num in numbers)
                {
                    if (num.Length != 2 || !int.TryParse(num, out int n))
                    {
                        task9Result.Text = "Ошибка: все числа должны быть двузначными";
                        return;
                    }

                    int firstDigit = int.Parse(num[0].ToString());
                    result.Add(firstDigit);
                }

                task9Result.Text = "Старшие разряды: " + string.Join(" ", result);
            }
            catch (Exception ex)
            {
                task9Result.Text = $"Ошибка: {ex.Message}";
            }
        }


        private void Task10Button_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                string input1 = task10Input1.Text.Trim();
                string input2 = task10Input2.Text.Trim();

                string[] numbers1 = input1.Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
                string[] numbers2 = input2.Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);

                if (numbers1.Length != 7 || numbers2.Length != 9)
                {
                    task10Result.Text = "Ошибка: первый массив должен содержать 7 чисел, второй - 9";
                    return;
                }

                List<double> list1 = numbers1.Select(s => double.Parse(s)).ToList();
                List<double> list2 = numbers2.Select(s => double.Parse(s)).ToList();

                List<double> combined = new List<double>();
                combined.AddRange(list1);
                combined.AddRange(list2);

                combined.Sort((a, b) => b.CompareTo(a)); // Сортировка по убыванию

                task10Result.Text = "Объединенный и отсортированный массив: " + string.Join(" ", combined);
            }
            catch (Exception ex)
            {
                task10Result.Text = $"Ошибка: {ex.Message}";
            }
        }


        private void Task11Button_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                string input = task11Input.Text.Trim();
                string[] numbers = input.Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);

                if (numbers.Length != 12)
                {
                    task11Result.Text = "Ошибка: нужно ввести ровно 12 двоичных чисел";
                    return;
                }


                var filtered = numbers
                    .GroupBy(n => n)
                    .SelectMany(g => g.Take(2))
                    .ToList();

                task11Result.Text = "Результат после удаления дубликатов: " + string.Join(" ", filtered);
            }
            catch (Exception ex)
            {
                task11Result.Text = $"Ошибка: {ex.Message}";
            }
        }


        private void Task12Button_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                string input = task12Input.Text.Trim();
                string[] numbers = input.Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);

                if (numbers.Length < 2)
                {
                    task12Result.Text = "Ошибка: массив должен содержать хотя бы 2 элемента";
                    return;
                }


                var duplicates = numbers
                    .GroupBy(n => n)
                    .Where(g => g.Count() > 1)
                    .Select(g => g.Key)
                    .ToList();

                if (duplicates.Count == 0)
                {
                    task12Result.Text = "Одинаковых элементов не найдено";
                    return;
                }

                if (duplicates.Count > 1)
                {
                    task12Result.Text = "Ошибка: в массиве более одной пары одинаковых элементов";
                    return;
                }

                string duplicateValue = duplicates[0];
                List<int> indices = new List<int>();

                for (int i = 0; i < numbers.Length; i++)
                {
                    if (numbers[i] == duplicateValue)
                    {
                        indices.Add(i);
                    }
                }

                task12Result.Text = $"Одинаковые элементы '{duplicateValue}' находятся на позициях: {string.Join(", ", indices)}";
            }
            catch (Exception ex)
            {
                task12Result.Text = $"Ошибка: {ex.Message}";
            }
        }


        private void Task13Button_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                string binary = task13Input.Text.Trim();
                if (!IsBinary(binary))
                {
                    task13Result.Text = "Ошибка: введите двоичное число (только 0 и 1)";
                    return;
                }

                if (binary.Length < 2)
                {
                    task13Result.Text = "Ошибка: число должно содержать хотя бы 2 цифры";
                    return;
                }


                string shifted = binary.Substring(2) + binary.Substring(0, 2);


                int original = Convert.ToInt32(binary, 2);
                int shiftedNum = Convert.ToInt32(shifted, 2);
                int difference = original - shiftedNum;

                task13Result.Text = $"После сдвига: {shifted}\nРазность: {difference} (десятичное)";
            }
            catch (Exception ex)
            {
                task13Result.Text = $"Ошибка: {ex.Message}";
            }
        }


        private void Task14Button_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                string input = task14Input.Text.Trim();
                string[] numbers = input.Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);

                if (numbers.Length == 0)
                {
                    task14Result.Text = "Ошибка: введите хотя бы одно двоичное число";
                    return;
                }

                foreach (string num in numbers)
                {
                    if (!IsBinary(num))
                    {
                        task14Result.Text = "Ошибка: все числа должны быть двоичными";
                        return;
                    }
                }


                var sorted = numbers.OrderByDescending(n => n).ToList();


                int sum = 0;
                foreach (string num in numbers)
                {
                    sum += Convert.ToInt32(num, 2);
                }

                task14Result.Text = $"Отсортированный массив: {string.Join(" ", sorted)}\nСумма: {sum} (десятичное)";
            }
            catch (Exception ex)
            {
                task14Result.Text = $"Ошибка: {ex.Message}";
            }
        }


        private void Task15Button_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                string input = task15Input.Text.Trim();
                string[] numbers = input.Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);

                if (numbers.Length == 0)
                {
                    task15Result.Text = "Ошибка: введите хотя бы одно двоичное число";
                    return;
                }

                foreach (string num in numbers)
                {
                    if (!IsBinary(num))
                    {
                        task15Result.Text = "Ошибка: все числа должны быть двоичными";
                        return;
                    }
                }


                var sorted = numbers.OrderBy(n => n).ToList();


                double sum = 0;
                foreach (string num in numbers)
                {
                    sum += Convert.ToInt32(num, 2);
                }
                double average = sum / numbers.Length;

                task15Result.Text = $"Отсортированный массив: {string.Join(" ", sorted)}\nСреднее значение: {average:F2} (десятичное)";
            }
            catch (Exception ex)
            {
                task15Result.Text = $"Ошибка: {ex.Message}";
            }
        }


        private void Task16Button_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                string input = task16Input.Text.Trim();
                string[] numbers = input.Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);

                if (numbers.Length == 0)
                {
                    task16Result.Text = "Ошибка: введите хотя бы одно двоичное число";
                    return;
                }

                foreach (string num in numbers)
                {
                    if (!IsBinary(num))
                    {
                        task16Result.Text = "Ошибка: все числа должны быть двоичными";
                        return;
                    }
                }

                if (numbers.Length < 2)
                {
                    task16Result.Text = "Ошибка: для обмена нужно хотя бы 2 числа";
                    return;
                }


                int minIndex = 0, maxIndex = 0;
                int minValue = Convert.ToInt32(numbers[0], 2);
                int maxValue = minValue;

                for (int i = 1; i < numbers.Length; i++)
                {
                    int current = Convert.ToInt32(numbers[i], 2);
                    if (current < minValue)
                    {
                        minValue = current;
                        minIndex = i;
                    }
                    if (current > maxValue)
                    {
                        maxValue = current;
                        maxIndex = i;
                    }
                }


                string temp = numbers[minIndex];
                numbers[minIndex] = numbers[maxIndex];
                numbers[maxIndex] = temp;

                task16Result.Text = $"Результат после обмена: {string.Join(" ", numbers)}";
            }
            catch (Exception ex)
            {
                task16Result.Text = $"Ошибка: {ex.Message}";
            }
        }


        private void Task17Button_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                string binary = task17Input.Text.Trim();
                if (!IsBinary(binary))
                {
                    task17Result.Text = "Ошибка: введите двоичное число (только 0 и 1)";
                    return;
                }

                if (binary.Length < 1)
                {
                    task17Result.Text = "Ошибка: число должно содержать хотя бы 1 цифру";
                    return;
                }


                string shifted = binary[binary.Length - 1] + binary.Substring(0, binary.Length - 1);


                int original = Convert.ToInt32(binary, 2);
                int shiftedNum = Convert.ToInt32(shifted, 2);
                int sum = original + shiftedNum;

                task17Result.Text = $"После сдвига: {shifted}\nСумма: {sum} (десятичное)";
            }
            catch (Exception ex)
            {
                task17Result.Text = $"Ошибка: {ex.Message}";
            }
        }


        private void Task18Button_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                string input = task18Input.Text.Trim();
                string[] numbersStr = input.Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);

                if (numbersStr.Length == 0)
                {
                    task18Result.Text = "Ошибка: введите хотя бы одно число";
                    return;
                }

                int[] numbers = numbersStr.Select(int.Parse).ToArray();

                if (numbers.Length < 2)
                {
                    task18Result.Text = "Ошибка: для анализа нужно хотя бы 2 числа";
                    return;
                }

                int increasingSum = 0;
                int decreasingSum = 0;
                List<int> currentSequence = new List<int> { numbers[0] };
                bool? isIncreasing = null;

                for (int i = 1; i < numbers.Length; i++)
                {
                    if (numbers[i] > numbers[i - 1])
                    {

                        if (isIncreasing == false)
                        {

                            decreasingSum += currentSequence.Sum();
                            currentSequence = new List<int> { numbers[i - 1], numbers[i] };
                        }
                        else
                        {
                            currentSequence.Add(numbers[i]);
                        }
                        isIncreasing = true;
                    }
                    else if (numbers[i] < numbers[i - 1])
                    {

                        if (isIncreasing == true)
                        {

                            increasingSum += currentSequence.Sum();
                            currentSequence = new List<int> { numbers[i - 1], numbers[i] };
                        }
                        else
                        {
                            currentSequence.Add(numbers[i]);
                        }
                        isIncreasing = false;
                    }
                    else
                    {

                        if (isIncreasing == true)
                        {
                            increasingSum += currentSequence.Sum();
                        }
                        else if (isIncreasing == false)
                        {
                            decreasingSum += currentSequence.Sum();
                        }
                        currentSequence = new List<int> { numbers[i] };
                        isIncreasing = null;
                    }
                }


                if (isIncreasing == true)
                {
                    increasingSum += currentSequence.Sum();
                }
                else if (isIncreasing == false)
                {
                    decreasingSum += currentSequence.Sum();
                }

                int difference = increasingSum - decreasingSum;
                task18Result.Text = $"Сумма возрастающих участков: {increasingSum}\nСумма убывающих участков: {decreasingSum}\nРазность: {difference}";
            }
            catch (Exception ex)
            {
                task18Result.Text = $"Ошибка: {ex.Message}";
            }
        }


        private void Task19Button_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                string input = task19Input.Text.Trim();
                string[] numbersStr = input.Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);

                if (numbersStr.Length == 0)
                {
                    task19Result.Text = "Ошибка: введите хотя бы одно число";
                    return;
                }

                int[] numbers = numbersStr.Select(int.Parse).ToArray();

                if (numbers.Length < 2)
                {
                    task19Result.Text = "Массив слишком мал для определения прогрессии";
                    return;
                }

                int difference = numbers[1] - numbers[0];
                bool isArithmetic = true;

                for (int i = 2; i < numbers.Length; i++)
                {
                    if (numbers[i] - numbers[i - 1] != difference)
                    {
                        isArithmetic = false;
                        break;
                    }
                }

                if (isArithmetic)
                {
                    task19Result.Text = $"Образует арифметическую прогрессию с разностью {difference}";
                }
                else
                {
                    task19Result.Text = "Не образует арифметическую прогрессию";
                }
            }
            catch (Exception ex)
            {
                task19Result.Text = $"Ошибка: {ex.Message}";
            }
        }


        private void Task20Button_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                string input = task20Input.Text.Trim();
                string[] numbersStr = input.Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);

                if (numbersStr.Length == 0)
                {
                    task20Result.Text = "Ошибка: введите хотя бы одно число";
                    return;
                }

                int[] numbers = numbersStr.Select(int.Parse).ToArray();

                if (numbers.Length < 2)
                {
                    task20Result.Text = "Массив слишком мал для определения прогрессии";
                    return;
                }

                if (numbers[0] == 0)
                {
                    task20Result.Text = "Первый элемент не может быть нулем";
                    return;
                }

                double ratio = (double)numbers[1] / numbers[0];
                bool isGeometric = true;

                for (int i = 2; i < numbers.Length; i++)
                {
                    if (numbers[i - 1] == 0 || Math.Abs((double)numbers[i] / numbers[i - 1] - ratio) > 0.0001)
                    {
                        isGeometric = false;
                        break;
                    }
                }

                if (isGeometric)
                {
                    task20Result.Text = $"Образует геометрическую прогрессию со знаменателем {ratio}";
                }
                else
                {
                    task20Result.Text = "Не образует геометрическую прогрессию";
                }
            }
            catch (Exception ex)
            {
                task20Result.Text = $"Ошибка: {ex.Message}";
            }
        }


        private void Task21Button_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                string input = task21Input.Text.Trim();
                string[] numbersStr = input.Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);

                if (numbersStr.Length == 0)
                {
                    task21Result.Text = "Ошибка: введите хотя бы одно число";
                    return;
                }

                int[] numbers = numbersStr.Select(int.Parse).ToArray();
                List<int> indices = new List<int>();

                for (int i = 0; i < numbers.Length; i++)
                {
                    bool isGreater = true;
                    for (int j = i + 1; j < numbers.Length; j++)
                    {
                        if (numbers[i] <= numbers[j])
                        {
                            isGreater = false;
                            break;
                        }
                    }

                    if (isGreater)
                    {
                        indices.Add(i);
                    }
                }

                task21Result.Text = $"Индексы элементов: {string.Join(", ", indices)}\nКоличество: {indices.Count}";
            }
            catch (Exception ex)
            {
                task21Result.Text = $"Ошибка: {ex.Message}";
            }
        }


        private void Task22Button_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                string input = task22Input.Text.Trim();
                string[] numbersStr = input.Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);

                if (numbersStr.Length == 0)
                {
                    task22Result.Text = "Ошибка: введите хотя бы одно число";
                    return;
                }

                int[] numbers = numbersStr.Select(int.Parse).ToArray();
                int lastIndex = -1;

                for (int i = 1; i < numbers.Length - 1; i++)
                {
                    if (numbers[i - 1] < numbers[i] && numbers[i] < numbers[i + 1])
                    {
                        lastIndex = i;
                    }
                }

                if (lastIndex != -1)
                {
                    task22Result.Text = $"Последний удовлетворяющий элемент на позиции {lastIndex} (значение: {numbers[lastIndex]})";
                }
                else
                {
                    task22Result.Text = "Таких элементов нет";
                }
            }
            catch (Exception ex)
            {
                task22Result.Text = $"Ошибка: {ex.Message}";
            }
        }


        private void Task23Button_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                string input = task23Input.Text.Trim();
                string[] numbers = input.Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);

                if (numbers.Length == 0)
                {
                    task23Result.Text = "Ошибка: введите хотя бы одно двоичное число";
                    return;
                }

                foreach (string num in numbers)
                {
                    if (!IsBinary(num))
                    {
                        task23Result.Text = "Ошибка: все числа должны быть двоичными";
                        return;
                    }
                }

                if (numbers.Length < 2)
                {
                    task23Result.Text = "Ошибка: для анализа нужно хотя бы 2 числа";
                    return;
                }


                int minIndex = 0, maxIndex = 0;
                int minValue = Convert.ToInt32(numbers[0], 2);
                int maxValue = minValue;

                for (int i = 1; i < numbers.Length; i++)
                {
                    int current = Convert.ToInt32(numbers[i], 2);
                    if (current < minValue)
                    {
                        minValue = current;
                        minIndex = i;
                    }
                    if (current > maxValue)
                    {
                        maxValue = current;
                        maxIndex = i;
                    }
                }


                int start = Math.Min(minIndex, maxIndex);
                int end = Math.Max(minIndex, maxIndex);
                int count = end - start - 1;

                if (count <= 0)
                {
                    task23Result.Text = "Между минимальным и максимальным элементами нет других элементов";
                }
                else
                {
                    task23Result.Text = $"Количество элементов между минимальным и максимальным: {count}";
                }
            }
            catch (Exception ex)
            {
                task23Result.Text = $"Ошибка: {ex.Message}";
            }
        }


        private void Task24Button_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                string input = task24Input.Text.Trim();
                string[] numbers = input.Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);

                if (numbers.Length == 0)
                {
                    task24Result.Text = "Ошибка: введите хотя бы одно двоичное число";
                    return;
                }

                foreach (string num in numbers)
                {
                    if (!IsBinary(num))
                    {
                        task24Result.Text = "Ошибка: все числа должны быть двоичными";
                        return;
                    }
                }

                if (numbers.Length < 1)
                {
                    task24Result.Text = "Ошибка: для сдвига нужно хотя бы 1 число";
                    return;
                }


                string[] shifted = new string[numbers.Length];
                shifted[0] = numbers[numbers.Length - 1];
                for (int i = 1; i < numbers.Length; i++)
                {
                    shifted[i] = numbers[i - 1];
                }

                task24Result.Text = $"После сдвига: {string.Join(" ", shifted)}";
            }
            catch (Exception ex)
            {
                task24Result.Text = $"Ошибка: {ex.Message}";
            }
        }


        private void Task25Button_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                string input = task25Input.Text.Trim();
                string[] numbers = input.Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);

                if (numbers.Length == 0)
                {
                    task25Result.Text = "Ошибка: введите хотя бы одно двоичное число";
                    return;
                }

                foreach (string num in numbers)
                {
                    if (!IsBinary(num))
                    {
                        task25Result.Text = "Ошибка: все числа должны быть двоичными";
                        return;
                    }
                }

                if (numbers.Length < 1)
                {
                    task25Result.Text = "Ошибка: для сдвига нужно хотя бы 1 число";
                    return;
                }


                int sumBefore = numbers.Sum(n => Convert.ToInt32(n, 2));


                string[] shifted = new string[numbers.Length];
                for (int i = 0; i < numbers.Length - 1; i++)
                {
                    shifted[i] = numbers[i + 1];
                }
                shifted[numbers.Length - 1] = numbers[0];


                int sumAfter = shifted.Sum(n => Convert.ToInt32(n, 2));

                task25Result.Text = $"После сдвига: {string.Join(" ", shifted)}\nСумма до сдвига: {sumBefore}\nСумма после сдвига: {sumAfter}";
            }
            catch (Exception ex)
            {
                task25Result.Text = $"Ошибка: {ex.Message}";
            }
        }


        private void Task26Button_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                string input = task26Input.Text.Trim();
                string[] numbers = input.Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);

                if (numbers.Length == 0)
                {
                    task26Result.Text = "Ошибка: введите хотя бы одно двоичное число";
                    return;
                }

                foreach (string num in numbers)
                {
                    if (!IsBinary(num))
                    {
                        task26Result.Text = "Ошибка: все числа должны быть двоичными";
                        return;
                    }
                }

                int addValue = Convert.ToInt32("1010", 2);
                List<string> result = new List<string>();

                foreach (string num in numbers)
                {
                    int decimalNum = Convert.ToInt32(num, 2);
                    int sum = decimalNum + addValue;
                    result.Add(Convert.ToString(sum, 2));
                }

                task26Result.Text = $"Результат: {string.Join(" ", result)}";
            }
            catch (Exception ex)
            {
                task26Result.Text = $"Ошибка: {ex.Message}";
            }
        }


        private void Task27Button_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                string input1 = task27Input1.Text.Trim();
                string input2 = task27Input2.Text.Trim();

                string[] numbersStr = input1.Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
                if (numbersStr.Length == 0)
                {
                    task27Result.Text = "Ошибка: введите хотя бы одно число";
                    return;
                }

                if (!double.TryParse(input2, out double R))
                {
                    task27Result.Text = "Ошибка: введите корректное число R";
                    return;
                }

                double[] numbers = numbersStr.Select(double.Parse).ToArray();
                double minDistance = Math.Abs(numbers[0] - R);
                int closestIndex = 0;
                double closestValue = numbers[0];

                for (int i = 1; i < numbers.Length; i++)
                {
                    double distance = Math.Abs(numbers[i] - R);
                    if (distance < minDistance)
                    {
                        minDistance = distance;
                        closestIndex = i;
                        closestValue = numbers[i];
                    }
                }

                task27Result.Text = $"Самый близкий элемент: {closestValue} (индекс {closestIndex})";
            }
            catch (Exception ex)
            {
                task27Result.Text = $"Ошибка: {ex.Message}";
            }
        }


        private void Task28Button_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                string input1 = task28Input1.Text.Trim();
                string input2 = task28Input2.Text.Trim();

                string[] numbers = input1.Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
                if (numbers.Length == 0)
                {
                    task28Result.Text = "Ошибка: введите хотя бы одно двоичное число";
                    return;
                }

                foreach (string num in numbers)
                {
                    if (!IsBinary(num))
                    {
                        task28Result.Text = "Ошибка: все числа должны быть двоичными";
                        return;
                    }
                }

                if (!IsBinary(input2))
                {
                    task28Result.Text = "Ошибка: число D должно быть двоичным";
                    return;
                }

                int D = Convert.ToInt32(input2, 2);
                int maxDistance = Math.Abs(Convert.ToInt32(numbers[0], 2) - D);
                int farthestIndex = 0;
                string farthestValue = numbers[0];

                for (int i = 1; i < numbers.Length; i++)
                {
                    int current = Convert.ToInt32(numbers[i], 2);
                    int distance = Math.Abs(current - D);
                    if (distance > maxDistance)
                    {
                        maxDistance = distance;
                        farthestIndex = i;
                        farthestValue = numbers[i];
                    }
                }

                task28Result.Text = $"Самый удаленный элемент: {farthestValue} (индекс {farthestIndex})";
            }
            catch (Exception ex)
            {
                task28Result.Text = $"Ошибка: {ex.Message}";
            }
        }


        private void Task29Button_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                string positiveBinary = task29Input1.Text.Trim();
                string negativeBinary = task29Input2.Text.Trim();

                if (!IsBinary(positiveBinary) || positiveBinary.StartsWith("-"))
                {
                    task29Result.Text = "Ошибка: первое число должно быть положительным двоичным";
                    return;
                }

                if (!negativeBinary.StartsWith("-") || !IsBinary(negativeBinary.Substring(1)))
                {
                    task29Result.Text = "Ошибка: второе число должно быть отрицательным двоичным (начинаться с минуса)";
                    return;
                }

                int positive = Convert.ToInt32(positiveBinary, 2);
                int negative = -Convert.ToInt32(negativeBinary.Substring(1), 2);

                int sum = positive + negative;

                task29Result.Text = $"Сумма: {sum} (десятичное)\nДвоичное представление суммы: {Convert.ToString(sum, 2)}";
            }
            catch (Exception ex)
            {
                task29Result.Text = $"Ошибка: {ex.Message}";
            }
        }

        private void Task30Button_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                string input = task30Input.Text.Trim();
                string[] numbersStr = input.Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);

                if (numbersStr.Length != 3)
                {
                    task30Result.Text = "Ошибка: нужно ввести ровно 3 десятичных числа";
                    return;
                }

                int[] numbers = numbersStr.Select(int.Parse).ToArray();
                string[] binaryNumbers = numbers.Select(n => Convert.ToString(n, 2)).ToArray();

                task30Result.Text = $"Двоичные представления: {string.Join(" ", binaryNumbers)}";
            }
            catch (Exception ex)
            {
                task30Result.Text = $"Ошибка: {ex.Message}";
            }
        }


        private bool IsBinary(string s)
        {
            foreach (char c in s)
            {
                if (c != '0' && c != '1')
                {
                    return false;
                }
            }
            return s.Length > 0;
        }

        private bool IsBinaryFraction(string s)
        {
            string[] parts = s.Split('.');
            if (parts.Length != 2) return false;

            return IsBinary(parts[0]) && IsBinary(parts[1]);
        }

        private bool IsOctal(string s)
        {
            if (s.Length != 2) return false;

            foreach (char c in s)
            {
                if (c < '0' || c > '7')
                {
                    return false;
                }
            }
            return true;
        }
    }
}