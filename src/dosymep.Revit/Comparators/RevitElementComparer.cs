using System;
using System.Collections;
using System.Collections.Generic;

using Autodesk.Revit.DB;

namespace dosymep.Revit.Comparators {
    /// <summary>
    /// Предоставляет абстрактный базовый класс для сравнения элементов Revit.
    /// Этот класс реализует различные интерфейсы сравнения и проверки на равенство,
    /// что позволяет задавать пользовательскую логику сравнения объектов
    /// Revit <see cref="Autodesk.Revit.DB.Element"/>.
    /// </summary>
    /// <remarks>
    /// Производные классы должны переопределить абстрактные методы,
    /// чтобы реализовать конкретную логику сравнения и вычисления хэша
    /// в соответствии с требованиями конкретного сценария сравнения в Revit.
    /// </remarks>
    public abstract class RevitElementComparer :
        IComparer,
        IEqualityComparer,
        IComparer<Element>,
        IEqualityComparer<Element> {
        /// <inheritdoc />
        public int Compare(object x, object y) {
            return Compare(x as Element, y as Element);
        }

        /// <inheritdoc />
        public abstract int Compare(Element x, Element y);

        /// <inheritdoc />
        public new bool Equals(object x, object y) {
            return Equals(x as Element, y as Element);
        }

        /// <inheritdoc />
        public int GetHashCode(object obj) {
            if(obj == null) {
                throw new ArgumentNullException(nameof(obj));
            }

            return obj is Element tObj ? GetHashCode(tObj) : obj.GetHashCode();
        }

        /// <inheritdoc />
        public abstract bool Equals(Element x, Element y);

        /// <inheritdoc />
        public abstract int GetHashCode(Element obj);
    }
}