﻿namespace LawFirm.Application.Exceptions;

public class StorageException : Exception
{
    public StorageException(string message) : base(message) { }
}