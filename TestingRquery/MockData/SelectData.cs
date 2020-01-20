using System;
using RebelQuery.Core;
using System.Collections.Generic;
using NUnit.Framework;

namespace TestingRquery.Data
{
    using Mocks;

    public class SelectData : MocksData
    {
        /// <summary>
        /// Returns a List of objects with data to run tests.
        /// </summary>
        public static List<Object>[] WhereCaseData {
            get => new List<Object>[]{ 
                new List<Object>(new[]{
                    new {shouldReturnStatus = true, shouldReturnRowsNum = 1, args = new { Name = "='Rebecca'"}},
                    new {shouldReturnStatus = true, shouldReturnRowsNum = 0, args = new { Name = "='BillyF'"}},
                 }),
                new List<Object>(new[]{
                    new {shouldReturnStatus = false, shouldReturnRowsNum = 0, args = new { Namef = "='Rebecca'"}},
                    new {shouldReturnStatus = false, shouldReturnRowsNum = 0, args = new { Namef = "='BillyF'"}},
                 }),
                new List<Object>(new[]{
                    new {shouldReturnStatus = false, shouldReturnRowsNum = 0, args = new { Name = "'Rebecca'"}},
                    new {shouldReturnStatus = false, shouldReturnRowsNum = 0, args = new { Name = "'BillyF'"}},
                 }),
                new List<Object>(new[]{
                    new {shouldReturnStatus = true, shouldReturnRowsNum = 41, args = new{}}
                 }),
                new List<Object>(new[]{
                    new {shouldReturnStatus = true, shouldReturnRowsNum = 41, args = ""}
                 }),
                new List<Object>(new[]{
                    new {shouldReturnStatus = false, shouldReturnRowsNum = 0, args = new { Name = "IN('Rebecca', 'Billy)'"}},
                 }),

            };
        }

        /// <summary>
        /// Returns a List of objects with data to run tests.
        /// </summary>
        public static List<Object>[] SelectCaseData
        {
            get => new List<Object>[]{
                new List<Object>(new[]{
                    new {shouldReturnStatus = true, shouldReturnRowsNum = 41, args = new {}},
                 }),
                new List<Object>(new[]{
                    new {shouldReturnStatus = true, shouldReturnRowsNum = 41, args = new {name=""}},
                    new {shouldReturnStatus = true, shouldReturnRowsNum = 41, args = new {name="Any"}},
                    new {shouldReturnStatus = true, shouldReturnRowsNum = 41, args = new {name="Rebecca"}},
                 }),
                new List<Object>(new[]{
                    new {shouldReturnStatus = true, shouldReturnRowsNum = 41, args = new {name="",LastName=""}},
                    new {shouldReturnStatus = true, shouldReturnRowsNum = 41, args = new {name="Any",LastName="Any"}},
                    new {shouldReturnStatus = true, shouldReturnRowsNum = 41, args = new {name="Rebecca",LastName="Rebecca"}},
                 }),
                new List<Object>(new[]{
                    new {shouldReturnStatus = false, shouldReturnRowsNum = 0, args = new {namef="",LastName=""}},
                 })

            };
        }

        /// <summary>
        /// Gets args to be supplied in a RQuery.PassWhereArgs`s WHERE clause
        /// </summary>
        /// <param name="WhereArgsItem">A "SelectData.WhereCaseData" item.</param>
        /// <returns> A new "Object" to be passed to a RQuery.PassWhereArgs function.</returns>
        public static object GetConditionArgs (object WhereArgsItem) => 
            WhereArgsItem.GetType().GetProperty("args").GetValue(WhereArgsItem, null);

        /// <summary>
        /// Gets expected rows  to be compared with a RQuery.QuerySelector`s result
        /// </summary>
        /// <param name="WhereArgsItem">A "SelectData.WhereCaseData" item.</param>
        /// <returns>A Int32 number.</returns>
        public static int? GetExpectedItensCount(object WhereArgsItem) =>
            (int?)WhereArgsItem.GetType().GetProperty("shouldReturnRowsNum").GetValue(WhereArgsItem, null);

        /// <summary>
        /// Gets a expected status to be compared with a RQuery.QuerySelector`s result
        /// </summary>
        /// <param name="WhereArgsItem">A "SelectData.WhereCaseData" item.</param>
        /// <returns>A boolean data; true or false</returns>
        public static bool GetExpectedResultStatus(object WhereArgsItem) =>
            (bool)WhereArgsItem.GetType().GetProperty("shouldReturnStatus").GetValue(WhereArgsItem, null);

    }

}