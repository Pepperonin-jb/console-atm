using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    internal class Program
    {
        static void Main(string[] args)
        {

            const int CorrectPin = 3679;       // правильный PIN
            int balance = 1000;            // начальный баланс
            int balanceChange;
            var history = new List<string>();   // история операций
            int Menu;

            Console.WriteLine("введите пин: ");
            for (int i = 0; i <= 3; i++)
            {
                if (int.Parse(Console.ReadLine()) == CorrectPin)
                {
                    break;
                }
                if (i == 2)
                {
                    Console.WriteLine("Карта заблокирована.");
                    return;
                }
                else
                {
                    Console.WriteLine($"Неверный пин. осталось попыток:{3 - i - 1} ");
                }
            }
            Console.WriteLine("Добро пожаловать!\n");
            // TODO: цикл на 3 попытки ввода PIN.
            // Если PIN верный — выйти из цикла и продолжить.
            // Если попытки закончились — вывести "Карта заблокирована" и return. --- сделано
            do
            {
                Console.WriteLine("ВЫБЕРИТЕ ПУНКТ\n1 -- Проверить баланс\n2 -- Вывод средств\n3 -- Пополнить счёт\n4 -- История операций\n0 -- Выход\n\n");
                Menu = int.Parse(Console.ReadLine());
                switch(Menu)
                {
                    case 1:
                        {
                            Console.WriteLine("Проверить баланс");
                            Console.WriteLine($"\nБаланс составлят: {balance};\n");
                            history.Add($"Проверка баланса.\n");
                        }
                        break;
                    case 2:
                        {
                            Console.WriteLine("Снять денги\n");
                            case2Label:
                            Console.WriteLine("Введите сумму, кратную 100: ");
                            balanceChange = int.Parse(Console.ReadLine());
                            if ((balanceChange % 100 == 0) && (balanceChange <= balance) && (balanceChange > 0)) 
                            {
                            balance -= balanceChange;
                                Console.WriteLine($"Успешно выведено: {balanceChange}\nБаланс: {balance}\n");
                                history.Add($"Снято {balanceChange} \nБаланс: {balance}\n");
                            }
                            else if (balanceChange == 0)
                            {
                                Console.WriteLine("Возврат в меню\n");
                                break;
                            }
                            else
                            {
                                Console.WriteLine("Некорректно введена сумма\n");
                                goto case2Label;
                            }
                        }
                        break;
                    case 3:
                        {
                            Console.WriteLine("Пополнение баланса\n");
                        case3Label:
                            Console.WriteLine("\nВнесите сумму для пополнения, кратную 100");
                            balanceChange= int.Parse(Console.ReadLine());
                            if (balanceChange > 0)
                            {
                                if (balanceChange % 100 == 0)
                                {
                                    balance += balanceChange;
                                    Console.WriteLine($"Успешно пополнено на {balanceChange}\n Баланс: {balance}\n");
                                    history.Add($"пополнение баланса на {balanceChange}\n Баланс: {balance}");
                                }
                                else
                                {
                                    balance += (balanceChange / 100) * 100;
                                    Console.WriteLine($"Успешно пополнено на {(balanceChange / 100) * 100}\n Баланс: {balance}\n Возвращено: {balanceChange % 100}\n");
                                    history.Add($"пополнение баланса на {(balanceChange / 100) * 100}\n Баланс: {balance}\n");
                                }
                            }
                            else if(balanceChange == 0)
                            {
                                Console.WriteLine("Возврат в меню\n");
                            }
                            else
                            {
                                Console.WriteLine("Некорректно введена сумма.\n");
                                goto case3Label;
                            }
                        }
                        break;
                    case 4:
                        {
                            Console.WriteLine("История операций:\n");
                            foreach( var n in history)
                            {
                                Console.WriteLine(n);
                            }

                        }
                        break;
                    default:
                        Console.WriteLine("Неверное значение\n");
                    break;
                }

            } while (Menu != 0);
            // TODO: главное меню — цикл, который повторяется,
            // пока пользователь не выберет выход (0).
            // Внутри — switch по пункту меню.
            // Для каждого пункта реализуйте отдельную логику.

            Console.WriteLine("Спасибо за использование банкомата!");
        }
    }
}
