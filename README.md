# МИПиС
## mod-lab02-fa-csharp


![GitHub pull requests](https://img.shields.io/github/issues-pr/UNN-IASR/mod-lab02-fa-csharp)
![GitHub closed pull requests](https://img.shields.io/github/issues-pr-closed/UNN-IASR/mod-lab02-fa-csharp)

Срок выполнения задания:

**по 05.04.2025** ![Relative date](https://img.shields.io/date/1775422800) 


## Lab 02. Разработка детерминированного конечного автомата (ДКА) на C\#

За основу берем пример реализации ДКА

```csharp
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace fans
{
  public class State
  {
    public string Name;
    public Dictionary<char, State> Transitions;
    public bool IsAcceptState;
  }
  public class FA
  {
        public static State a = new State()
        {
            Name = "a",
            IsAcceptState = false,
            Transitions = new Dictionary<char, State>()
        };
        public State b = new State()
        {
            Name = "b",
            IsAcceptState = false,
            Transitions = new Dictionary<char, State>()
        };
        public State c = new State()
        {
            Name = "c",
            IsAcceptState = true,
            Transitions = new Dictionary<char, State>()
        };

        State InitialState = a;
        
        public FA()
        {
           a.Transitions['0'] = a;
           a.Transitions['1'] = b;
           b.Transitions['0'] = c;
           b.Transitions['1'] = a;
           c.Transitions['0'] = b;
           c.Transitions['1'] = c;            
        }
        
        public bool? Run(IEnumerable<char> s)
        {
            State current = InitialState;
            foreach (var c in s) // цикл по всем символам 
            {
                current = current.Transitions[c]; // меняем состояние на то, в которое у нас переход
                if (current == null)              // если его нет, возвращаем признак ошибки
                    return null;
                // иначе переходим к следующему
            }
            return current.IsAcceptState;         // результат true если в конце финальное состояние 
        }
  }

  class Program
  {
    static void Main(string[] args)
    {
      String s = "0000010111";
      FA fa = new FA();
      bool? result = fa.Run(s);
      Console.WriteLine(result);
    }
  }
}
```

### Задача №1

> Разработать класс ДКА, который допускает бинарную строку, содержащую ровно один '0' и хотя бы одну '1'. 

Класс должен называться **FA1**

### Задача №2

> Разработать класс ДКА, который допускает бинарную строку, содержащую нечетное количество символов '0' и нечетное количество символов '1'.

Класс должен называться **FA2**

### Задача №3

> Разработать класс ДКА, который допускает бинарную строку, содержащую  '11'.

Класс должен называться **FA3**


### Задача №4

> Разработать модульные тесты в количестве, не менее 10 штук

### Структура проекта

- **fa/program.cs** - файл с реализацией классов **FA1**, **FA2**,  **FA3**
- **fa.Tests/UnitTest1.cs** - файл с модульными тестами.
