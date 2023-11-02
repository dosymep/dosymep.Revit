using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace dosymep.Revit.ServerClient {
    /// <summary>
    /// Класс для создания клиента Revit сервера.
    /// </summary>
    public class RevitServerClientBuilder {
        private string _serverName;
        private string _serverVersion;
        private ISerializer _serializer;

        /// <summary>
        /// Устанавливает наименование сервера.
        /// </summary>
        /// <param name="serverName">Наименование сервера.</param>
        /// <returns>Возвращает текущий builder.</returns>
        public RevitServerClientBuilder SetServerName(string serverName) {
            _serverName = serverName;
            return this;
        }

        /// <summary>
        /// Устанавливает версию сервера.
        /// </summary>
        /// <param name="serverVersion">Версия сервера.</param>
        /// <returns>Возвращает текущий builder.</returns>
        public RevitServerClientBuilder SetServerVersion(string serverVersion) {
            _serverVersion = serverVersion;
            return this;
        }


        /// <summary>
        /// Устанавливает JsonSerializer.
        /// </summary>
        /// <param name="serializer">Json сериализация.</param>
        /// <returns>Возвращает текущий builder.</returns>
        public RevitServerClientBuilder SetJsonSerializer(ISerializer serializer) {
            _serializer = serializer;
            return this;
        }

        /// <summary>
        /// Создает соединение с Revit сервером.
        /// </summary>
        /// <returns>Возвращает соединение с Revit сервером.</returns>
        public IRevitServerClient Build() {
            return new RevitServerClient(_serverName, _serverVersion, _serializer);
        }
    }
}
