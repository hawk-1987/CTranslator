using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CTranslator.Analysis.Errors;

namespace CTranslator.Analysis
{
    /// <summary>
    /// Синтаксический анализатор (парсер)
    /// </summary>
    public static class Parser
    {
        #region Служебные свойства и методы
        /// <summary>
        /// Индекс анализируемой лексемы
        /// </summary>
        private static int lexemIndex;

        /// <summary>
        /// Текущая анализируемая лексема
        /// </summary>
        private static Token currentLexem
        {
            get
            {
                return (lexemIndex < Scanner.Tokens.Count) ? Scanner.Tokens[lexemIndex] : new Token(TokenType.UNDEFINED, "");
            }
        }

        /// <summary>
        /// Следующая лексема входного потока
        /// </summary>
        private static Token nextLexem
        {
            get
            {
                return (lexemIndex + 1 < Scanner.Tokens.Count) ? Scanner.Tokens[lexemIndex + 1] : new Token(TokenType.UNDEFINED, "");
            }
        }

        /// <summary>
        /// Считывает следующую лексему из входного потока
        /// </summary>
        private static void Next()
        {
            lexemIndex++;
        }

        /// <summary>
        /// Проверяет является ли лексема типом
        /// </summary>
        /// <param name="Lexem">Анилизируемая лексема</param>
        /// <returns>Возвращает true если лексема является типом и false в противном случае</returns>
        private static bool IsType(Token Lexem)
        {
            return Lexem.LexemType == TokenType.INT  || 
                   Lexem.LexemType == TokenType.LONG || 
                   Lexem.LexemType == TokenType.BOOL;
        }
        #endregion

        #region Синтаксический анализ
        /// <summary>
        /// Выполняет синтаксический анализ программы на заданном языке
        /// </summary>
        public static void Analyze()
        {
            lexemIndex = 0;
            if (currentLexem.LexemType != TokenType.MAIN)
                throw new UnexpectedLexemError("main", currentLexem.Value);
            Next();
            if (currentLexem.LexemType != TokenType.LEFTBRACKET)
                throw new UnexpectedLexemError("(", currentLexem.Value);
            Next();
            if (currentLexem.LexemType != TokenType.RIGHTBRACKET)
                throw new UnexpectedLexemError (")", currentLexem.Value);
            Next();
            if (currentLexem.LexemType != TokenType.LEFTFIGURE)
                throw new UnexpectedLexemError("{", currentLexem.Value);
            Next();
            DeclarationList();
            Next();
            OperatorList();
            if (currentLexem.LexemType != TokenType.RIGHTFIGURE)
                throw new UnexpectedLexemError("}", currentLexem.Value);
        }

        /// <summary>
        /// Список описаний
        /// </summary>
        private static void DeclarationList()
        {
            Declaration();
            B();
        }

        /// <summary>
        /// Описание переменных
        /// </summary>
        private static void Declaration()
        {
            Type();
            Next();
            VariableList();
        }

        /// <summary>
        /// <спис_опис> ::=<опис><B> 
        /// </summary>
        private static void B()
        {
            if (currentLexem.LexemType != TokenType.SEMICOLON)
                throw new UnexpectedLexemError(";", currentLexem.Value);
            if (!IsType(nextLexem))
                return;
            A();
        }

        /// <summary>
        /// <B>::=<A>
        /// </summary>
        private static void A()
        {
            if (currentLexem.LexemType != TokenType.SEMICOLON)
                throw new UnexpectedLexemError(";", currentLexem.Value);
            Next();
            Declaration();
            B();
        }

        /// <summary>
        /// Тип
        /// </summary>
        private static void Type()
        {
            if (currentLexem.LexemType != TokenType.INT &&
                currentLexem.LexemType != TokenType.LONG &&
                currentLexem.LexemType != TokenType.BOOL)
                throw new WrongNonTerminalError("тип", currentLexem.Value);
        }

        /// <summary>
        /// Список переменных
        /// </summary>
        private static void VariableList()
        {
            if (currentLexem.Type != TokenType.IDENTIFIER)
                throw new UnexpectedLexemError("идентификатор", currentLexem.Value);
            Next();
            D();
        }

        /// <summary>
        /// <спис_перем>::=id<D>
        /// </summary>
        private static void D()
        {
            if (currentLexem.LexemType == TokenType.SEMICOLON)
                return;
            C();
        }

        /// <summary>
        /// <C>::=id<D>
        /// </summary>
        private static void C()
        {
            if (currentLexem.LexemType != TokenType.COMMA)
                throw new UnexpectedLexemError(",", currentLexem.Value);
            Next();
            if (currentLexem.Type != TokenType.IDENTIFIER)
                throw new UnexpectedLexemError("идентификатор", currentLexem.Value);
            Next();
            D();
        }

        /// <summary>
        /// Список операторов
        /// </summary>
        private static void OperatorList()
        {
            Operator();
            X();
        }

        /// <summary>
        /// Оператор
        /// </summary>
        private static void Operator()
        {
            
            switch (currentLexem.LexemType)
            {
                case TokenType.IDENTIFIER:
                    Assignment();
                    break;

                case TokenType.WHILE:
                    Loop();
                    break;

                default:
                    throw new WrongNonTerminalError("оператор", currentLexem.Value);
            }
        }

        /// <summary>
        /// Присваивание
        /// </summary>
        private static void Assignment()
        {
            if (currentLexem.LexemType != TokenType.IDENTIFIER)
                throw new UnexpectedLexemError("идентификатор", currentLexem.Value);
            Next();
            if (currentLexem.LexemType != TokenType.ASSIGN)
                throw new UnexpectedLexemError ("=", currentLexem.Value);
            Next();
            ArithmeticExpression();
        }

        /// <summary>
        /// Цикл
        /// </summary>
        private static void Loop()
        {
            if (currentLexem.LexemType != TokenType.WHILE)
                throw new UnexpectedLexemError("while", currentLexem.Value);
            Next();
            if (currentLexem.LexemType != TokenType.LEFTBRACKET)
                throw new UnexpectedLexemError("(", currentLexem.Value);
            Next();
            LogicExpression();
            Next();
            if (currentLexem.LexemType != TokenType.RIGHTBRACKET)
                throw new UnexpectedLexemError(")", currentLexem.Value);
            Next();
            if (currentLexem.LexemType != TokenType.LEFTFIGURE)
                throw new UnexpectedLexemError("{", currentLexem.Value);
            Next();
            OperatorList();
            Next();
            if (currentLexem.LexemType != TokenType.RIGHTFIGURE)
                throw new UnexpectedLexemError("}", currentLexem.Value);
        }

        /// <summary>
        /// Арифметическое выражение
        /// </summary>
        private static void ArithmeticExpression()
        {
            Operand();
            Next();
            if (currentLexem.LexemType == TokenType.SEMICOLON)
                return;
            ArithmeticOperation();
            Next();
            Operand();
            Next(); 
        }

        /// <summary>
        /// Логическое выражение
        /// </summary>
        private static void LogicExpression()
        {
            Operand();
            Next();
            LogicOperation();
            Next();
            Operand();
        }

        /// <summary>
        /// Операнд
        /// </summary>
        private static void Operand()
        {
            if (currentLexem.LexemType != TokenType.IDENTIFIER &&
                currentLexem.LexemType != TokenType.LITERAL)
                throw new WrongNonTerminalError("операнд", currentLexem.Value);
        }

        /// <summary>
        /// Арифметическая операция
        /// </summary>
        private static void ArithmeticOperation()
        {
            if (currentLexem.LexemType != TokenType.PLUS  &&
                currentLexem.LexemType != TokenType.MINUS &&
                currentLexem.LexemType != TokenType.MUL   &&
                currentLexem.LexemType != TokenType.DIV)
                throw new UnknownArithmeticOperationError(currentLexem.Value);
        }

        /// <summary>
        /// Логическая операция
        /// </summary>
        private static void LogicOperation()
        {
            if (currentLexem.LexemType != TokenType.LESS          &&
                currentLexem.LexemType != TokenType.LESS_OR_EQUAL &&
                currentLexem.LexemType != TokenType.MORE          &&
                currentLexem.LexemType != TokenType.MORE_OR_EQUAL &&
                currentLexem.LexemType != TokenType.EQUAL         &&
                currentLexem.LexemType != TokenType.NOT_EQUAL)
                throw new UnknownLogicOperationError(currentLexem.Value);
        }

        /// <summary>
        /// <спис_опер>::=<опер><X>
        /// </summary>
        private static void X()
        {      
            if (nextLexem.LexemType == TokenType.IDENTIFIER ||
               nextLexem.LexemType == TokenType.WHILE)
               Y();
           else
              return;
        }

        /// <summary>
        /// <X>::=<Y>
        /// </summary>
        private static void Y()
        {
            if (currentLexem.LexemType != TokenType.SEMICOLON)
                throw new UnexpectedLexemError("; или }", currentLexem.Value);
            Next();
            if (currentLexem.LexemType != TokenType.RIGHTFIGURE)
                Operator();
            X();
        }
        #endregion
    }
}
