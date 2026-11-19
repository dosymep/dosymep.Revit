# dosymep.Revit

[![JetBrains Rider](https://img.shields.io/badge/JetBrains-Rider-blue.svg)](https://www.jetbrains.com/rider)
[![License MIT](https://img.shields.io/badge/License-MIT-blue.svg)](LICENSE.md)
[![Revit 2020-2024](https://img.shields.io/badge/Revit-2020--2024-blue.svg)](https://www.autodesk.com/products/revit/overview)

Библиотека содержит методы расширения и вспомогательные компоненты для Autodesk Revit 2020–2024.

## Сборка проекта

Для сборки используется **ModularPipelines**. Каждый режим запускается через соответствующий модуль. Зависимые модули выполняются автоматически.

### Полная сборка (CI)

Компилирует библиотеки, генерирует документацию и упаковывает библиотеки в ZIP-архивы.

Используется в GitHub Actions.

```bash
dotnet run --project build -- --module BuildDocsModule --module PackageModule
```

После компиляции библиотек генерация документации и упаковка выполняются параллельно.

### Сборка документации

Компилирует библиотеки и генерирует документацию с помощью DocFX.

```bash
dotnet run --project build -- --module BuildDocsModule
```

- **GitHub Actions** — документация генерируется в `docs/_site` без запуска сервера.
- **Локально** — запускается сервер DocFX и автоматически открывается браузер.

При локальном запуске сервер продолжает работать до остановки процесса. Для завершения нажмите `Ctrl+C` в терминале.

### Упаковка библиотек

Компилирует библиотеки и создаёт ZIP-архивы для каждой поддерживаемой версии Revit.

```bash
dotnet run --project build -- --module PackageModule
```

Архивы сохраняются в `artifacts`:

```text
artifacts/
├── dosymep.Revit.2020.zip
├── dosymep.Revit.2021.zip
├── dosymep.Revit.2022.zip
├── dosymep.Revit.2023.zip
└── dosymep.Revit.2024.zip
```

### Локальная публикация

Компилирует библиотеки и копирует их в локальную платформу BIM4Everyone для разработки и тестирования.

```bash
dotnet run --project build -- --module DeployModule
```

Результаты публикации размещаются в:

```text
%APPDATA%\pyRevit\Extensions\BIM4Everyone.lib\dosymep_libs\libs\<RevitVersion>\
```

### Компиляция библиотек

Компилирует библиотеки без генерации документации, упаковки и публикации.

```bash
dotnet run --project build -- --module BuildModule
```

Результаты сохраняются отдельно для каждой версии Revit:

```text
bin/
├── 2020/
├── 2021/
├── 2022/
├── 2023/
└── 2024/
```

## Зависимости сборки

Перед компиляцией автоматически проверяется наличие необходимых зависимостей. Если соответствующий каталог отсутствует, репозиторий скачивается из GitHub.

| Зависимость | Версия / ветка | Локальный каталог |
|---|---|---|
| [pyRevit](https://github.com/pyrevitlabs/pyRevit) | `v4.8.16.24121+2117` | `%APPDATA%\pyRevit-Master` |
| [BIM4Everyone](https://github.com/dosymep/BIM4Everyone) | `master` | `%APPDATA%\pyRevit\Extensions\BIM4Everyone.lib` |

Если каталог уже существует, повторное скачивание не выполняется.

## Каталоги проекта

| Каталог | Назначение |
|---|---|
| `src/` | Исходный код библиотек |
| `docs/` | Исходные файлы документации |
| `docs/_site/` | Сгенерированный сайт документации |
| `tests/` | Тестовые проекты |
| `build/` | Конфигурация и модули сборки |
| `bin/<RevitVersion>/` | Скомпилированные библиотеки |
| `artifacts/` | ZIP-архивы библиотек |
| `TestResults/` | Результаты тестирования |

По умолчанию используется конфигурация сборки `Debug`. Параметры сборки определяются в `BuildOptions`.