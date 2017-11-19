using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace AUnitTestProject.CreateAndUseTypes {

    [TestClass, TestCategory(nameof(CreateAndUseTypes))]
    public class Reflection {

        [TestMethod]
        public void CodeDOMWithExpressions() {
            BlockExpression blockExpr = Expression.Block(
                Expression.Call(
                    null,
                    typeof(Console).GetMethod("Write", new Type[] { typeof(String) }),
                    Expression.Constant("Hello")
                ),
                Expression.Call(
                    null,
                    typeof(Console).GetMethod("WriteLine", new Type[] { typeof(String) }),
                    Expression.Constant("World!")
                    )
                );

            var sb = new StringBuilder();
            
            Expression.Lambda<Action>(blockExpr).Compile()();
        }
    }
}
