using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using CTranslator.Analysis;

namespace CTranslator
{
    public partial class TablesForm : Form
    {
        public TablesForm()
        {
            InitializeComponent();
            // вывод таблицы лексем
            dgvLexems.Rows.Clear();
            foreach (var token in Scanner.Tokens)
            {
                int index = dgvLexems.Rows.Add();
                dgvLexems.Rows[index].Cells["LexemValue"].Value = token.Value;
                switch (token.Type)
                {
                    case TokenType.DELIMITER:
                        dgvLexems.Rows[index].Cells["LexemType"].Value = "разделитель";
                        break;
                    case TokenType.IDENTIFIER:
                        dgvLexems.Rows[index].Cells["LexemType"].Value = "идентификатор";
                        break;
                    case TokenType.LITERAL:
                        dgvLexems.Rows[index].Cells["LexemType"].Value = "литерал";
                        break;
                }
            }

            // вывод таблицы ключевых слов
            dgvSpecialWords.Rows.Clear();
            foreach (var specialWord in Scanner.SpecialWords.Keys.ToList())
            {
                int index = dgvSpecialWords.Rows.Add();
                dgvSpecialWords.Rows[index].Cells["SpecialWordID"].Value = (index + 1).ToString();
                dgvSpecialWords.Rows[index].Cells["SpecialWord"].Value = specialWord.ToString();
            }

            // вывод таблицы разделителей
            dgvDelimiters.Rows.Clear();
            foreach (var delimiter in Scanner.Delimiters)
            {
                int index = dgvDelimiters.Rows.Add();
                dgvDelimiters.Rows[index].Cells["DelimiterID"].Value = (index + 1).ToString();
                dgvDelimiters.Rows[index].Cells["Delimiter"].Value = delimiter.ToString();
            }

            // вывод таблицы литералов
            dgvLiterals.Rows.Clear();
            foreach (var literal in Scanner.Literals)
            {
                int index = dgvLiterals.Rows.Add();
                dgvLiterals.Rows[index].Cells["LiteralID"].Value = (index + 1).ToString();
                dgvLiterals.Rows[index].Cells["Literal"].Value = literal.ToString();
            }

            // вывод таблицы идентификаторов
            dgvIdentifiers.Rows.Clear();
            foreach (var identifier in Scanner.Identifiers)
            {
                int index = dgvIdentifiers.Rows.Add();
                dgvIdentifiers.Rows[index].Cells["IdentifierID"].Value = (index + 1).ToString();
                dgvIdentifiers.Rows[index].Cells["Identifier"].Value = identifier.ToString();
            }
        }
    }
}
