using System;
using System.Reflection;

namespace Timberborn.QuadrupleTerrainHeight;

public static class ReflectionExtensions
{
    private const BindingFlags BindingFlags = System.Reflection.BindingFlags.Public |
                                              System.Reflection.BindingFlags.NonPublic |
                                              System.Reflection.BindingFlags.Instance;

    public static T? GetFieldValue<T>(this object obj, string name)
    {
        var field = obj.GetType().GetField(name, BindingFlags);
        return (T?)field?.GetValue(obj);
    }

    public static object? Call(this object obj, string methodName, params object[] args)
    {
        var methodInfo = obj.GetType().GetMethod(methodName, BindingFlags);
        return methodInfo != null ? methodInfo.Invoke(obj, args) : null;
    }

    public static void Raise<TEventArgs>(this object obj, string eventName, TEventArgs eventArgs)
    {
        var field = obj.GetType().GetField(eventName, BindingFlags);
        var eventDelegate = (MulticastDelegate)field!.GetValue(obj);
        foreach (var handler in eventDelegate.GetInvocationList())
            handler.Method.Invoke(handler.Target, new[] { obj, eventArgs });
    }
}