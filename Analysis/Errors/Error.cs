using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CTranslator.Analysis.Errors
{
    /// <summary>
    /// Базовый класс Ошибка трансляции
    /// </summary>
    public class Error : Exception
    {
        /// <summary>
        /// Текст сообщения об ошибке
        /// </summary>
        public new string Message;

        /// <summary>
        /// Лексема, в которой возникла ошибка
        /// </summary>
        public string Lexem;

        /// <summary>
        /// Позиция, в которой возникла ошибка
        /// </summary>
        public int Pos;

        public override string ToString()
        {
            return Message;
        }
    }

    /// <summary>
    /// Ошибка неизвестный символ
    /// </summary>
    public class UnknownSymbolError : Error
    {
        public UnknownSymbolError(string lexem, int pos)
        {
            Lexem = lexem;
            Pos = pos;
            Message = string.Format("Неизвестный символ '{0}'", lexem);
        }
    }

    /// <summary>
    /// Ошибка Слишком длинный идентификатор
    /// </summary>
    public class TooLongIdentifierError : Error
    {
        public TooLongIdentifierError(string lexem, int pos)
        {
            Lexem = lexem;
            Pos = pos;
            Message = string.Format("Длина идентификатора '{0}' превышает 8 символов", lexem);
        }
    }

    /// <summary>
    /// Ошибка Неверная лексема
    /// </summary>
    public class UnexpectedLexemError : Error
    {
        /// <summary>
        /// Полученная лексема
        /// </summary>
        public string InputLexem;

        public UnexpectedLexemError(string lexem, string inputLexem, int pos = 0)
        {
            Lexem = lexem;
            InputLexem = inputLexem;
            Pos = pos;
            Message = string.Format("Ожидалась лексема '{0}', но получено '{1}'", lexem, inputLexem);
        }
    }

    /// <summary>
    /// Ошибка Неверный нетерминал
    /// </summary>
    public class WrongNonTerminalError : Error
    {
        /// <summary>
        /// Полученный нетерминальный символ
        /// </summary>
        public string NonTerminal;

        public WrongNonTerminalError(string lexem, string nonTerminal, int pos = 0)
        {
            Lexem = lexem;
            NonTerminal = nonTerminal;
            Pos = pos;
            Message = string.Format("Ожидалось '{0}', но получено {1}", lexem, nonTerminal);
        }
    }

    /// <summary>
    /// Ошибка Неизвестная арифметическая операция
    /// </summary>
    public class UnknownArithmeticOperationError : Error
    {
        public UnknownArithmeticOperationError(string lexem, int pos = 0)
        {
            Lexem = lexem;
            Pos = pos;
            Message = string.Format("Неизвестная арифметическая операция '{0}'", lexem);
        }
    }

    /// <summary>
    /// Ошибка Неизвестная логическая операция
    /// </summary>
    public class UnknownLogicOperationError : Error
    {
        public UnknownLogicOperationError(string lexem, int pos = 0)
        {
            Lexem = lexem;
            Pos = pos;
            Message = string.Format("Неизвестная логическая операция '{0}'", lexem);
        }
    }
}
