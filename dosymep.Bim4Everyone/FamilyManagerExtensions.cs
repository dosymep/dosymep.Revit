using System;

using Autodesk.Revit.DB;

namespace dosymep.Bim4Everyone {
    /// <summary>
    /// Класс расширений для менеджера семейств.
    /// </summary>
    public static class FamilyManagerExtensions {
        /// <summary>
        /// Создает параметр типа у семейства.
        /// </summary>
        /// <param name="self">Менеджер семейства.</param>
        /// <param name="revitParam">Параметр Revit.</param>
        /// <param name="group">Группа, к которой принадлежит параметр семейства.</param>
        /// <returns>Возвращает новый созданный параметр типа у семейства.</returns>
        public static FamilyParameter CreateTypeParam(this FamilyManager self,
            RevitParam revitParam,
            BuiltInParameterGroup group) {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Создает параметр типа семейства.
        /// </summary>
        /// <param name="self">Менеджер семейства.</param>
        /// <param name="revitParam">Параметр Revit.</param>
        /// <param name="group">Группа, к которой принадлежит параметр семейства.</param>
        /// <param name="category">Категория, к которой привязывается новый параметр семейства.</param>
        /// <returns>Возвращает новый созданный параметр типа у семейства.</returns>
        public static FamilyParameter CreateTypeParam(this FamilyManager self,
            RevitParam revitParam,
            BuiltInParameterGroup group,
            Category category) {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Создает параметр экземпляра у семейства.
        /// </summary>
        /// <param name="self">Менеджер семейства.</param>
        /// <param name="revitParam">Параметр Revit.</param>
        /// <param name="group">Группа, к которой принадлежит параметр семейства.</param>
        /// <returns>Возвращает новый созданный параметр экземпляра у семейства.</returns>
        public static FamilyParameter CreateInstanceParam(this FamilyManager self,
            RevitParam revitParam,
            BuiltInParameterGroup group) {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Создает параметр экземпляра семейства.
        /// </summary>
        /// <param name="self">Менеджер семейства.</param>
        /// <param name="revitParam">Параметр Revit.</param>
        /// <param name="group">Группа, к которой принадлежит параметр семейства.</param>
        /// <param name="category">Категория, к которой привязывается новый параметр семейства.</param>
        /// <returns>Возвращает новый созданный параметр экземпляра у семейства.</returns>
        public static FamilyParameter CreateInstanceParam(this FamilyManager self,
            RevitParam revitParam,
            BuiltInParameterGroup group,
            Category category) {
            throw new NotImplementedException();
        }

#if REVIT_2020 || REVIT_2021

        /// <summary>
        /// Создает параметр типа у семейства.
        /// </summary>
        /// <param name="self">Менеджер семейства.</param>
        /// <param name="revitParam">Параметр Revit.</param>
        /// <param name="group">Группа, к которой принадлежит параметр семейства.</param>
        /// <param name="parameterType">Тип создаваемого параметра у семейства.</param>
        /// <returns>Возвращает новый созданный параметр типа у семейства.</returns>
        public static FamilyParameter CreateTypeParam(this FamilyManager self,
            RevitParam revitParam,
            BuiltInParameterGroup group,
            ParameterType parameterType) {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Создает параметр экземпляра у семейства.
        /// </summary>
        /// <param name="self">Менеджер семейства.</param>
        /// <param name="revitParam">Параметр Revit.</param>
        /// <param name="group">Группа, к которой принадлежит параметр семейства.</param>
        /// <param name="parameterType">Тип создаваемого параметра у семейства.</param>
        /// <returns>Возвращает новый созданный параметр экземпляра у семейства.</returns>
        public static FamilyParameter CreateInstanceParam(this FamilyManager self,
            RevitParam revitParam,
            BuiltInParameterGroup group,
            ParameterType parameterType) {
            throw new NotImplementedException();
        }

#else

        /// <summary>
        /// Создает параметр типа у семейства.
        /// </summary>
        /// <param name="self">Менеджер семейства.</param>
        /// <param name="revitParam">Параметр Revit.</param>
        /// <param name="group">Группа, к которой принадлежит параметр семейства.</param>
        /// <param name="category">Категория, к которой привязывается новый параметр семейства.</param>
        /// <returns>Возвращает новый созданный параметр типа у семейства.</returns>
        public static FamilyParameter CreateTypeParam(this FamilyManager self,
            RevitParam revitParam,
            ForgeTypeId group,
            Category category) {
                throw new NotImplementedException();
        }

        /// <summary>
        /// Создает параметр типа у семейства.
        /// </summary>
        /// <param name="self">Менеджер семейства.</param>
        /// <param name="revitParam">Параметр Revit.</param>
        /// <param name="group">Группа, к которой принадлежит параметр семейства.</param>
        /// <param name="parameterType">Тип создаваемого параметра у семейства.</param>
        /// <returns>Возвращает новый созданный параметр типа у семейства.</returns>
        public static FamilyParameter CreateTypeParam(this FamilyManager self,
            RevitParam revitParam,
            ForgeTypeId group,
            ForgeTypeId parameterType) {
                throw new NotImplementedException();
        }

        /// <summary>
        /// Создает параметр экземпляра семейства.
        /// </summary>
        /// <param name="self">Менеджер семейства.</param>
        /// <param name="revitParam">Параметр Revit.</param>
        /// <param name="group">Группа, к которой принадлежит параметр семейства.</param>
        /// <param name="category">Категория, к которой привязывается новый параметр семейства.</param>
        /// <returns>Возвращает новый созданный параметр экземпляра у семейства.</returns>
        public static FamilyParameter CreateInstanceParam(this FamilyManager self,
            RevitParam revitParam,
            ForgeTypeId group,
            Category category) {
                throw new NotImplementedException();
        }

        /// <summary>
        /// Создает параметр экземпляра у семейства.
        /// </summary>
        /// <param name="self">Менеджер семейства.</param>
        /// <param name="revitParam">Параметр Revit.</param>
        /// <param name="group">Группа, к которой принадлежит параметр семейства.</param>
        /// <param name="parameterType">Тип создаваемого параметра у семейства.</param>
        /// <returns>Возвращает новый созданный параметр экземпляра у семейства.</returns>
        public static FamilyParameter CreateInstanceParam(this FamilyManager self,
            RevitParam revitParam,
            ForgeTypeId group,
            ForgeTypeId parameterType) {
                throw new NotImplementedException();
        }

#endif
    }
}