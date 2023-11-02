using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace dosymep.Revit.ServerClient {
    /// <summary>
    /// Интерфейс сериализатора
    /// </summary>
    public interface ISerializer {
        /// <summary>
        /// Десериализует строку в объект.
        /// </summary>
        /// <typeparam name="T">Тип результата десериализации.</typeparam>
        /// <param name="text">Строка десериализуемого объекта.</param>
        /// <returns></returns>
        T Deserialize<T>(string text);
    }
}
