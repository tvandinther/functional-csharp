namespace HierarchicalTypes;

public abstract record PaymentMethod;

public sealed record CreditCard(string Number, string Expiry, string SecurityCode) : PaymentMethod;

public sealed record BankTransfer(string AccountNumber, string SortCode) : PaymentMethod;

public sealed record Bitcoin(string Address) : PaymentMethod;

public sealed record Cash : PaymentMethod;

/*
 * The following is the equivalent F# code:
 * type PaymentMethod =
 * | CreditCard of string * string * string
 * | BankTransfer of string * string
 * | Bitcoin of string
 * | Cash
 */
