using System;
using System.Threading.Tasks;
using System.Windows.Media;

using dosymep.SimpleServices;

namespace dosymep.Bim4Everyone.SimpleServices.NullServices {
    internal sealed class NullNotificationService : INotificationService {
        private readonly NullNotification _nullNotification;

        public NullNotificationService() {
            _nullNotification = new NullNotification();
        }

        public INotification CreateNotification(string title, string body, string footer = null, string author = null,
            ImageSource imageSource = null) {
            return _nullNotification;
        }

        public INotification CreateFatalNotification(string title, string body, string author = null,
            ImageSource imageSource = null) {
            return _nullNotification;
        }

        public INotification CreateWarningNotification(string title, string body, string author = null,
            ImageSource imageSource = null) {
            return _nullNotification;
        }
    }

    internal sealed class NullNotification : INotification {
        public void Hide() {
        }

        public Task<bool?> ShowAsync() {
            return Task.FromResult<bool?>(default);
        }

        public Task<bool?> ShowAsync(int millisecond) {
            return Task.FromResult<bool?>(default);
        }

        public Task<bool?> ShowAsync(TimeSpan interval) {
            return Task.FromResult<bool?>(default);
        }
    }
}