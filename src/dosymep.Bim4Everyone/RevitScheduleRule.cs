using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace dosymep.Bim4Everyone {
    /// <summary>
    /// Настройки спецификаций.
    /// </summary>
    public abstract class RevitScheduleRule {
        /// <summary>
        /// Наименование спецификации.
        /// </summary>
        public virtual string ScheduleName { get; set; }
    }
}
