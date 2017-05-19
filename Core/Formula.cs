﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core
{
    // Абстрактный класс формулы
    public abstract class Formula
    {
        /// <summary>
        /// Вычислить значение формулы
        /// </summary>
        /// <param name="variables">Словарь со значениями переменных</param>
        public abstract string Calculate(Dictionary<string, string> variables = null);

        public abstract void Accept(FormulaVisitor v);
    }

    // Константа
    public class Const : Formula
    {
        public string Value { get; set; }

        public Const(string c)
        {
            if (c == null)
                throw new ArgumentNullException();
            Value = c;
        }

        public override void Accept(FormulaVisitor v)
        { }

        public override string Calculate(Dictionary<string, string> variables = null)
        {
            return Value;
        }
    }

    // Переменная
    public class Var : Formula
    {
        public string Value { get; set; }

        public Var(string v)
        {
            Value = v;
        }

        public override void Accept(FormulaVisitor v)
        { }

        public override string Calculate(Dictionary<string, string> variables = null)
        {
            if (variables.ContainsKey(Value))
                return variables[Value];
            else
                throw new ApplicationException("Uninitialized variable");
        }
    }
}
