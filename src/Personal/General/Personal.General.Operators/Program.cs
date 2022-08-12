// https://docs.microsoft.com/en-us/dotnet/csharp/language-reference/operators/boolean-logical-operators

OperatorsManager manager = new ();

#region Logical AND Operator &

Console.WriteLine("\nLogical AND Operator &\n");

var result1 = true & manager.ExecuteAndReturnFalse();
Console.WriteLine(string.Format("{0} & {1} = {2}", true, nameof(manager.ExecuteAndReturnFalse), result1));

var result2 = true & manager.ExecuteAndReturnTrue();
Console.WriteLine(string.Format("{0} & {1} = {2}", true, nameof(manager.ExecuteAndReturnTrue), result2));

// Note that the right side will be executed despite of the false in the left.
var result3 = false & manager.ExecuteAndReturnFalse();
Console.WriteLine(string.Format("{0} & {1} = {2}", false, nameof(manager.ExecuteAndReturnFalse), result3));

var result4 = false & manager.ExecuteAndReturnTrue();
Console.WriteLine(string.Format("{0} & {1} = {2}", false, nameof(manager.ExecuteAndReturnTrue), result4));

#endregion

#region Logical OR Operator |

Console.WriteLine("\nLogical OR Operator |\n");

// Note that the right side will be executed despite of the true in the left.
var resultLogicalOr1 = true | manager.ExecuteAndReturnFalse();
Console.WriteLine(string.Format("{0} | {1} = {2}", true, nameof(manager.ExecuteAndReturnFalse), resultLogicalOr1));

var resultLogicalOr2 = true | manager.ExecuteAndReturnTrue();
Console.WriteLine(string.Format("{0} | {1} = {2}", true, nameof(manager.ExecuteAndReturnTrue), resultLogicalOr2));

var resultLogicalOr3 = false | manager.ExecuteAndReturnFalse();
Console.WriteLine(string.Format("{0} | {1} = {2}", false, nameof(manager.ExecuteAndReturnFalse), resultLogicalOr3));

var resultLogicalOr4 = false | manager.ExecuteAndReturnTrue();
Console.WriteLine(string.Format("{0} | {1} = {2}", false, nameof(manager.ExecuteAndReturnTrue), resultLogicalOr4));

#endregion

Console.WriteLine("\nLogical Exclusive OR (XOR) Operator\n");

#region Logical Exclusive OR (XOR) Operator

// Note that the right side will be executed despite of the true in the left.
var resultLogicalExclusiveOr1 = true ^ manager.ExecuteAndReturnFalse();
Console.WriteLine(string.Format("{0} ^ {1} = {2}", true, nameof(manager.ExecuteAndReturnFalse), resultLogicalExclusiveOr1));

var resultLogicalExclusiveOr2 = true ^ manager.ExecuteAndReturnTrue();
Console.WriteLine(string.Format("{0} ^ {1} = {2}", true, nameof(manager.ExecuteAndReturnTrue), resultLogicalExclusiveOr2));

var resultLogicalExclusiveOr3 = false ^ manager.ExecuteAndReturnFalse();
Console.WriteLine(string.Format("{0} ^ {1} = {2}", false, nameof(manager.ExecuteAndReturnFalse), resultLogicalExclusiveOr3));

var resultLogicalExclusiveOr4 = false ^ manager.ExecuteAndReturnTrue();
Console.WriteLine(string.Format("{0} ^ {1} = {2}", false, nameof(manager.ExecuteAndReturnTrue), resultLogicalExclusiveOr4));

#endregion