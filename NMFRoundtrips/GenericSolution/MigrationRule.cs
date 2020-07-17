using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Reflection;
using System.Text;
using NMF.Models;
using NMF.Models.Meta;
using NMF.Models.Repository;
using NMF.Synchronizations;
using NMF.Utilities;

namespace TTC2020.Roundtrip.NMFSolution
{
    public class MigrationRule<TOld, TNew> : SynchronizationRule<TOld, TNew>
        where TOld : class, IModelElement
        where TNew : class, IModelElement
    {
        private static readonly IClass oldModelClass = MetaRepository.Instance.ResolveClass(typeof(TOld)) as IClass;
        private static readonly IClass newModelClass = MetaRepository.Instance.ResolveClass(typeof(TNew)) as IClass;

        private static readonly MethodInfo singleAttribute;
        private static readonly MethodInfo singleReference;

        static MigrationRule()
        {
            var methods = typeof(MigrationRule<TOld,TNew>).GetMethods();
            singleAttribute = methods.FirstOrDefault(m => m.Name == "Synchronize" && m.IsGenericMethodDefinition && m.GetGenericArguments().Length == 1 && m.GetParameters().Length == 2);
            singleReference = methods.FirstOrDefault(m => m.Name == "Synchronize" && m.IsGenericMethodDefinition && m.GetGenericArguments().Length == 2 && m.GetParameters().Length == 4);
        }
        public override void DeclareSynchronization()
        {
            foreach (var att in oldModelClass.Attributes)
            {
                var newAtt = newModelClass.Attributes.FirstOrDefault(a => a.Name == att.Name);
                if (newAtt != null && att.Type == newAtt.Type && newAtt.LowerBound == att.LowerBound)
                {
                    // Create Synchronize call
                    var lambda = CreateLambdaFor<TOld>(att);
                    singleAttribute
                        .MakeGenericMethod(lambda.ReturnType)
                        .Invoke(this, new object[] { lambda, CreateLambdaFor<TNew>(newAtt) });
                }
            }

            foreach (var oldReference in oldModelClass.References)
            {
                var newReference = newModelClass.References.FirstOrDefault(r => r.Name == oldReference.Name);
                if (newReference != null && newReference.LowerBound == oldReference.LowerBound)
                {
                    // Create Synchronize call
                    var oldLambda = CreateLambdaFor<TOld>(oldReference);
                    var newLambda = CreateLambdaFor<TNew>(newReference);
                    var rule = Synchronization.GetSynchronizationRuleForSignature(oldLambda.ReturnType, newLambda.ReturnType);
                    singleReference
                        .MakeGenericMethod(oldLambda.ReturnType, newLambda.ReturnType)
                        .Invoke(this, new object[] { rule, oldLambda, newLambda, null });
                }
            }
        }

        public override bool ShouldCorrespond(TOld left, TNew right, ISynchronizationContext context)
        {
            if (left.IsIdentified && right.IsIdentified)
            {
                return left.ToIdentifierString() == right.ToIdentifierString();
            }
            return false;
        }


        private static LambdaExpression CreateLambdaFor<T>(ITypedElement feature)
        {
            var par = Expression.Parameter(typeof(T), "element");
            return Expression.Lambda(Expression.MakeMemberAccess(par, typeof(T).GetProperty(feature.Name.ToPascalCase())), par);
        }
    }
}
