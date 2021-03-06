﻿using System.ComponentModel;
using Spectre.Cli;

namespace Sample.Commands.Settings
{
    public abstract class AddSettings : CommandSettings
    {
        [CommandArgument(0, "[PROJECT]")]
        [Description("Specifies the project file.")]
        public string Project { get; set; }
    }
}
