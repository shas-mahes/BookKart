﻿namespace BookKart.Core.Application.Exceptions;

public class DomainException<TEntity> : CoreException
{
    public DomainException(string message = null, string errorCode = null) : base(message, errorCode)
    {

    }
}
