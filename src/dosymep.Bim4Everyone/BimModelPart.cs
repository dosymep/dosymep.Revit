using System;

namespace dosymep.Bim4Everyone
{
    /// <summary>
    /// Класс предоставляющий информацию о разделе.
    /// </summary>
    public class BimModelPart : IEquatable<BimModelPart> {
        /// <summary>
        /// AR
        /// </summary>
        public static readonly BimModelPart ARPart =
            new BimModelPart() {Id = "AR", Name = "АР", Description = "Архитектурные решения"};

        /// <summary>
        /// KR
        /// </summary>
        public static readonly BimModelPart KRPart =
            new BimModelPart() {Id = "KR", Name = "КР", Description = "Конструктивные решения"};

        /// <summary>
        /// KM
        /// </summary>
        public static readonly BimModelPart KMPart =
            new BimModelPart() {Id = "KM", Name = "КМ", Description = "Конструкции металлические"};

        /// <summary>
        /// OV
        /// </summary>
        public static readonly BimModelPart OVPart =
            new BimModelPart() {Id = "OV", Name = "ОВК", Description = "Вентиляция"};

        /// <summary>
        /// ITP
        /// </summary>
        public static readonly BimModelPart ITPPart =
            new BimModelPart() {Id = "ITP", Name = "ИТП", Description = "ЦТП/ИТП"};

        /// <summary>
        /// HC
        /// </summary>
        public static readonly BimModelPart HCPart =
            new BimModelPart() {Id = "HC", Name = "ХЦ", Description = "Хладоцентр"};

        /// <summary>
        /// VK
        /// </summary>
        public static readonly BimModelPart VKPart =
            new BimModelPart() {Id = "VK", Name = "ВК", Description = "Водоснабжение"};

        /// <summary>
        /// ЕОМ
        /// </summary>
        public static readonly BimModelPart EOMPart =
            new BimModelPart() {Id = "EOM", Name = "ЭОМ", Description = "Система электроснабжения"};

        /// <summary>
        /// EG
        /// </summary>
        public static readonly BimModelPart EGPart =
            new BimModelPart() {Id = "EG", Name = "ЭГ", Description = "Молниезащита"};

        /// <summary>
        /// SS
        /// </summary>
        public static readonly BimModelPart SSPart =
            new BimModelPart() {Id = "SS", Name = "CC", Description = "Слаботочные системы"};

        /// <summary>
        /// GP
        /// </summary>
        public static readonly BimModelPart GPPart = new BimModelPart() {
            Id = "GP", Name = "ГП", Description = "Благоустройство, окружение и генплан"
        };

        /// <summary>
        /// KOORD
        /// </summary>
        public static readonly BimModelPart KOORDPart =
            new BimModelPart() {Id = "KOORD", Name = "КООРД", Description = "Координационный файл"};


        /// <summary>
        /// VN
        /// </summary>
        public static readonly BimModelPart VNPart =
            new BimModelSubPart() {
                Parent = OVPart, Id = "VN", Name = "ВН", Description = "Системы общеобменной вентиляции"
            };

        /// <summary>
        /// KV
        /// </summary>
        public static readonly BimModelPart KVPart =
            new BimModelSubPart() {
                Parent = OVPart, Id = "KV", Name = "КВ", Description = "Кониционирование/Холодноснабжение"
            };

        /// <summary>
        /// OT
        /// </summary>
        public static readonly BimModelPart OTPart =
            new BimModelSubPart() {
                Parent = OVPart, Id = "OT", Name = "ОТ", Description = "Системы отопления и теплоснабжения"
            };

        /// <summary>
        /// DU
        /// </summary>
        public static readonly BimModelPart DUPart =
            new BimModelSubPart() {
                Parent = OVPart, Id = "DU", Name = "ДУ", Description = "Противодымная вентиляция и дымоудаление"
            };

        /// <summary>
        /// VS
        /// </summary>
        public static readonly BimModelPart VSPart =
            new BimModelSubPart() {Parent = VKPart, Id = "VS", Name = "ВС", Description = "Системы водоснабжения"};

        /// <summary>
        /// KN
        /// </summary>
        public static readonly BimModelPart KNPart =
            new BimModelSubPart() {Parent = VKPart, Id = "KN", Name = "КН", Description = "Системы водоотведения"};

        /// <summary>
        /// PT
        /// </summary>
        public static readonly BimModelPart PTPart =
            new BimModelSubPart() {
                Parent = VKPart, Id = "PT", Name = "ПТ", Description = "Система водяного пожаротушения"
            };

        /// <summary>
        /// EO
        /// </summary>
        public static readonly BimModelPart EOPart =
            new BimModelSubPart() {Parent = EOMPart, Id = "EO", Name = "ЕО", Description = "Системы электроснабжения"};

        /// <summary>
        /// EM
        /// </summary>
        public static readonly BimModelPart EMPart =
            new BimModelSubPart() {Parent = EOMPart, Id = "EM", Name = "EM", Description = "Системы электроснабжения"};

        /// <summary>
        /// Идентификатор раздела.
        /// </summary>
        public string Id { get; private set; }

        /// <summary>
        /// Наименование раздела.
        /// </summary>
        public string Name { get; private set; }

        /// <summary>
        /// Описание раздела.
        /// </summary>
        public string Description { get; private set; }

        internal virtual bool IsBimPart(string documentName) {
            return documentName.Contains("_" + Id);
        }

        #region IEquatable<BimModelPart>

        /// <inheritdoc />
        public bool Equals(BimModelPart other) {
            if(ReferenceEquals(null, other)) {
                return false;
            }

            if(ReferenceEquals(this, other)) {
                return true;
            }

            return Id == other.Id;
        }

        /// <inheritdoc />
        public override bool Equals(object obj) {
            if(ReferenceEquals(null, obj)) {
                return false;
            }

            if(ReferenceEquals(this, obj)) {
                return true;
            }

            if(obj.GetType() != this.GetType()) {
                return false;
            }

            return Equals((BimModelPart) obj);
        }

        /// <inheritdoc />
        public override int GetHashCode() {
            return (Id != null ? Id.GetHashCode() : 0);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="left"></param>
        /// <param name="right"></param>
        /// <returns></returns>
        public static bool operator ==(BimModelPart left, BimModelPart right) {
            return Equals(left, right);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="left"></param>
        /// <param name="right"></param>
        /// <returns></returns>
        public static bool operator !=(BimModelPart left, BimModelPart right) {
            return !Equals(left, right);
        }

        #endregion
    }
    
    /// <summary>
    /// Класс предоставляющий информацию о подразделе.
    /// </summary>
    internal class BimModelSubPart : BimModelPart {
        /// <summary>
        /// Родительский раздел.
        /// </summary>
        public BimModelPart Parent { get; set; }

        internal override bool IsBimPart(string documentName) {
            return documentName.Contains("_" + Parent.Id + "_" + Id) || base.IsBimPart(documentName);
        }
    }
}