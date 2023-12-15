using System;
using System.Collections.Generic;
using System.Reflection;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace BankTellerExerciseTests.Classes
{
    [TestClass]
    public class BankAccountTests
    {
        private const string ClassName = "BankAccount";
        private const string NamespaceName = "BankTellerExercise.Classes";

        private static Type classType;

        private enum GetterSetterRequired
        {
            None = 0,
            Private,
            Public
        }

        [TestMethod]
        public void Test01_ClassWellFormed()
        {
            string wellFormedCheck = ClassWellFormedCheck();
            if (!string.IsNullOrEmpty(wellFormedCheck))
            {
                Assert.Fail(wellFormedCheck);
            }
        }

        [TestMethod]
        public void Test02_HappyPathTests()
        {
            string wellFormedCheck = ClassWellFormedCheck();
            if (!string.IsNullOrEmpty(wellFormedCheck))
            {
                Assert.Fail($"{ClassName} is not well formed. The Test01_ClassWellFormed tests must pass first.\r\n\t{wellFormedCheck}");
            }

            // Assert constructors set properties
            string testAccountHolderName = "Tester Testerson";
            string testAccountNumber = "CHK:1234";
            decimal testBalance = 100M;

            // Two arg constructor
            object twoArgInstance = SafeReflection.CreateInstance(classType, new object[] { testAccountHolderName, testAccountNumber });
            object twoArgAccountHolderName = SafeReflection.GetPropertyValue(twoArgInstance, "AccountHolderName");
            object twoArgAccountNumber = SafeReflection.GetPropertyValue(twoArgInstance, "AccountNumber");
            Assert.AreEqual(testAccountHolderName, twoArgAccountHolderName, $"{ClassName} two argument constructor {ClassName}(string, string) does not correctly set the property AccountHolderName.");
            Assert.AreEqual(testAccountNumber, twoArgAccountNumber, $"{ClassName} two argument constructor {ClassName}(string, string) does not correctly set the property AccountNumber.");

            // Three arg constructor
            object threeArgInstance = SafeReflection.CreateInstance(classType, new object[] { testAccountHolderName, testAccountNumber, testBalance });
            object threeArgAccountHolderName = SafeReflection.GetPropertyValue(threeArgInstance, "AccountHolderName");
            object threeArgAccountNumber = SafeReflection.GetPropertyValue(threeArgInstance, "AccountNumber");
            object threeArgBalance = SafeReflection.GetPropertyValue(threeArgInstance, "Balance");
            Assert.AreEqual(testAccountHolderName, threeArgAccountHolderName, $"{ClassName} three argument constructor {ClassName}(string, string, decimal) does not correctly set the property AccountHolderName.");
            Assert.AreEqual(testAccountNumber, threeArgAccountNumber, $"{ClassName} three argument constructor {ClassName}(string, string, decimal) does not correctly set the property AccountNumber.");
            Assert.AreEqual(testBalance, threeArgBalance, $"{ClassName} three argument constructor {ClassName}(string, string, decimal) does not correctly set the property Balance.");

            // Assert deposit increases balance
            MethodInfo deposit = SafeReflection.GetMethod(classType, "Deposit");
            decimal depositParamValue = 23;
            decimal depositExpectedReturnValue = testBalance + depositParamValue;
            object depositActualReturnValue = deposit.Invoke(threeArgInstance, new object[] { depositParamValue });
            Assert.AreEqual(depositExpectedReturnValue, depositActualReturnValue, $"{ClassName} Deposit method fails to increase balance by correct amount. Starting balance: {testBalance}, deposit: {depositParamValue}, new balance should be {depositExpectedReturnValue}.");

            // Assert withdraw decreases balance
            MethodInfo withdraw = SafeReflection.GetMethod(classType, "Withdraw");
            decimal withdrawParamValue = 22;
            decimal withdrawExpectedReturnValue = depositExpectedReturnValue - withdrawParamValue;
            object withdrawActualReturnValue = withdraw.Invoke(threeArgInstance, new object[] { withdrawParamValue });
            Assert.AreEqual(withdrawExpectedReturnValue, withdrawActualReturnValue, $"{ClassName} Withdraw method fails to decrease balance by correct amount. Starting balance: {depositExpectedReturnValue}, withdraw: {withdrawParamValue}, new balance should be {withdrawExpectedReturnValue}.");
        }

        [TestMethod]
        public void Test03_EdgeCaseTests()
        {
            string wellFormedCheck = ClassWellFormedCheck();
            if (!string.IsNullOrEmpty(wellFormedCheck))
            {
                Assert.Fail($"{ClassName} is not well formed. The Test01_ClassWellFormed tests must pass first.\r\n\t{wellFormedCheck}");
            }

            MethodInfo deposit = SafeReflection.GetMethod(classType, "Deposit");
            MethodInfo withdraw = SafeReflection.GetMethod(classType, "Withdraw");

            // Assert two argument constructor defaults balance to 0
            object account = SafeReflection.CreateInstance(classType, new object[] { "", "" });
            object balance = SafeReflection.GetPropertyValue(account, "Balance");
            Assert.AreEqual(0M, balance, $"{ClassName} two argument constructor {ClassName}(string, string) does not correctly default Balance to 0.");

            // Assert withdraw method can handle 0 balance
            account = SafeReflection.CreateInstance(classType, new object[] { "", "", 1M });
            withdraw.Invoke(account, new object[] { 1M });
            balance = SafeReflection.GetPropertyValue(account, "Balance");
            Assert.AreEqual(0M, balance, $"{ClassName} Withdraw method fails to decrease balance by correct amount. Starting balance: 1, withdraw: 1, new balance should be 0.");

            // Assert deposit method can handle 0 balance
            account = SafeReflection.CreateInstance(classType, new object[] { "", "", 0M });
            deposit.Invoke(account, new object[] { 1M });
            balance = SafeReflection.GetPropertyValue(account, "Balance");
            Assert.AreEqual(1M, balance, $"{ClassName} Deposit method fails to increase balance by correct amount. Starting balance: 0, deposit: 1, new balance should be 1.");

            // Assert can't deposit a negative amount
            account = SafeReflection.CreateInstance(classType, new object[] { "", "", 100M });
            deposit.Invoke(account, new object[] { -10M });
            balance = SafeReflection.GetPropertyValue(account, "Balance");
            Assert.AreEqual(100M, balance, $"{ClassName} Deposit method fails to prevent negative deposit amount. Starting balance: 100, deposit: -10, balance should remain at 100.");

            // Assert can't withdraw a negative amount
            account = SafeReflection.CreateInstance(classType, new object[] { "", "", 100M });
            withdraw.Invoke(account, new object[] { -10M });
            balance = SafeReflection.GetPropertyValue(account, "Balance");
            Assert.AreEqual(100M, balance, $"{ClassName} Withdraw method fails to prevent negative withdraw amount. Starting balance: 100, withdraw: -10, balance should remain at 100.");
        }

        private string ClassWellFormedCheck()
        {
            // Assert class exists
            classType = SafeReflection.GetType(ClassName, NamespaceName);

            if (classType == null) { return $"{ClassName} class not found. Have you declared it yet? Make sure the class name is '{ClassName}' and the namespace is '{NamespaceName}'."; }

            if (classType.IsAbstract) { return $"{ClassName} class must not be abstract. Remove the 'abstract' modifier on {ClassName}."; }

            // Assert constructors exist
            ConstructorInfo twoArgConstructor = SafeReflection.GetConstructor(classType, new Type[] { typeof(string), typeof(string) });
            if (twoArgConstructor == null) { return $"{ClassName} does not have the required two argument constructor {ClassName}(string, string). Make sure access for the constructor is public."; }

            ConstructorInfo threeArgConstructor = SafeReflection.GetConstructor(classType, new Type[] { typeof(string), typeof(string), typeof(decimal) });
            if (threeArgConstructor == null) { return $"{ClassName} does not have the required three argument constructor {ClassName}(string, string, decimal). Make sure access for the constructor is public."; }

            // Assert properties exist, are of correct type and access
            string propertyCheck = CheckProperty("AccountHolderName", typeof(string), GetterSetterRequired.Public, GetterSetterRequired.Private);
            if (!string.IsNullOrEmpty(propertyCheck)) { return propertyCheck; }

            propertyCheck = CheckProperty("AccountNumber", typeof(string), GetterSetterRequired.Public, GetterSetterRequired.None);
            if (!string.IsNullOrEmpty(propertyCheck)) { return propertyCheck; }

            propertyCheck = CheckProperty("Balance", typeof(decimal), GetterSetterRequired.Public, GetterSetterRequired.Private);
            if (!string.IsNullOrEmpty(propertyCheck)) { return propertyCheck; }

            // Assert methods are present -- whether they work is confirmed in other test methods
            string methodCheck = CheckMethod("Deposit", typeof(decimal), true, false, new Type[] { typeof(decimal) });
            if (!string.IsNullOrEmpty(methodCheck)) { return methodCheck; }
            methodCheck = CheckMethod("Withdraw", typeof(decimal), true, true, new Type[] { typeof(decimal) });
            if (!string.IsNullOrEmpty(methodCheck)) { return methodCheck; }

            return "";
        }

        static private string AliasOrTypeName(Type t)
        {
            Dictionary<Type, string> typeAliases = new Dictionary<Type, string>()
            {
                { typeof(byte), "byte" },
                { typeof(sbyte), "sbyte" },
                { typeof(short), "short" },
                { typeof(ushort), "ushort" },
                { typeof(int), "int" },
                { typeof(uint), "uint" },
                { typeof(long), "long" },
                { typeof(ulong), "ulong" },
                { typeof(float), "float" },
                { typeof(double), "double" },
                { typeof(decimal), "decimal" },
                { typeof(object), "object" },
                { typeof(bool), "bool" },
                { typeof(char), "char" },
                { typeof(string), "string" },
                { typeof(void), "void" }
            };
            return typeAliases.ContainsKey(t) ? typeAliases[t] : t.Name;
        }

        public static string GetTypeName(Type t)
        {
            if (!t.IsGenericType)
            {
                return AliasOrTypeName(t);
            }

            // Build the Generic representation
            string genericArguments = "";
            foreach (Type argType in t.GetGenericArguments())
            {
                if (genericArguments.Length > 0) genericArguments += ", ";
                genericArguments += GetTypeName(argType);
            }
            return $"{t.Name.Substring(0, t.Name.IndexOf("`"))}<{genericArguments}>";
        }

        private string CheckProperty(string propertyName, Type propertyType, GetterSetterRequired getterRequired = GetterSetterRequired.Public, GetterSetterRequired setterRequired = GetterSetterRequired.Public)
        {
            // Assert property exists, is of correct type and access
            PropertyInfo propertyInfo = SafeReflection.GetProperty(classType, propertyName);
            if (propertyInfo == null) { return $"{ClassName} does not have the required property {propertyName}."; }

            if (propertyInfo.PropertyType != propertyType) { return $"{ClassName} property {propertyName} must be type {GetTypeName(propertyType)}."; }

            MethodInfo getMethodInfo = propertyInfo.GetMethod;
            if (getterRequired == GetterSetterRequired.None)
            {
                if (getMethodInfo != null) { return $"{ClassName} property {propertyName} must NOT have a getter."; }
            }
            else // A getter is required
            {
                if (getMethodInfo == null) { return $"{ClassName} property {propertyName} must have a getter."; }
                // A private getter is required
                if (getterRequired == GetterSetterRequired.Private)
                {
                    if (!getMethodInfo.IsPrivate) { return $"{ClassName} property {propertyName} getter must be private."; }
                }
                else // A public getter is required
                {
                    if (!getMethodInfo.IsPublic) { return $"{ClassName} property {propertyName} getter must be public."; }
                }
            }

            MethodInfo setMethodInfo = propertyInfo.SetMethod;
            if (setterRequired == GetterSetterRequired.None)
            {
                if (setMethodInfo != null) { return $"{ClassName} property {propertyName} must NOT have a setter."; }
            }
            else // A setter is required
            {
                if (setMethodInfo == null) { return $"{ClassName} property {propertyName} must have a setter."; }
                // A private setter is required
                if (setterRequired == GetterSetterRequired.Private)
                {
                    if (!setMethodInfo.IsPrivate) { return $"{ClassName} property {propertyName} setter must be private."; }
                }
                else // A public setter is required
                {
                    if (!setMethodInfo.IsPublic) { return $"{ClassName} property {propertyName} setter must be public."; }
                }
            }
            return "";
        }

        private string CheckMethod(string methodName, Type returnType, bool isPublic, bool isVirtual, Type[] parameters)
        {
            MethodInfo methodInfo = SafeReflection.GetMethod(classType, methodName);
            if (methodInfo == null) { return $"{ClassName} does not have the method {methodName}."; }

            if (methodInfo.ReturnType != returnType) { return $"{ClassName} method {methodName} must return type {GetTypeName(returnType)}."; }

            if (isPublic && !methodInfo.IsPublic) { return $"{ClassName} method {methodName} must be public."; }
            if (!isPublic && methodInfo.IsPublic) { return $"{ClassName} method {methodName} must NOT be public."; }

            if (isVirtual && !methodInfo.IsVirtual) { return $"{ClassName} method {methodName} must be marked virtual."; }
            if (!isVirtual && methodInfo.IsVirtual) { return $"{ClassName} method {methodName} must NOT be marked virtual."; }

            ParameterInfo[] parameterInfo = methodInfo.GetParameters();

            if (parameterInfo.Length != parameters.Length) { return $"{ClassName} method {methodName} must accept exactly {parameters.Length} parameter{(parameters.Length == 1 ? "" : "s")}."; }

            for (int i = 0; i < parameters.Length; i++)
            {
                if (parameterInfo[i].ParameterType != parameters[i]) { return $"{ClassName} method {methodName} parameter {i} must be of type {GetTypeName(parameters[i])}."; }
            }
            return "";
        }
    }
}
