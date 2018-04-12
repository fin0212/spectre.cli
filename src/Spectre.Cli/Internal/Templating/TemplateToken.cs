﻿namespace Spectre.Cli.Internal.Templating
{
    internal sealed class TemplateToken
    {
        public Kind TokenKind { get; }
        public int Position { get; set; }
        public string Value { get; }
        public string Representation { get; }

        public TemplateToken(Kind kind, int position, string value, string representation)
        {
            TokenKind = kind;
            Position = position;
            Value = value;
            Representation = representation;
        }

        public enum Kind
        {
            Unknown = 0,
            LongName,
            ShortName,
            RequiredValue,
            OptionalValue
        }
    }
}