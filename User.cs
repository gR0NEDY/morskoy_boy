using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace morskoy_boy
{
    internal class User : Battleship
    {
        public User()
            {
                Console.WriteLine("На данный момент у нас присутствует только случайная расстоновка кораблей)");
                Console.ReadKey();
                Console.Clear();
                Number = 0;
                Four();
                while (Number < three)
                {
                    Three();
                }
                Number = 0;
                while (Number < two)
                {
                    Two();
                }
                Number = 0;
                while (Number < one)
                {
                    One();
                }
            }
        public void Strike()
        {
            if (Win())
            {
                return;
            }
            Console.SetCursorPosition(30, Indent++);
            Console.WriteLine("Выстрел №: " + ++Step);
            Boolean letter = true;
            while (letter)
            {
                Console.SetCursorPosition(30, Indent++);
                Console.Write("Ваш выстрел: ");
                switch (Console.Read())
                {
                    case 'а':
                        Letter[Step] = 0;
                        letter = false;
                        break;
                    case 'б':
                        Letter[Step] = 1;
                        letter = false;
                        break;
                    case 'в':
                        Letter[Step] = 2;
                        letter = false;
                        break;
                    case 'г':
                        Letter[Step] = 3;
                        letter = false;
                        break;
                    case 'д':
                        Letter[Step] = 4;
                        letter = false;
                        break;
                    case 'е':
                        Letter[Step] = 5;
                        letter = false;
                        break;
                    case 'ж':
                        Letter[Step] = 6;
                        letter = false;
                        break;
                    case 'з':
                        Letter[Step] = 7;
                        letter = false;
                        break;
                    case 'и':
                        Letter[Step] = 8;
                        letter = false;
                        break;
                    case 'к':
                        Letter[Step] = 9;
                        letter = false;
                        break;
                    default:
                        Console.SetCursorPosition(30, Indent++);
                        Console.WriteLine("Почитайте правила перед тем, как играть");
                        Strike();
                        break;
                }
            }
            Index[Step] = TryInt() - 1;
            Boolean index = true;
            while (index) 
            {
                if (Index[Step] > 9 || Index[Step] < 0)
                {
                    Console.SetCursorPosition(30, Indent++);
                    Console.WriteLine("Вы выбрали не правильную клетку.");
                    Strike();
                    
                }
                else
                {
                    index = false;
                }
            }

            if (Hit(Index[Step], Letter[Step]))
            {
                Points++;
                Strike();
            }
        }

        public bool Hit(int i, int j)
        {
            if (BotField[i, j] == 0)
            {
                BotField[i, j] = 3;
                Field1[i, j] = 3;
                Output(Field1);
                Cursor();
                Console.Write("Не попали, грусть(((");
                return false;
            }
            if (BotField[i, j] == 1)
            {
                BotField[i, j] = 2;
                Field1[i, j] = 2;
                Stroke(BotField, i, j);
                Output(Field1);
                Cursor();
                Console.Write("Да ты снайпер!");
                return true;
            }
            Cursor();
            Console.Write("Данный выстрел не возможен!");
            Console.SetCursorPosition(30, 4);
            Console.WriteLine();
            Step--;
            return true;
        }

        public bool Win()
        {
            if (Points == 20)
            {
                Console.SetCursorPosition(10, 0);
                Console.Write("Победа!");
                return true;
            }
            return false;
        }

        private void Four()
        {
            var random = new Random();
            int x = random.Next(10);
            int y = random.Next(10);
            if (x > 5)
            {
                y = random.Next(5);
                for (int i = y; i < y + 4; i++)
                {
                    UserField[i, x] = 1;
                }
                return;
            }
            if (y > 5)
            {
                x = random.Next(5);
                for (int j = x; j < x + 4; j++)
                {
                    UserField[y, j] = 1;
                }
                return;
            }
            int k = random.Next(1);
            if (k == 0)
            {
                for (int i = y; i < y + 4; i++)
                {
                    UserField[i, x] = 1;
                }
            }
            else
            {
                for (int j = x; j < x + 4; j++)
                {
                    UserField[y, j] = 1;
                }
            }
        }
        private void Three()
        {
            var random = new Random();
            var x = random.Next(10);
            var y = random.Next(10);
            if (y > 6)
            {
                x = random.Next(7);
                for (int i = y - 1; i < y + 2; i++)
                {
                    if (i < 0)
                    {
                        i++;
                    }
                    if (i > 9)
                    {
                        break;
                    }
                    for (int j = x - 1; j < x + 4; j++)
                    {
                        if (j < 0)
                        {
                            j++;
                        }
                        if (j > 9)
                        {
                            break;
                        }
                        if (UserField[i, j] != 0)
                        {
                            return;
                        }
                    }
                }
                for (int j = x; j < x + 3; j++)
                {
                    UserField[y, j] = 1;
                }
                Number++;
                return;
            }
            if (x > 6)
            {
                y = random.Next(7);
                for (int i = y - 1; i < y + 4; i++)
                {
                    if (i < 0)
                    {
                        i++;
                    }
                    if (i > 9)
                    {
                        break;
                    }
                    for (int j = x - 1; j < x + 2; j++)
                    {
                        if (j < 0)
                        {
                            j++;
                        }
                        if (j > 9)
                        {
                            break;
                        }
                        {
                            if (UserField[i, j] != 0)
                            {
                                return;
                            }
                        }
                    }
                }
                for (int i = y; i < y + 3; i++)
                {
                    UserField[i, x] = 1;
                }
                Number++;
                return;
            }
            int k = random.Next(1);
            if (k == 0)
            {
                for (int i = y - 1; i < y + 4; i++)
                {
                    if (i < 0)
                    {
                        i++;
                    }
                    if (i > 9)
                    {
                        break;
                    }
                    for (int j = x - 1; j < x + 2; j++)
                    {
                        if (j < 0)
                        {
                            j++;
                        }
                        if (j > 9)
                        {
                            break;
                        }
                        if (UserField[i, j] != 0)
                        {
                            return;
                        }
                    }
                }
                for (int i = y; i < y + 3; i++)
                {
                    UserField[i, x] = 1;
                }
                Number++;
            }
            else
            {
                for (int i = y - 1; i < y + 2; i++)
                {
                    if (i < 0)
                    {
                        i++;
                    }
                    if (i > 9)
                    {
                        break;
                    }
                    for (int j = x - 1; j < x + 4; j++)
                    {
                        if (j < 0)
                        {
                            j = 0;
                        }
                        if (j > 9)
                        {
                            break;
                        }
                        if (UserField[i, j] != 0)
                        {
                            return;
                        }
                    }
                }
                for (int j = x; j < x + 3; j++)
                {
                    UserField[y, j] = 1;
                }
                Number++;
            }
        }
        private void Two()
        {
            var random = new Random();
            var x = random.Next(10);
            var y = random.Next(10);
            if (y > 7)
            {
                x = random.Next(8);
                for (int i = y - 1; i < y + 2; i++)
                {
                    if (i < 0)
                    {
                        i++;
                    }
                    if (i > 9)
                    {
                        break;
                    }
                    for (int j = x - 1; j < x + 3; j++)
                    {
                        if (j < 0)
                        {
                            j++;
                        }
                        if (j > 9)
                        {
                            break;
                        }
                        if (UserField[i, j] != 0)
                        {
                            return;
                        }
                    }
                }
                for (int j = x; j < x + 2; j++)
                {
                    UserField[y, j] = 1;
                }
                Number++;
                return;
            }
            if (x > 7)
            {
                y = random.Next(8);
                for (int i = y - 1; i < y + 3; i++)
                {
                    if (i < 0)
                    {
                        i++;
                    }
                    if (i > 9)
                    {
                        break;
                    }
                    for (int j = x - 1; j < x + 2; j++)
                    {
                        if (j < 0)
                        {
                            j++;
                        }
                        if (j > 9)
                        {
                            break;
                        }
                        if (UserField[i, j] != 0)
                        {
                            return;
                        }
                    }
                }
                for (int i = y; i < y + 2; i++)
                {
                    UserField[i, x] = 1;
                }
                Number++;
                return;
            }
            int k = random.Next(1);
            if (k == 0)
            {
                for (int i = y - 1; i < y + 3; i++)
                {
                    if (i < 0)
                    {
                        i++;
                    }
                    if (i > 9)
                    {
                        break;
                    }
                    for (int j = x - 1; j < x + 2; j++)
                    {
                        if (j < 0)
                        {
                            j++;
                        }
                        if (j > 9)
                        {
                            break;
                        }
                        if (UserField[i, j] != 0)
                        {
                            return;
                        }
                    }
                }
                for (int i = y; i < y + 2; i++)
                {
                    UserField[i, x] = 1;
                }
                Number++;
            }
            else
            {
                for (int i = y - 1; i < y + 2; i++)
                {
                    if (i < 0)
                    {
                        i++;
                    }
                    if (i > 9)
                    {
                        break;
                    }
                    for (int j = x - 1; j < x + 3; j++)
                    {
                        if (j < 0)
                        {
                            j++;
                        }
                        if (j > 9)
                        {
                            break;
                        }
                        if (UserField[i, j] != 0)
                        {
                            return;
                        }
                    }
                }
                for (int j = x; j < x + 2; j++)
                {
                    UserField[y, j] = 1;
                }
                Number++;
            }
        }
        private void One()
        {
            var random = new Random();
            var x = random.Next(10);
            var y = random.Next(10);
            for (int i = y - 1; i < y + 2; i++)
            {
                if (i < 0)
                {
                    i++;
                }
                if (i > 9)
                {
                    break;
                }
                for (int j = x - 1; j < x + 2; j++)
                {
                    if (j < 0)
                    {
                        j++;
                    }
                    if (j > 9)
                    {
                        break;
                    }
                    if (UserField[i, j] != 0)
                    {
                        return;
                    }
                }
            }
            UserField[y, x] = 1;
            Number++;
        }

        public int TryInt()
        {
            int a;
            try
            {
                Console.SetCursorPosition(30, Indent++);
                a = Convert.ToInt32(Console.ReadLine());
                return a;
            }
            catch
            {
                Console.SetCursorPosition(30, Indent++);
                Console.WriteLine("Вы выбрали не тот формат строки. Ничего страншного, просто не ошибайтесь больше)");
                a = TryInt();
                return a;
            }
           
        }

        public void Cursor()
        {
            Console.SetCursorPosition(30, 0);
        }
    }
}
