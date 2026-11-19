using ModularPipelines.Attributes;
using ModularPipelines.Options;

namespace Build.Options;

/// <summary>
/// <c>docfx [config] [OPTIONS]</c> — metadata + build (+ serve).
/// </summary>
[CliTool("docfx")]
public sealed record DocFxOptions : CommandLineToolOptions {
    /// <summary>
    /// Путь к docfx.json. По умолчанию используется docfx.json в рабочей директории.
    /// </summary>
    [CliArgument(0, Phase = CommandLinePhase.EarlyOperand)]
    public string? Config { get; init; }

    /// <summary>
    /// <c>-o|--output</c> — базовая выходная директория.
    /// </summary>
    [CliOption("--output", ShortForm = "-o")]
    public string? Output { get; init; }

    /// <summary>
    /// <c>-s|--serve</c> — поднять сайт после сборки.
    /// </summary>
    [CliFlag("--serve", ShortForm = "-s")]
    public bool? Serve { get; init; }

    /// <summary>
    /// <c>-n|--hostname</c> — хост для --serve.
    /// </summary>
    [CliOption("--hostname", ShortForm = "-n")]
    public string? Hostname { get; init; }

    /// <summary>
    /// <c>-p|--port</c> — порт для --serve.
    /// </summary>
    [CliOption("--port", ShortForm = "-p")]
    public int? Port { get; init; }

    /// <summary>
    /// <c>--open-browser</c> — открыть браузер при старте сервера.
    /// </summary>
    [CliFlag("--open-browser")]
    public bool? OpenBrowser { get; init; }
}
