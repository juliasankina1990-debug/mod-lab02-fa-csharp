using System;
using System.Collections.Generic;

namespace fans
{
    // Вспомогательный класс состояния (общий для всех автоматов)
    public class State
    {
        public string Name;
        public Dictionary<char, State> Transitions;
        public bool IsAcceptState;
    }

    // FA1: ровно один '0' и хотя бы одна '1'
    public class FA1
    {
        private State A, B, C, D, E;
        private State InitialState;

        public FA1()
        {
            // Создаём состояния
            A = new State { Name = "A", IsAcceptState = false, Transitions = new Dictionary<char, State>() };
            B = new State { Name = "B", IsAcceptState = false, Transitions = new Dictionary<char, State>() };
            C = new State { Name = "C", IsAcceptState = false, Transitions = new Dictionary<char, State>() };
            D = new State { Name = "D", IsAcceptState = true,  Transitions = new Dictionary<char, State>() };
            E = new State { Name = "E", IsAcceptState = false, Transitions = new Dictionary<char, State>() };

            // Определяем переходы
            A.Transitions['0'] = C;
            A.Transitions['1'] = B;

            B.Transitions['0'] = D;
            B.Transitions['1'] = B;

            C.Transitions['0'] = E;
            C.Transitions['1'] = D;

            D.Transitions['0'] = E;
            D.Transitions['1'] = D;

            E.Transitions['0'] = E;
            E.Transitions['1'] = E;

            InitialState = A;
        }

        public bool? Run(IEnumerable<char> s)
        {
            State current = InitialState;
            foreach (char c in s)
            {
                if (!current.Transitions.ContainsKey(c))
                    return null;
                current = current.Transitions[c];
            }
            return current.IsAcceptState;
        }
    }

    // FA2: нечётное количество '0' и нечётное количество '1'
    public class FA2
    {
        private State[,] states; // [чётность0, чётность1]
        private State InitialState;

        public FA2()
        {
            states = new State[2, 2];
            for (int i = 0; i < 2; i++)
                for (int j = 0; j < 2; j++)
                {
                    states[i, j] = new State
                    {
                        Name = $"({i},{j})",
                        IsAcceptState = (i == 1 && j == 1),
                        Transitions = new Dictionary<char, State>()
                    };
                }

            // Переходы: по '0' меняем чётность0, по '1' меняем чётность1
            for (int i = 0; i < 2; i++)
                for (int j = 0; j < 2; j++)
                {
                    states[i, j].Transitions['0'] = states[1 - i, j];
                    states[i, j].Transitions['1'] = states[i, 1 - j];
                }

            InitialState = states[0, 0];
        }

        public bool? Run(IEnumerable<char> s)
        {
            State current = InitialState;
            foreach (char c in s)
            {
                if (!current.Transitions.ContainsKey(c))
                    return null;
                current = current.Transitions[c];
            }
            return current.IsAcceptState;
        }
    }

    // FA3: содержит подстроку "11"
    public class FA3
    {
        private State S0, S1, S2;
        private State InitialState;

        public FA3()
        {
            S0 = new State { Name = "S0", IsAcceptState = false, Transitions = new Dictionary<char, State>() };
            S1 = new State { Name = "S1", IsAcceptState = false, Transitions = new Dictionary<char, State>() };
            S2 = new State { Name = "S2", IsAcceptState = true,  Transitions = new Dictionary<char, State>() };

            S0.Transitions['0'] = S0;
            S0.Transitions['1'] = S1;

            S1.Transitions['0'] = S0;
            S1.Transitions['1'] = S2;

            S2.Transitions['0'] = S2;
            S2.Transitions['1'] = S2;

            InitialState = S0;
        }

        public bool? Run(IEnumerable<char> s)
        {
            State current = InitialState;
            foreach (char c in s)
            {
                if (!current.Transitions.ContainsKey(c))
                    return null;
                current = current.Transitions[c];
            }
            return current.IsAcceptState;
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            string s = "01111";
            FA1 fa1 = new FA1();
            bool? result1 = fa1.Run(s);
            Console.WriteLine($"FA1(\"{s}\") = {result1}");

            FA2 fa2 = new FA2();
            bool? result2 = fa2.Run(s);
            Console.WriteLine($"FA2(\"{s}\") = {result2}");

            FA3 fa3 = new FA3();
            bool? result3 = fa3.Run(s);
            Console.WriteLine($"FA3(\"{s}\") = {result3}");
        }
    }
}
