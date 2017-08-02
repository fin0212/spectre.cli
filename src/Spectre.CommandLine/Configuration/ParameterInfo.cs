﻿using System;
using System.ComponentModel;
using System.Reflection;
using Spectre.CommandLine.Annotations;

namespace Spectre.CommandLine.Configuration
{
    internal sealed class ParameterInfo
    {
        public Type Type { get; }
        public ParameterType ParameterType { get; }
        public PropertyInfo Property { get; }
        public string Description { get; }
        public bool IsInherited { get; }
        public TypeConverterAttribute Converter { get; }
        public bool IsRequired { get; }

        private ParameterInfo(
            Type type, ParameterType parameterType, PropertyInfo property, string description,
            bool isInherited, TypeConverterAttribute converter, bool isRequired)
        {
            Type = type;
            ParameterType = parameterType;
            Property = property;
            Description = description;
            IsInherited = isInherited;
            Converter = converter;
            IsRequired = isRequired;
        }

        public static ParameterInfo Create(CommandInfo command, PropertyInfo property)
        {
            var description = property.GetCustomAttribute<DescriptionAttribute>()?.Description;
            var converter = property.GetCustomAttribute<TypeConverterAttribute>();
            var required = property.GetCustomAttribute<RequiredAttribute>() != null;
            var inherited = property.DeclaringType != command.SettingsType;

            var type = property.PropertyType == typeof(bool)
                ? ParameterType.Flag : ParameterType.Single;

            return new ParameterInfo(property.PropertyType, type, property, description, inherited, converter, required);
        }
    }
}