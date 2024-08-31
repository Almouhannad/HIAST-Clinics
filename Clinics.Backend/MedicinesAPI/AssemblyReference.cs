using System.Reflection;

namespace MedicinesAPI;

public class AssemblyReference
{
    public static readonly Assembly Assembly = typeof(AssemblyReference).Assembly;
}
