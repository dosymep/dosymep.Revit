using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Autodesk.Revit.DB;

namespace dosymep.Revit {
    /// <summary>
    /// Расширения класса <see cref="Autodesk.Revit.DB.Transaction"/>
    /// </summary>
    public static class TransactionExtensions {
        /// <summary>
        /// Добавляет в название транзакции текст BIM.
        /// </summary>
        /// <param name="transaction">Транзакция.</param>
        /// <param name="transactionName">Название транзакции.</param>
        /// <returns>Возвращает статус запуска транзакции.</returns>
        public static TransactionStatus BIMStart(this Transaction transaction, string transactionName) {
            return transaction.Start("BIM: " + transactionName);
        }
        
        /// <summary>
        /// Добавляет в название транзакции текст BIM.
        /// </summary>
        /// <param name="transaction">Транзакция.</param>
        /// <param name="transactionName">Название транзакции.</param>
        /// <returns>Возвращает статус запуска транзакции.</returns>
        public static TransactionStatus BIMStart(this TransactionGroup transaction, string transactionName) {
            return transaction.Start("BIM: " + transactionName);
        }
    }
}
